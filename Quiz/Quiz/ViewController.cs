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
using UIKit;
using System.Collections.Generic;

namespace Quiz
{
	public partial class ViewController : UIViewController
	{
		Questionnaire questionnaire;
		List<QuestionnaireOptions> questionnaireOptions;

		protected ViewController(IntPtr handle) : base(handle)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var db = Constants.GetConnectionObject();
			int QuestionnaireId = 1;
			questionnaire = db.Table<Questionnaire>().Where(a => a.QuestionnaireId == QuestionnaireId).FirstOrDefault();
			questionnaireOptions = db.Query<QuestionnaireOptions>($"select * from QuestionnaireOptions where QuestionnaireId = {questionnaire.QuestionnaireId}");

			BtnNextQuestion.TouchUpInside += (sender, e) => {
				QuestionnaireId += 1;
				questionnaire = db.Table<Questionnaire>().Where(a => a.QuestionnaireId == QuestionnaireId).FirstOrDefault();
				questionnaireOptions = db.Query<QuestionnaireOptions>($"select * from QuestionnaireOptions where QuestionnaireId = {questionnaire.QuestionnaireId}");
				QuestionTableView.Source = new QuestionTableSource(questionnaire, questionnaireOptions);
				QuestionTableView.ReloadData();
			};

			QuestionTableView.Source = new QuestionTableSource(questionnaire, questionnaireOptions);

			QuestionTableView.TableFooterView = new UIView();
		}
	}

	public class QuestionTableSource : UITableViewSource
	{

		Questionnaire questionnaire;
		List<QuestionnaireOptions> questionnaireOptions;
		string CellIdentifier = "TableCell";

		public QuestionTableSource(Questionnaire items, List<QuestionnaireOptions> options)
		{
			questionnaire = items;
			questionnaireOptions = options;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return questionnaireOptions.Count;
		}

		public override string TitleForHeader(UITableView tableView, nint section)
		{
			return $"({questionnaire.QuestionnaireId}) " + questionnaire.Question;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			string item = questionnaireOptions[indexPath.Row].Options;
			if (cell == null) { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

			cell.TextLabel.Text = $"{indexPath.Row + 1 }) " + item;

			return cell;
		}
	}
}
