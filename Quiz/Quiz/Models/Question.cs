using System;
using System.Collections.Generic;

namespace Quiz
{
	public class Question
	{
		public int QuestionId { get; set; }
		public string Description { get; set; }
		public List<Options> Options { get; set; }
	}

	public class Options
	{
		public int OptionId { get; set; }
		public string Description { get; set; }
		public bool IsCorrect { get; set; }
	}
}
