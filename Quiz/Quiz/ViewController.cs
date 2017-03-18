//
// ViewController.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
using Foundation;
using CoreGraphics;
using System.Timers;
using UIKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz
{
	public partial class ViewController : UIViewController
	{
		//Questionnaire questionnaire;
		//List<QuestionnaireOptions> questionnaireOptions;
		private int duration = 0;

		protected ViewController(IntPtr handle) : base(handle)
		{

		}

		public override void ViewDidLoad()
		{
			//base.ViewDidLoad();
			//LblTimer.Text = string.Empty;
			//LblTimer.Layer.MasksToBounds = true;
			//LblTimer.Layer.CornerRadius = LblTimer.Frame.Width / 2;
			//var db = Constants.GetConnectionObject();
			//int QuestionnaireId = 1;
			//questionnaire = db.Table<Questionnaire>().Where(a => a.QuestionnaireId == QuestionnaireId).FirstOrDefault();
			//questionnaireOptions = db.Query<QuestionnaireOptions>($"select * from QuestionnaireOptions where QuestionnaireId = {questionnaire.QuestionnaireId}");
			//StartTimer();
			//BtnNextQuestion.TouchUpInside += (sender, e) => {
			//	StartTimer();
			//	QuestionnaireId += 1;
			//	questionnaire = db.Table<Questionnaire>().Where(a => a.QuestionnaireId == QuestionnaireId).FirstOrDefault();
			//	questionnaireOptions = db.Query<QuestionnaireOptions>($"select * from QuestionnaireOptions where QuestionnaireId = {questionnaire.QuestionnaireId}");
			//	QuestionTableView.Source = new QuestionTableSource(questionnaire, questionnaireOptions);
			//	QuestionTableView.ReloadData();
			//};

			//QuestionTableView.Source = new QuestionTableSource(questionnaire, questionnaireOptions);

			//QuestionTableView.TableFooterView = new UIView();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		private void UpdateDateTime()
		{
			if (duration != 60) {
				LblTimer.Text = duration.ToString("00");
				BtnNextQuestion.UserInteractionEnabled = false;
				QuestionTableView.UserInteractionEnabled = true;
				duration++;
			} else {
				duration = 0;
				BtnNextQuestion.UserInteractionEnabled = true;
				QuestionTableView.UserInteractionEnabled = false;
			}
		}

		private void StartTimer()
		{
			var timer = new Timer(1000);
			timer.Elapsed += (s, a) => InvokeOnMainThread(UpdateDateTime);
			timer.Start();
		}
	}



	//public class QuestionTableSource : UITableViewSource
	//{

	//Questionnaire questionnaire;
	//List<QuestionnaireOptions> questionnaireOptions;
	//string CellIdentifier = "TableCell";

	//public QuestionTableSource(Questionnaire items, List<QuestionnaireOptions> options)
	//{
	//	questionnaire = items;
	//	questionnaireOptions = options;
	//}

	//public override nint RowsInSection(UITableView tableview, nint section)
	//{
	//	return questionnaireOptions.Count;
	//}

	//public override string TitleForHeader(UITableView tableView, nint section)
	//{
	//	return $"({questionnaire.QuestionnaireId}) " + questionnaire.Question;
	//}

	//public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
	//{
	//	UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
	//	string item = questionnaireOptions[indexPath.Row].Options;
	//	if (cell == null) { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

	//	cell.TextLabel.Text = $"{indexPath.Row + 1 }) " + item;

	//	return cell;
	//}
	//}
}
