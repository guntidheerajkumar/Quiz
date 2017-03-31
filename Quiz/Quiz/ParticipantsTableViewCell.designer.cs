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
	[Register ("ParticipantsTableViewCell")]
	partial class ParticipantsTableViewCell
	{
		[Outlet]
		UIKit.UILabel LblStudentName { get; set; }

		[Outlet]
		UIKit.UILabel LblStudentSchool { get; set; }

		[Outlet]
		UIKit.UIImageView StudentImage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (StudentImage != null) {
				StudentImage.Dispose ();
				StudentImage = null;
			}

			if (LblStudentName != null) {
				LblStudentName.Dispose ();
				LblStudentName = null;
			}

			if (LblStudentSchool != null) {
				LblStudentSchool.Dispose ();
				LblStudentSchool = null;
			}
		}
	}
}
