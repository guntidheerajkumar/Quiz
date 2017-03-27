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
	[Register ("QuizViewController")]
	partial class QuizViewController
	{
		[Outlet]
		UIKit.UILabel LblTimeRemaining { get; set; }

		[Outlet]
		UIKit.UITableView ParticipantsTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LblTimeRemaining != null) {
				LblTimeRemaining.Dispose ();
				LblTimeRemaining = null;
			}

			if (ParticipantsTableView != null) {
				ParticipantsTableView.Dispose ();
				ParticipantsTableView = null;
			}
		}
	}
}
