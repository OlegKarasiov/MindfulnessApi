using MindfulnessApi.Models;

namespace MindfulnessApi.Services.Interfaces
{
    public interface IMindfulnessService
    {
        Task<string> GenerateMindfullnesAsync(QuestionsRequest questions);
    }
}
