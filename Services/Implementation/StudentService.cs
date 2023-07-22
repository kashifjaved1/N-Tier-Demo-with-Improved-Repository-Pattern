using Repositories.Contracts;
using Repositories.Entities;
using Services.DTOs;

namespace Services.Implementation
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<StudentDTO> AddStudent(StudentCreateDTO student)
        {
            var studentToAdd = new Student
            {
                Name = student.Name,
                ClassroomId = student.ClassroomId
            };

            _repository.Students.Add(studentToAdd);
            var res = await _repository.SaveChangesAsync();
            return res > 0 ?
                new StudentDTO
                {
                    Id = studentToAdd.Id,
                    Name = student.Name,
                    ClassroomId = student.ClassroomId
                } : null;
        }

        public List<StudentDTO> Students()
        {
            var students = _repository.Students;
            var studentList = new List<StudentDTO>();
            foreach (var student in students)
            {
                studentList.Add(new StudentDTO
                {
                    Id= student.Id,
                    Name = student.Name,
                    ClassroomId = student.ClassroomId
                });
            }

            return studentList;
        }
    }
}
