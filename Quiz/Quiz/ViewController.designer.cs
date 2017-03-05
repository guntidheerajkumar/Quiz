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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton BtnNextQuestion { get; set; }

		[Outlet]
		UIKit.UILabel LblTimer { get; set; }

		[Outlet]
		UIKit.UITableView QuestionTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnNextQuestion != null) {
				BtnNextQuestion.Dispose ();
				BtnNextQuestion = null;
			}

			if (LblTimer != null) {
				LblTimer.Dispose ();
				LblTimer = null;
			}

			if (QuestionTableView != null) {
				QuestionTableView.Dispose ();
				QuestionTableView = null;
			}
		}
	}
}
