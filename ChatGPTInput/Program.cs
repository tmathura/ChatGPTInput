using ChatGPTInput.Implementations;
using ChatGPTInput.Interfaces;
using ChatGPTInput.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI_API;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace ChatGPTInput
{
	internal class Program
	{
		private static async Task Main(string[] args)
		{

			var repository = log4net.LogManager.GetRepository(Assembly.GetEntryAssembly());
			var fileInfo = new FileInfo(@"log4net.config");
			log4net.Config.XmlConfigurator.Configure(repository, fileInfo);

			var settings = new Settings();
			var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			configuration.Bind(settings);

			var serviceProvider = new ServiceCollection()
				.AddSingleton<IConversationBl, ConversationBl>(_ => new ConversationBl(new OpenAIAPI(settings.ApiKey)))
				.BuildServiceProvider();

			var conversationBl = serviceProvider.GetService<IConversationBl>();

			Console.WriteLine("Please ask me a question.");

			while (true)
			{
				var question = Console.ReadLine();

				var answer = await conversationBl.Answer(question);

				Console.WriteLine(answer);
			}
		}
	}
}
