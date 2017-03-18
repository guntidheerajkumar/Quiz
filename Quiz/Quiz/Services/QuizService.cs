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
	}
}
