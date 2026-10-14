using System.ComponentModel.DataAnnotations;

namespace StudentFeedback.Models;

public enum Sentiment
{
    [Display(Name = "Very negative")] VeryNegative = 1,
    [Display(Name = "Negative")] Negative = 2,
    [Display(Name = "Neutral")] Neutral = 3,
    [Display(Name = "Positive")] Positive = 4,
    [Display(Name = "Very positive")] VeryPositive = 5
}