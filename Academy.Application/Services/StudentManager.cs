using Academy.Application.DTOs;
using Academy.Application.Repositories;
using Academy.Application.Services.Contracts;
using Academy.Domain.Entities;

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

        _repository.AddStudent(student);
    }

    public StudentDto GetStudent(Func<Student, bool> predicate)
    {
        var student = _repository.GetStudent(predicate);

        var studentDto = new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            GroupName = student.Group?.Name
        };

        return studentDto;
    }

    public List<StudentDto> GetStudents(Func<Student, bool> predicate)
    {
        var studentDtos = new List<StudentDto>();

        foreach (var item in _repository.GetStudents(predicate))
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
        _repository.RemoveStudent(id);
    }

    public void UpdateStudent(int id, Student student)
    {
        _repository.UpdateStudent(id, student);
    }
}