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
	[Register ("ParticipantTableViewCell")]
	partial class ParticipantTableViewCell
	{
		[Outlet]
		UIKit.UILabel LblParticipantName { get; set; }

		[Outlet]
		UIKit.UILabel LblPoints { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LblParticipantName != null) {
				LblParticipantName.Dispose ();
				LblParticipantName = null;
			}

			if (LblPoints != null) {
				LblPoints.Dispose ();
				LblPoints = null;
			}
		}
	}
}
