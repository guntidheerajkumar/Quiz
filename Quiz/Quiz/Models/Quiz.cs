//
// Quiz.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;

namespace Quiz.Models
{
	public class SmartQuiz
	{
		public int QuizId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}

	public class SelectedQuizTopic
	{
		public static string TopicName { get; set; }
	}
}
