using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;
using YodaApp.Model;
using YodaApp.Configuration;


namespace YodaApp.Services
{

    
        public class YodaResponse : IYodaResponse
        {
            private ISettings _settings;
            private const string YodaBehaviorDescription = "You are Yoda from Stars who provides fun facts. you have his personality aswell. ";

            public YodaResponse(ISettings settings)
            {
                _settings = settings;
            }

            //Link it here  
            public async Task<ChatMessage> GetCompletion()
            {

                try
                {
                    var client = new OpenAIClient(new Uri(_settings.AzureOpenAiEndPoint), new AzureKeyCredential(_settings.AzureOpenAiKey));
                    string deploymentName = "gpt35turbo16";
                    string funfact = "Give a fun fact";

                    var chatCompletionsOptions = new ChatCompletionsOptions()
                    {
                        Messages =
                       {
                           new ChatMessage(ChatRole.System,YodaBehaviorDescription),
                           new ChatMessage(ChatRole.User,funfact)
                       }
                    };

                    Response<ChatCompletions> response = await client.GetChatCompletionsAsync(deploymentName, chatCompletionsOptions);
                    ChatMessage responseMessage = response.Value.Choices[0].Message;

                    return responseMessage;

                }
                catch (Exception ex)
                {

                }

                return null;
            }
        }
    
}
