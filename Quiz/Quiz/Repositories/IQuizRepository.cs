using System.Collections.Generic;
using System.Threading.Tasks;
using Quiz.Models;

namespace Quiz.Repository
{
	public interface IQuizRepository
	{
		Task<IList<SmartQuiz>> GetQuizDetails();
	}
}
