using System.ComponentModel.DataAnnotations;

namespace StudentFeedback.Models;

public class Subject
{
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Name { get; set; } = string.Empty;

    public bool IsElective { get; set; }

    public List<Feedback> Feedbacks { get; set; } = new();
}