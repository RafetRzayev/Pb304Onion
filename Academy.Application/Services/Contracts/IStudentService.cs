using Academy.Application.DTOs;
using Academy.Domain.Entities;

namespace Academy.Application.Services.Contracts;

public interface IStudentService
{
    StudentDto GetStudent(Func<Student, bool> predicate);
    List<StudentDto> GetStudents(Func<Student, bool> predicate);
    void AddStudent(StudentCreateDto student);
    void RemoveStudent(int id);
    void UpdateStudent(int id, Student student);
}