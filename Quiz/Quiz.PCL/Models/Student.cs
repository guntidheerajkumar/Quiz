//
// Student.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
namespace Quiz.PCL
{
	public class SmartStudent
	{
		public int StudentId { get; set; }
		public string StudentName { get; set; }
		public string SchoolName { get; set; }
		public int Age { get; set; }
		public DateTime LogInDateTime { get; set; }
		public byte[] StudentImage { get; set; }
	}
}
