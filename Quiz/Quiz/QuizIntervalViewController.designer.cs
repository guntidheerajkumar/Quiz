// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Quiz
{
	[Register ("QuizIntervalViewController")]
	partial class QuizIntervalViewController
	{
		[Outlet]
		UIKit.UIButton BtnLetsStart { get; set; }

		[Outlet]
		UIKit.UITextView LblQuizRules { get; set; }

		[Outlet]
		UIKit.UITableView QuizParticipantsTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LblQuizRules != null) {
				LblQuizRules.Dispose ();
				LblQuizRules = null;
			}

			if (QuizParticipantsTableView != null) {
				QuizParticipantsTableView.Dispose ();
				QuizParticipantsTableView = null;
			}

			if (BtnLetsStart != null) {
				BtnLetsStart.Dispose ();
				BtnLetsStart = null;
			}
		}
	}
}
