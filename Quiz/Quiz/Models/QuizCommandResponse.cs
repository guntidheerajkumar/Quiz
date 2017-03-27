using System;
using System.Collections.Generic;

namespace Quiz
{
	public class QuizCommandResponse
	{
		public string Command { get; set; }
		public EventTable Data { get; set; }
		public bool IsLastQuestion { get; set; }
		public List<ScoreBoard> ScoreBoard { get; set; }
		public List<string> TextToSpeech { get; set; }
		public int BuzzerOwnedBy { get; set; }
		public string BuzzerOwnByName { get; set; }
	}
}
