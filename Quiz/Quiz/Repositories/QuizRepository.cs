using System.Collections.Generic;
using System.Threading.Tasks;
using Quiz.Models;
using Quiz.Services;

namespace Quiz.Repository
{
	public class QuizRepository : IQuizRepository
	{
		public async Task<IList<SmartQuiz>> GetQuizDetails()
		{
			var serviceData = new QuizService();
			var data = await serviceData.GetQuizDetails();
			return (List<SmartQuiz>)data;
		}
	}
}
