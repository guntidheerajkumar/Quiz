//
// InitialSetupData.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
using SQLite;

namespace Quiz
{
	public class InitialSetupData
	{
		public static void SetupData()
		{
			var db = new SQLiteConnection(Constants.GetDbConnection());
			db.DropTable<Student>();
			db.DropTable<StudentGroup>();
			db.DropTable<Questionnaire>();
			db.DropTable<QuestionnaireOptions>();
			
			db.CreateTable<Student>();
			db.CreateTable<StudentGroup>();
			db.CreateTable<Questionnaire>();
			db.CreateTable<QuestionnaireOptions>();
			
			InitialSetupData.EnterSeedData(db);
		}

		private static void EnterSeedData(SQLiteConnection db)
		{
			//Students
			db.Insert(new Student() { StudentName = "Robert", StudentImage = "placeholder" });
			db.Insert(new Student() { StudentName = "Philip", StudentImage = "placeholder" });
			db.Insert(new Student() { StudentName = "Patrick", StudentImage = "placeholder" });
			db.Insert(new Student() { StudentName = "Ted Brown", StudentImage = "placeholder" });
			db.Insert(new Student() { StudentName = "Maria Hong", StudentImage = "placeholder" });
			db.Insert(new Student() { StudentName = "Martina Hofstee", StudentImage = "placeholder" });
			//Student Group
			string groupName = "First Group";
			db.Insert(new StudentGroup() { GroupName = groupName, StudentId = 1 });
			db.Insert(new StudentGroup() { GroupName = groupName, StudentId = 3 });
			db.Insert(new StudentGroup() { GroupName = groupName, StudentId = 5 });

			groupName = "Second Group";
			db.Insert(new StudentGroup() { GroupName = groupName, StudentId = 2 });
			db.Insert(new StudentGroup() { GroupName = groupName, StudentId = 4 });
			db.Insert(new StudentGroup() { GroupName = groupName, StudentId = 6 });

			//Questionnaire
			db.Insert(new Questionnaire() { Question = "What is the capital of Turkey?" });
			db.Insert(new Questionnaire() { Question = "How many continents are there?" });
			db.Insert(new Questionnaire() { Question = "What is the longest river in Europe?" });
			db.Insert(new Questionnaire() { Question = "What is the largest city in Canada?" });
			db.Insert(new Questionnaire() { Question = "What is the capital city of Australia ?" });

			//Questionnarie Options
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 1, Options = "Ankara", IsCorrect = true });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 1, Options = "Sonora", IsCorrect = false });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 1, Options = "Sahara", IsCorrect = false });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 1, Options = "Siberia", IsCorrect = false });
			
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 2, Options = "Five", IsCorrect = false });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 2, Options = "Seven", IsCorrect = true });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 2, Options = "Four", IsCorrect = false });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 2, Options = "Ten", IsCorrect = false });
			
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 3, Options = "Wolga river", IsCorrect = true });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 3, Options = "Nippon river", IsCorrect = false });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 3, Options = "Honolulu river", IsCorrect = false });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 3, Options = "Donau river", IsCorrect = false });
			
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 4, Options = "Sicilyr", IsCorrect = false });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 4, Options = "Ottawa", IsCorrect = false });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 4, Options = "Toronto", IsCorrect = true });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 4, Options = "Giant panda", IsCorrect = false });
			
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 5, Options = "Sydney", IsCorrect = false });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 5, Options = "Canberra", IsCorrect = true });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 5, Options = "Melbourne", IsCorrect = false });
			db.Insert(new QuestionnaireOptions() { QuestionnaireId = 5, Options = "Perth", IsCorrect = false });
		}
	}
}
