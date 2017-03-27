using System;
namespace Quiz
{
	public class QuizCommandRequest
	{
		public int StudentId { get; set; }
		public string Command { get; set; }
		public EventTable Data { get; set; }
		public int Duration { get; set; }
		public bool BuzzerRequested { get; set; }
	}
}
