//
// Constants.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
using System.IO;
using SQLite;

namespace Quiz
{
	public class Constants
	{
		public static string GetDbConnection()
		{
			string fileName = "Quiz.db3";
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

			if (!Directory.Exists(libFolder)) {
				Directory.CreateDirectory(libFolder);
			}

			return Path.Combine(libFolder, fileName);
		}

		public static SQLiteConnection GetConnectionObject()
		{
			var db = new SQLiteConnection(Constants.GetDbConnection());
			return db;
		}
	}
}
