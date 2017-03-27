using System;

namespace Quiz
{
	public class SignlarResponse
	{
		public string Command { get; set; }
		public object Data { get; set; }
		public bool IsVoicePlay { get; set; }
		public string TextToSpeech { get; set; }
		public int Interval { get; set; }
	}
}
