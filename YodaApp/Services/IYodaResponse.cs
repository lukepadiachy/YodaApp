using Azure.AI.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodaApp.Services
{
    public interface IYodaResponse
    {
        Task<ChatMessage> GetCompletion();
    }
}
