using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Quiz.Services
{
	public class StudentService
	{
		public async Task<SmartStudent> AddStudent(SmartStudent student)
		{
			var client = new RestClient(Constants.AzureUrl);
			var input = new SmartStudentRequest();
			input.Input = JsonConvert.SerializeObject(student);
			var request = new RestRequest("JoinQuiz", Method.POST);
			request.AddHeader("Content-Type", "application/json");
			request.RequestFormat = DataFormat.Json;
			request.AddObject(input);
			var response = await client.ExecuteTaskAsync(request);
			var studentData = JsonConvert.DeserializeObject<SmartStudent>(response.Content);
			return studentData;
		}

		public async Task<List<SmartStudent>> GetStudents()
		{
			var client = new RestClient(Constants.AzureUrl);
			var request = new RestRequest("QuizBoardMembers", Method.GET);
			var response = await client.ExecuteTaskAsync(request);
			var quizResult = JsonConvert.DeserializeObject<List<SmartStudent>>(response.Content);
			return quizResult;
		}
	}
}
