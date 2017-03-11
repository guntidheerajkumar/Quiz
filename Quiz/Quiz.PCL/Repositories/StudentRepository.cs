using System;
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
	}
}
