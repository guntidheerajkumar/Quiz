//
// Student.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
using SQLite;

namespace Quiz
{
	public class Student
	{
		[PrimaryKey, AutoIncrement]
		 public int StudentId {
			get;
			set;
		}
		
		public string StudentName {
			get;
			set;
		}
		
		public string StudentImage {
			get;
			set;
		}
	}
}
