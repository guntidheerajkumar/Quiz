using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quiz.Services;

namespace Quiz.Repository
{
	public class StudentRepository : IStudentRepository
	{
		public async Task<SmartStudent> AddStudent(SmartStudent student)
		{
			var serviceData = new StudentService();
			var studentData = await serviceData.AddStudent(student);
			return studentData;
		}

		public async Task<List<SmartStudent>> GetStudents()
		{
			var serviceData = new StudentService();
			var studentdata = await serviceData.GetStudents();
			return studentdata;
		}
	}
}
