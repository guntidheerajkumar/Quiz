using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Quiz.PCL
{
	public class StudentService
	{
		public async Task AddStudent(SmartStudent student)
		{
			var client = new RestClient(Constants.AzureUrl);
			var input = new SmartStudentRequest();
			input.Input = JsonConvert.SerializeObject(student);
			var request = new RestRequest("JoinQuiz", Method.POST);
			request.AddHeader("Content-Type", "application/json");
			request.RequestFormat = DataFormat.Json;
			request.AddObject(input);
			await client.ExecuteTaskAsync(request);
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
