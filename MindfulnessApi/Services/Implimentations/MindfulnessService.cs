using Azure;
using Azure.AI.OpenAI;
using MindfulnessApi.Data;
using MindfulnessApi.Models;
using MindfulnessApi.Services.Interfaces;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace MindfulnessApi.Services.Implimentations
{
    public class MindfulnessService : IMindfulnessService
    {
        private readonly ApiDbContext _context;

        public MindfulnessService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateMindfullnesAsync(QuestionsRequest questions)
        {
            string questionsSerialized = JsonSerializer.Serialize(questions);

            string nonAzureOpenAIApiKey = "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";
            var client = new OpenAIClient(nonAzureOpenAIApiKey, new OpenAIClientOptions());
            var systemRoleText = File.ReadAllText(@"ServiceFiles/OpenAiUtils/system-role.json");
            string data = JObject.Parse(systemRoleText)["SystemRole"].ToString();


            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                DeploymentName = "gpt-4o",
                Messages =
                    {
                        // The system message represents instructions or other guidance about how the assistant should behave
                        new ChatRequestSystemMessage(systemRoleText),
                        // User messages represent current or historical input from the end user
                        new ChatRequestUserMessage(questionsSerialized)
                    }
            };

            Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
            ChatResponseMessage responseMessage = response.Value.Choices[0].Message;

            return responseMessage.Content;
        }
    }
}
