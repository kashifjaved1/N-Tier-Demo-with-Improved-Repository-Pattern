using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Entities;
using Services.DTOs;

namespace Services.Implementation
{
    public class ClassroomService
    {
        private readonly IClassroomRepository _repository;

        public ClassroomService(IClassroomRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClassroomDTO> AddClassroom(ClassroomCreateDTO classroom)
        {
            var classroomToAdd = new Classroom
            {
                ClassroomNumber = classroom.ClassroomNumber
            };

            _repository.Classrooms.Add(classroomToAdd);
            var res = await _repository.SaveChangesAsync();
            return res > 0 ? 
                new ClassroomDTO
                {
                    Id = classroomToAdd.Id,
                    ClassroomNumber = classroom.ClassroomNumber
                } : null;
        }

        public List<ClassroomDTO> Classrooms()
        {
            var classrooms = _repository.Classrooms.Include(x => x.Students);
            var classroomList = new List<ClassroomDTO>();
            foreach (var classroom in classrooms)
            {
                var students = new List<StudentDTO>();
                foreach(var student in classroom.Students)
                {
                    students.Add(new StudentDTO
                    {
                        Id = student.Id,
                        Name = student.Name,
                        ClassroomId = student.ClassroomId
                    });
                }
                classroomList.Add(new ClassroomDTO
                {
                    Id = classroom.Id,
                    ClassroomNumber = classroom.ClassroomNumber,
                    Students = students
                });
            }

            return classroomList;
        }
    }
}
