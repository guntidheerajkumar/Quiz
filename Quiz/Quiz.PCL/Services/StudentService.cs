using System;
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
			var request = new RestRequest("JoinQuiz", Method.POST);
			request.AddHeader("Content-Type", "application/json");
			request.RequestFormat = DataFormat.Json;
			request.AddObject(student);
			await client.ExecuteTaskAsync(request);
		}
	}
}
