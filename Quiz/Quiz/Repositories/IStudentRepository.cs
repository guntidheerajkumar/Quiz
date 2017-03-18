using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.PCL
{
	public interface IStudentRepository
	{
		Task AddStudent(SmartStudent student);

		Task<List<SmartStudent>> GetStudents();
	}
}
