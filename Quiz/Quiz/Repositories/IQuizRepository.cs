//
// IQuizRepository.cs
//
// Author: Dheeraj Kumar Gunti <guntidheerajkumar@gmail.com>
//
// Copyright (c) 2017 (c) Dheeraj Kumar Gunti
//
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quiz.PCL.Models;

namespace Quiz.PCL.Interfaces
{
	public interface IQuizRepository
	{
		Task<IList<SmartQuiz>> GetQuizDetails();
	}
}
