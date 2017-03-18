using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.PCL
{
	public class StudentRepository : IStudentRepository
	{
		public async Task AddStudent(SmartStudent student)
		{
			var serviceData = new StudentService();
			await serviceData.AddStudent(student);
		}

		public async Task<List<SmartStudent>> GetStudents()
		{
			var serviceData = new StudentService();
			var studentdata = await serviceData.GetStudents();
			return studentdata;
		}
	}
}
