using Academy.Application.DTOs;
using Academy.Domain.Entities;
using System.Linq.Expressions;

namespace Academy.Application.Services.Contracts;

public interface IStudentService
{
    StudentDto GetStudent(Func<Student, bool> predicate);
    List<StudentDto> GetStudents(Expression<Func<Student, bool>>? predicate = null);
    void AddStudent(StudentCreateDto student);
    void RemoveStudent(int id);
    void UpdateStudent(int id, Student student);
}