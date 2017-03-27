using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using Quiz.Repository;
using UIKit;
using AVFoundation;
using BigTed;

namespace Quiz
{
	public partial class StudentCollectionViewController : UICollectionViewController
	{
		static NSString studentCellId = new NSString("CollectionCell");

		List<SmartStudent> students;
		private int studentCount { get; set; } = 0;

		public StudentCollectionViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.CollectionView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("Page_background.jpg"));
			this.NavigationItem.HidesBackButton = true;
		}

		public async override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			BTProgressHUD.Show(status: "Please wait \n\n Loading Quiz Participants", maskType: ProgressHUD.MaskType.Black);
			students = new List<SmartStudent>();
			this.View.BackgroundColor = UIColor.White;
			var joinRepository = new StudentRepository();
			students = await joinRepository.GetStudents();
			CollectionView.ReloadData();
			BTProgressHUD.Dismiss();
			CollectionView.Frame = new CGRect(0, 0, this.View.Frame.Width, CollectionView.Frame.Height);
			CollectionView.RegisterClassForCell(typeof(CollectionCell), studentCellId);
			Generic.TextToSpeech($"Welcome to Smart Student Quiz, we have {students.Count} boarded right now.");
			AppDelegate.signal.StudentResponseReceived += (sender, e) => {
				this.InvokeOnMainThread(() => {
					var response = (SignalrResponse)e;
					if (e.Command == "BoardingStudents") {
						this.InvokeOnMainThread(async () => {
							students = await joinRepository.GetStudents();
							CollectionView.ReloadData();
							BTProgressHUD.Show(response.TextToSpeech, maskType: ProgressHUD.MaskType.Black);
							Generic.TextToSpeech(response.TextToSpeech);

						});
					}
					if (e.Command == "QuizReadyToStart") {
						this.InvokeOnMainThread(() => {
							this.Title = "Quiz Start";
							BTProgressHUD.Dismiss();
							Generic.TextToSpeech($"Quiz is going to start with {students.Count} students");
							Generic.speechSynthesizer.DidFinishSpeechUtterance += (s, ee) => {
								var quizIntervalViewController = UIStoryboard.FromName("Main", null).InstantiateViewController("QuizIntervalViewController");
								NavigationController.PushViewController(quizIntervalViewController, true);
							};
						});
					}
				});
			};
		}


		public override nint NumberOfSections(UICollectionView collectionView)
		{
			return 1;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return students.Count;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var studentCell = (CollectionCell)collectionView.DequeueReusableCell(studentCellId, indexPath);
			var student = students[indexPath.Row];
			studentCell.Image = student.StudentImage.ToImage();
			studentCell.TitleLabel = student.StudentName;
			return studentCell;
		}
	}

	public class CollectionCell : UICollectionViewCell
	{
		UIImageView imageView;
		UILabel titleLabel;

		[Export("initWithFrame:")]
		public CollectionCell(CGRect frame) : base(frame)
		{
			ContentView.BackgroundColor = UIColor.Clear;

			imageView = new UIImageView();
			imageView.Frame = new CGRect(0, 0, 200, 200);

			titleLabel = new UILabel();
			titleLabel.Frame = new CGRect(0, imageView.Frame.Height + 5, 200, 50);
			titleLabel.TextAlignment = UITextAlignment.Center;
			titleLabel.Lines = 0;
			titleLabel.Font = UIFont.FromName("HelveticaNeue-Thin", 18f);
			titleLabel.TextColor = UIColor.White;

			ContentView.AddSubview(titleLabel);
			ContentView.AddSubview(imageView);
		}

		public UIImage Image {
			set {
				imageView.Image = value;
			}
		}

		public string TitleLabel {
			set {
				titleLabel.Text = value;
			}
		}
	}
}
