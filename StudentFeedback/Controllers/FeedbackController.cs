using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentFeedback.Data;
using StudentFeedback.Models;

namespace StudentFeedback.Controllers;

[Authorize]
public class FeedbackController : Controller
{
    private readonly ApplicationDbContext _context;

    public FeedbackController(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        var name = User.Identity?.Name;
        var items = await _context.Feedbacks
            .Include(f => f.Subject)
            .Where(f => f.StudentName == name)
            .OrderByDescending(f => f.SubmittedAt)
            .ToListAsync();
        return View(items);
    }

    public async Task<IActionResult> Create()
    {
        await LoadSubjects();
        return View(new Feedback());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("SubjectId,Rating,Comments")] Feedback feedback)
    {
        feedback.StudentName = User.Identity?.Name ?? "Unknown";
        ModelState.Remove(nameof(Feedback.StudentName)); // set by the server, not the form

        if (!ModelState.IsValid)
        {
            await LoadSubjects(feedback.SubjectId);
            return View(feedback);
        }

        feedback.SubmittedAt = DateTime.UtcNow;
        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadSubjects(int? selected = null)
    {
        var subjects = await _context.Subjects.OrderBy(s => s.Name).ToListAsync();
        ViewBag.Subjects = new SelectList(subjects, "Id", "Name", selected);
    }
}