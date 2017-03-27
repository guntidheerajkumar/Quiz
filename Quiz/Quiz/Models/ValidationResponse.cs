using System;
using System.Collections.Generic;

namespace Quiz
{
	public class ValidationResponse
	{
		public List<string> TextToSpeech { get; set; }
		public List<ScoreBoard> ScoreBoard { get; set; }
	}
}
