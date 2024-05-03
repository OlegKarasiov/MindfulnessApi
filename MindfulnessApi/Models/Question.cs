namespace MindfulnessApi.Models
{
    public class Question
    {
        public int Id { get; set; }

        public int? Type { get; set; }

        public string QuestionText { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
