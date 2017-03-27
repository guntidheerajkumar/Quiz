using System;
using System.Collections.Generic;
using Foundation;
using System.Threading.Tasks;
using UIKit;
using Quiz.Repository;
using BigTed;

namespace Quiz
{
	public partial class QuizIntervalViewController : UIViewController
	{
		private List<SmartStudent> students;
		public QuizIntervalViewController(IntPtr handle) : base(handle)
		{
		}

		public async override void ViewDidLoad()
		{
			base.ViewDidLoad();
			students = new List<SmartStudent>();
			var joinRepository = new StudentRepository();
			students = await joinRepository.GetStudents();
			QuizParticipantsTableView.Source = new QuizParticipantsTableSource(students);
			QuizParticipantsTableView.ReloadData();

			QuizParticipantsTableView.TableFooterView = new UIView();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			AppDelegate.signal.StudentResponseReceived += (sender, e) => {
				var response = (SignalrResponse)e;
				this.InvokeOnMainThread(() => {
					if (e.Command == "QuizReadyToStart") {
						this.InvokeOnMainThread(() => {
							Generic.TextToSpeech(response.TextToSpeech);
							foreach (var item in students) {
								Generic.TextToSpeech($"{item.StudentName} from {item.SchoolName}");
							}
						});
					}
				});
			};

			BtnLetsStart.Layer.CornerRadius = BtnLetsStart.Frame.Width / 2;
		}
	}

	public class QuizParticipantsTableSource : UITableViewSource
	{

		List<SmartStudent> listStudents;
		string CellIdentifier = "TableCell";

		public QuizParticipantsTableSource(List<SmartStudent> items)
		{
			listStudents = items;
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 60;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return listStudents.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			SmartStudent item = listStudents[indexPath.Row];
			if (cell == null) { cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier); }

			cell.TextLabel.Text = item.StudentName;
			cell.DetailTextLabel.Text = item.SchoolName;
			cell.ImageView.Image = item.StudentImage.ToImage();
			var frame = cell.ImageView.Frame;
			frame.Height = 60;
			frame.Width = 60;
			cell.ImageView.Frame = frame;
			cell.BackgroundColor = UIColor.Clear;
			cell.TextLabel.Font = UIFont.FromName("HelveticaNeue-Thin", 24f);
			cell.DetailTextLabel.Font = UIFont.FromName("HelveticaNeue-Thin", 16f);
			cell.TextLabel.TextColor = UIColor.FromRGB(245, 127, 90);
			cell.DetailTextLabel.TextColor = UIColor.FromRGB(64, 163, 166);
			return cell;
		}
	}
}
