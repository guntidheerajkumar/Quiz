using System;
namespace Quiz
{
	public class BuzzerLog
	{
		public int StudentId { get; set; }
		public string StudentName { get; set; }
		public int Duration { get; set; }
		public bool Response { get; set; }
		public bool BuzzerRequested { get; set; }
	}
}
