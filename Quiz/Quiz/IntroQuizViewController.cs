using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BigTed;
using Foundation;
using Quiz.Listeners;
using Quiz.Models;
using Quiz.Repository;
using UIKit;

namespace Quiz
{
	public partial class IntroQuizViewController : UIViewController
	{

		public IntroQuizViewController(IntPtr handle) : base(handle)
		{

		}

		public async override void ViewDidLoad()
		{
			base.ViewDidLoad();
			BTProgressHUD.Show(status: "Please wait.. Loading Quiz Topics", maskType: ProgressHUD.MaskType.Black);
			var source = new SmartQuizTableSource(await GetQuizInfo());
			source.NavigationController = this.NavigationController;
			QuizTableView.Source = source;
			QuizTableView.SeparatorColor = UIColor.White;
			QuizTableView.ReloadData();
			QuizTableView.TableFooterView = new UIView();
			this.Title = "Quiz Topics";
			BTProgressHUD.Dismiss();
			await AppDelegate.signal.StartListening();
		}

		private async Task<List<SmartQuiz>> GetQuizInfo()
		{
			IQuizRepository quizRepository = new QuizRepository();
			var data = await quizRepository.GetQuizDetails();
			return (List<SmartQuiz>)data;
		}
	}

	public class SmartQuizTableSource : UITableViewSource
	{

		List<SmartQuiz> TableItems;
		string CellIdentifier = "TableCell";
		public UINavigationController NavigationController;

		public SmartQuizTableSource(List<SmartQuiz> items)
		{
			TableItems = items;
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 60;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			SmartQuiz item = TableItems[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null) { cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier); }

			cell.TextLabel.Text = item.Name;
			cell.DetailTextLabel.Text = item.Description;

			cell.BackgroundColor = UIColor.Clear;
			cell.TextLabel.Font = UIFont.BoldSystemFontOfSize(24f);
			cell.DetailTextLabel.Font = UIFont.SystemFontOfSize(18f);

			cell.TextLabel.TextColor = UIColor.FromRGB(245, 127, 90);
			cell.DetailTextLabel.TextColor = UIColor.FromRGB(64, 163, 166);

			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, false);
			SelectedQuizTopic.TopicName = TableItems[indexPath.Row].Name;
			var studentJoinViewController = UIStoryboard.FromName("Main", null).InstantiateViewController("StudentJoinViewController");
			NavigationController.PushViewController(studentJoinViewController, true);
		}
	}
}
