//
// ViewController.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;

using UIKit;

namespace Quiz
{
	public partial class ViewController : UIViewController
	{
		
		protected ViewController(IntPtr handle) : base(handle)
		{
			
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var db = Constants.GetConnectionObject();
			var d = db.Table<Student>().Where(a => a.StudentId == 1).FirstOrDefault();
			StudentImage.Image = UIImage.FromBundle(d.StudentImage);
			StudentName.Text = d.StudentName;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
