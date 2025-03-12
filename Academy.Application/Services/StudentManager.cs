using Academy.Application.DTOs;
using Academy.Application.Repositories;
using Academy.Application.Services.Contracts;
using Academy.Domain.Entities;
using System.Linq.Expressions;

namespace Academy.Application.Services;

public class StudentManager : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentManager(IStudentRepository repository)
    {
        _repository = repository;
    }

    public void AddStudent(StudentCreateDto createDto)
    {
        var student = new Student
        {
            Name = createDto.Name,
            GroupId = createDto.GroupId
        };

        _repository.Add(student);
    }

    public StudentDto GetStudent(Func<Student, bool> predicate)
    {
        var student = _repository.Get(predicate);

        var studentDto = new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            GroupName = student.Group?.Name
        };

        return studentDto;
    }

    public List<StudentDto> GetStudents(Expression<Func<Student, bool>>? predicate = null)
    {
        var studentDtos = new List<StudentDto>();

        foreach (var item in _repository.GetAll(predicate))
        {
            studentDtos.Add(new StudentDto 
            { 
                Id = item.Id, Name = item.Name, GroupName = item.Group?.Name
            });
        }

        return studentDtos;
    }

    public void RemoveStudent(int id)
    {
        _repository.Remove(id);
    }

    public void UpdateStudent(int id, Student student)
    {
        _repository.Update(id, student);
    }
}