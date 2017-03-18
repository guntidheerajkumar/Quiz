//
// QuizRepository.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quiz.PCL.Models;
using Quiz.PCL.Interfaces;
using Quiz.PCL.Services;

namespace Quiz.PCL.Repository
{
	public class QuizRepository : IQuizRepository
	{
		public async Task<IList<SmartQuiz>> GetQuizDetails()
		{
			var serviceData = new QuizService();
			var data = await serviceData.GetQuizDetails();
			return (List<SmartQuiz>)data;
		}
	}
}
