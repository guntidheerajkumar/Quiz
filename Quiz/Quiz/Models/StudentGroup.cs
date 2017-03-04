//
// StudentGroup.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
using SQLite;

namespace Quiz
{
	public class StudentGroup
	{
		[PrimaryKey, AutoIncrement]
		 public int StudentGroupId {
			get;
			set;
		}
		
		public string GroupName {
			get;
			set;
		}
		
		public int StudentId {
			get;
			set;
		}
	}
}
