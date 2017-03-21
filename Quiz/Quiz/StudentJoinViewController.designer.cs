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
		UIKit.UIButton JoinQuiz { get; set; }

		[Outlet]
		UIKit.UIImageView StudenImage { get; set; }

		[Outlet]
		UIKit.UITextField StudentAgeField { get; set; }

		[Outlet]
		UIKit.UITextField StudentNameField { get; set; }

		[Outlet]
		UIKit.UITextField StudentSchoolField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (JoinQuiz != null) {
				JoinQuiz.Dispose ();
				JoinQuiz = null;
			}

			if (StudenImage != null) {
				StudenImage.Dispose ();
				StudenImage = null;
			}

			if (StudentAgeField != null) {
				StudentAgeField.Dispose ();
				StudentAgeField = null;
			}

			if (StudentNameField != null) {
				StudentNameField.Dispose ();
				StudentNameField = null;
			}

			if (StudentSchoolField != null) {
				StudentSchoolField.Dispose ();
				StudentSchoolField = null;
			}
		}
	}
}
