using System.Threading.Tasks;

namespace ChatGPTInput.Interfaces
{
	public interface IConversationBl
	{
		Task<string> Answer(string question);
	}
}
