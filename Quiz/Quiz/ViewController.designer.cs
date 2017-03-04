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
		UIKit.UIImageView StudentImage { get; set; }

		[Outlet]
		UIKit.UILabel StudentName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (StudentImage != null) {
				StudentImage.Dispose ();
				StudentImage = null;
			}

			if (StudentName != null) {
				StudentName.Dispose ();
				StudentName = null;
			}
		}
	}
}
