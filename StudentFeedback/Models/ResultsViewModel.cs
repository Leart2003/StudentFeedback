namespace StudentFeedback.Models
{
    public class ResultsViewModel
    {
    public List<string> Subjects { get; set; } = new();

        
        public Dictionary<string, List<int>> Series { get; set; } = new();
    }
}
