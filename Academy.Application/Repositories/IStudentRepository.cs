using Academy.Domain.Entities;

namespace Academy.Application.Repositories;

public interface IStudentRepository
{
    Student GetStudent(Func<Student, bool> predicate);
    List<Student> GetStudents(Func<Student, bool> predicate);
    void AddStudent(Student student);
    void RemoveStudent(int id);
    void UpdateStudent(int id, Student student);
}