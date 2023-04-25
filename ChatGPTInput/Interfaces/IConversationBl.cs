using System.Threading.Tasks;

namespace ChatGPTInput.Interfaces
{
	public interface IConversationBl
	{
		Task<string> Ask(string question);
	}
}
