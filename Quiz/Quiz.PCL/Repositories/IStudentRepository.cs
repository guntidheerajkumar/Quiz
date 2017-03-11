using System;
using System.Threading.Tasks;

namespace Quiz.PCL
{
	public interface IStudentRepository
	{
		Task AddStudent(SmartStudent student);
	}
}
