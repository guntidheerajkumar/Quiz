using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Quiz.Models;

namespace Quiz.Services
{
	public class QuizService
	{
		public async Task<IEnumerable<SmartQuiz>> GetQuizDetails()
		{
			var client = new RestClient(Constants.AzureUrl);
			var request = new RestRequest("Quiz", Method.GET);
			var response = await client.ExecuteTaskAsync(request);
			var quizResult = JsonConvert.DeserializeObject<List<SmartQuiz>>(response.Content);
			return quizResult;
		}

		//public async Task<IEnumerable<SmartQuiz>> ReadyForQuiz()
		//{
		//	var client = new RestClient(Constants.AzureUrl);
		//	var input = new SmartStudentRequest();
		//	var request = new RestRequest("QuizCommands", Method.POST);
		//	input.Input = JsonConvert.SerializeObject(new QuizCommandRequest());
		//	request.AddHeader("Content-Type", "application/json");
		//	request.RequestFormat = DataFormat.Json;
		//	request.AddObject(input);
		//	return;
		//}
	}
}
