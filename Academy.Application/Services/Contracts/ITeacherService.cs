using Academy.Application.DTOs;
using Academy.Domain.Entities;
using System.Linq.Expressions;

namespace Academy.Application.Services.Contracts;

public interface ITeacherService
{
    TeacherDto GetTeacher(Func<Teacher, bool> predicate);
    List<TeacherDto> GetTeachers(Expression<Func<Teacher, bool>>? predicate = null);
    void AddTeacher(TeacherCreateDto teacher);
    void RemoveTeacher(int id);
    void UpdateTeacher(int id, Teacher teacher);
}
