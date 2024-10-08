﻿namespace MindfulnessApi.Models
{
    public class Test
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Question> Questions { get; set; }

        public List<Result> Results { get; set; }
    }
}
