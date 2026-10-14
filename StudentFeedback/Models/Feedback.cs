using System.ComponentModel.DataAnnotations;

namespace StudentFeedback.Models;

public class Feedback
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    [Display(Name = "Student Name")]
    public string StudentName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Subject")]
    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }

    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    [Required(ErrorMessage = "Please choose how you feel about this subject")]
    [Display(Name = "Your opinion")]
    public Sentiment? Rating { get; set; }

    [Required, StringLength(1000)]
    public string Comments { get; set; } = string.Empty;

    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}