//
// QuestionnaireOptions.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
using SQLite;

namespace Quiz
{
	public class QuestionnaireOptions
	{
		[PrimaryKey, AutoIncrement]
		public int QuestionOptionId {
			get;
			set;
		}
		
		public string Options {
			get;
			set;
		}
		
		public bool IsCorrect {
			get;
			set;
		}
		
		public int QuestionnaireId {
			get;
			set;
		}
	}
}
