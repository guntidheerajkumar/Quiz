//
// Questionnaire.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
using SQLite;

namespace Quiz
{
	public class Questionnaire
	{
		[PrimaryKey, AutoIncrement]
		public int QuestionnaireId {
			get;
			set;
		}

		public string Question {
			get;
			set;
		}
	}
}
