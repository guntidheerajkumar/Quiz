﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace Quiz.Listeners
{
	public class QuizListener
	{
		private const string Url = "http://ismartstudent.azurewebsites.net/";
		private HubConnection _connection;
		private IHubProxy _proxy;

		public event EventHandler<SignalrResponse> StudentResponseReceived;

		public async Task StartListening()
		{
			_connection = new HubConnection(Url);
			_proxy = _connection.CreateHubProxy("SmartStudentHub");

			_proxy.On<SignalrResponse>("StudentResponseCommand", quizdata => {
				if (StudentResponseReceived != null)
					StudentResponseReceived.Invoke(this, quizdata);
			});

			await _connection.Start();
		}
	}
}
