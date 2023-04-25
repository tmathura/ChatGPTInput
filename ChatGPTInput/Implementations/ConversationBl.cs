using ChatGPTInput.Interfaces;
using log4net;
using OpenAI_API;
using System;
using System.Threading.Tasks;

namespace ChatGPTInput.Implementations
{
	public class ConversationBl : IConversationBl
	{
		private readonly IOpenAIAPI _openAIAPI;
		private readonly ILog _logger = LogManager.GetLogger(typeof(ConversationBl));

		public ConversationBl(IOpenAIAPI openAIAPI)
		{
			_openAIAPI = openAIAPI;
		}

		public async Task<string> Ask(string question)
		{
			string answer = null;

			try
			{
				var chat = _openAIAPI.Chat.CreateConversation();
				chat.AppendUserInput(question);

				answer = await chat.GetResponseFromChatbotAsync();

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				_logger.Warn(e);
			}

			return answer;
		}
	}
}
