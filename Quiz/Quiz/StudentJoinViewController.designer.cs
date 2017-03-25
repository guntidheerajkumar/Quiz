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
	[Register ("StudentJoinViewController")]
	partial class StudentJoinViewController
	{
		[Outlet]
		UIKit.UIView DataPlaceHodler { get; set; }

		[Outlet]
		UIKit.UIButton JoinQuiz { get; set; }

		[Outlet]
		UIKit.UILabel LblSelectedTopic { get; set; }

		[Outlet]
		UIKit.UIImageView StudenImage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DataPlaceHodler != null) {
				DataPlaceHodler.Dispose ();
				DataPlaceHodler = null;
			}

			if (JoinQuiz != null) {
				JoinQuiz.Dispose ();
				JoinQuiz = null;
			}

			if (StudenImage != null) {
				StudenImage.Dispose ();
				StudenImage = null;
			}

			if (LblSelectedTopic != null) {
				LblSelectedTopic.Dispose ();
				LblSelectedTopic = null;
			}
		}
	}
}
