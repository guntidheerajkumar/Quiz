//
// QuizService.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Quiz.PCL.Models;

namespace Quiz.PCL.Services
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
