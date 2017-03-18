﻿//
// Constants.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
using Foundation;
using UIKit;

namespace Quiz
{
	public class Constants
	{
		public static string AzureUrl = "http://ismartstudent.azurewebsites.net/api/";
	}

	public static class Extensions
	{

		public static byte[] ToNSData(this UIImage image)
		{

			if (image == null) {
				return null;
			}
			NSData data = null;

			try {
				data = image.AsPNG();
				return data.ToArray();
			} catch (Exception) {
				return null;
			} finally {
				if (image != null) {
					image.Dispose();
					image = null;
				}
				if (data != null) {
					data.Dispose();
					data = null;
				}
			}
		}

		public static UIImage ToImage(this byte[] data)
		{
			if (data == null) {
				return null;
			}
			UIImage image = null;
			try {

				image = new UIImage(NSData.FromArray(data));
				data = null;
			} catch (Exception) {
				return null;
			}
			return image;
		}
	}
}
