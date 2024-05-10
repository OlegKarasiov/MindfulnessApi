using MindfulnessApi.Models;

namespace MindfulnessApi.Services.Interfaces
{
    public interface ITestService
    {
        Task StartTestSeedingAsync();
        Task<List<TestResult>> GetAllTestsAsync();
        Task<Test> GetTestAsync(int testId);
        Task<ResultResponse> GetTestResultAsync(int testId, List<TestAnswer> testAnswer);
    }
}
