using System;
using System.Collections.Generic;

namespace Quiz
{
	public class EventTable
	{
		public bool IsFakeClient { get; set; }
		public int EventId { get; set; }
		public string Title { get; set; }
		public string Command { get; set; }
		public int StudentId { get; set; }
		public int Round { get; set; }
		public bool Completed { get; set; }
		public int StudentChoice { get; set; }
		public int Score { get; set; }
		public int Duration { get; set; }
		public Question Question { get; set; }
		public List<string> TextToSpeech { get; set; }
		public bool Answered { get; set; }
		public bool IsCorrect { get; set; }
		public int CorrectChoice { get; set; }
		public string TimeUpMessage { get; set; }
	}
}
