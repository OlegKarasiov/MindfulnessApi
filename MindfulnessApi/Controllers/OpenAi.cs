using Azure;
using Azure.AI.OpenAI;
using Microsoft.AspNetCore.Mvc;
using MindfulnessApi.Models;
using System.Text.Json;
using IO = System.IO;

namespace MindfulnessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenAi : ControllerBase
    {
        [HttpPost(Name = "GetMindfullnes")]
        public async Task<IActionResult> Post([FromBody] QuestionsRequest questions)
        {
            string questionsSerialized = JsonSerializer.Serialize(questions);

            string nonAzureOpenAIApiKey = "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";
            var client = new OpenAIClient(nonAzureOpenAIApiKey, new OpenAIClientOptions());
            var systemRoleText = IO.File.ReadAllText("system-role.txt");

            try
            {
                var chatCompletionsOptions = new ChatCompletionsOptions()
                {
                    DeploymentName = "gpt-3.5-turbo-0125",
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

                return Ok(responseMessage.Content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
