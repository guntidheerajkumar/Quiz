using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using Quiz.Listeners;
using Quiz.Repository;
using UIKit;

namespace Quiz
{
	public partial class StudentCollectionViewController : UICollectionViewController
	{
		static NSString studentCellId = new NSString("CollectionCell");
		List<SmartStudent> students;
		private QuizListener signal = new QuizListener();
		public StudentCollectionViewController(IntPtr handle) : base(handle)
		{
		}

		public async override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.CollectionView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("Page_background.jpg"));
			this.Title = "Welcome to Smart Student";
			this.NavigationItem.HidesBackButton = true;
			await signal.StartListening();
		}

		public async override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			students = new List<SmartStudent>();
			this.Title = "Students";
			this.View.BackgroundColor = UIColor.White;
			var joinRepository = new StudentRepository();
			students = await joinRepository.GetStudents();
			CollectionView.ReloadData();
			CollectionView.Frame = new CGRect(0, 0, this.View.Frame.Width, CollectionView.Frame.Height);
			CollectionView.RegisterClassForCell(typeof(CollectionCell), studentCellId);
			signal.StudentResponseReceived += (sender, e) => {
				this.InvokeOnMainThread(() => {
					if (e.Command == "BoardingTime") {
						this.InvokeOnMainThread(() => {
							var response = (SignalrResponse)e;
							this.Title = $"Time Remaining : {response.Data.ToString()}";
						});
					} else if (e.Command == "BoardingStudents") {
						this.InvokeOnMainThread(async () => {
							students = await joinRepository.GetStudents();
							CollectionView.ReloadData();
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

		//public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
		//{
		//	var cell = collectionView.CellForItem(indexPath);
		//	cell.ContentView.BackgroundColor = UIColor.Yellow;
		//}

		//public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
		//{
		//	var cell = collectionView.CellForItem(indexPath);
		//	cell.ContentView.BackgroundColor = UIColor.White;
		//}

		//public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
		//{
		//	return false;
		//}
	}

	public class CollectionCell : UICollectionViewCell
	{
		UIImageView imageView;
		UILabel titleLabel;

		[Export("initWithFrame:")]
		public CollectionCell(CGRect frame) : base(frame)
		{
			ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
			ContentView.Layer.BorderWidth = 1.0f;
			ContentView.BackgroundColor = UIColor.Clear;
			//ContentView.Frame = new CGRect(0, 0, 200, 200);

			imageView = new UIImageView();
			imageView.Frame = new CGRect(0, 0, 150, 150);

			titleLabel = new UILabel();
			titleLabel.Frame = new CGRect(0, imageView.Frame.Height + 5, 150, 30);
			titleLabel.TextAlignment = UITextAlignment.Center;
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
