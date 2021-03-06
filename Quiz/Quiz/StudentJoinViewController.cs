using System;
using BigTed;
using CoreGraphics;
using Foundation;
using Quiz.Models;
using Quiz.Repository;
using UIKit;

namespace Quiz
{
	public partial class StudentJoinViewController : UIViewController
	{
		UIImagePickerController imagePicker;
		public StudentJoinViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var tapGuestureRecognizer = new UITapGestureRecognizer(OnSelectImage);
			StudenImage.UserInteractionEnabled = true;
			StudenImage.AddGestureRecognizer(tapGuestureRecognizer);
			this.Title = "Smart Student - Join";
			LblSelectedTopic.Text = $"Selected Quiz Topic - {SelectedQuizTopic.TopicName}";


			JoinQuiz.TouchUpInside += async (sender, e) => {
				BTProgressHUD.Show(status: "Please wait \n\n Joining in to Quiz", maskType: ProgressHUD.MaskType.Black);
				SmartStudent student = new SmartStudent();
				student.StudentName = StudentNameField.Text;
				student.SchoolName = StudentSchoolField.Text;
				UIGraphics.BeginImageContext(new CGSize(320f, 240f));
				UIImage img = StudenImage.Image;
				img.Draw(new CGRect(0, 0, 320f, 240f));
				img = UIGraphics.GetImageFromCurrentImageContext();
				UIGraphics.EndImageContext();
				student.StudentImage = img.ToNSData();
				student.Age = Convert.ToInt32(StudentAgeField.Text);
				student.LogInDateTime = DateTime.Now;
				var joinRepository = new StudentRepository();
				var studentData = await joinRepository.AddStudent(student);
				if (studentData != null) {
					Constants.LoggedInStudent = studentData;
					BTProgressHUD.Dismiss();
					Constants.StudentId = studentData.StudentId;
					var participantsViewController = UIStoryboard.FromName("Main", null).InstantiateViewController("StudentCollectionViewController");
					NavigationController.PushViewController(participantsViewController, true);
				}
			};

			this.DataPlaceHodler.AddSubviews(StudentNameField, StudentSchoolField, StudentAgeField);
		}

		private void OnSelectImage()
		{
			imagePicker = new UIImagePickerController();
			imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
			imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
			imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
			imagePicker.Canceled += Handle_Canceled;
			NavigationController.PresentModalViewController(imagePicker, true);
		}

		protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			// determine what was selected, video or image
			bool isImage = false;
			switch (e.Info[UIImagePickerController.MediaType].ToString()) {
				case "public.image":
					isImage = true;
					break;
				case "public.video":
					break;
			}

			// get common info (shared between images and video)
			NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl;
			if (referenceURL != null)
				Console.WriteLine("Url:" + referenceURL.ToString());

			// if it was an image, get the other image info
			if (isImage) {
				// get the original image
				UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
				if (originalImage != null) {
					// do something with the image
					StudenImage.Image = originalImage; // display
				}
			} else { // if it's a video
					 // get video url
				NSUrl mediaURL = e.Info[UIImagePickerController.MediaURL] as NSUrl;
				if (mediaURL != null) {
					Console.WriteLine(mediaURL.ToString());
				}
			}
			// dismiss the picker
			imagePicker.DismissViewController(true, null);
		}

		void Handle_Canceled(object sender, EventArgs e)
		{
			imagePicker.DismissViewController(true, null);
		}
	}
}
