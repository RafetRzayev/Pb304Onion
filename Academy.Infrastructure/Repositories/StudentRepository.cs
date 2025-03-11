using Academy.Application.Repositories;
using Academy.Domain.Entities;
using Academy.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public Student GetStudent(Func<Student, bool> predicate)
    {
        var student = _context.Students
            .Include(x => x.Group)
            .FirstOrDefault(predicate);

        return student;
    }

    public List<Student> GetStudents(Func<Student, bool> predicate)
    {
        var students = _context.Students
            .Include(x => x.Group)
            .Where(predicate)
            .ToList();

        return students;
    }

    public void RemoveStudent(int id)
    {
        var existStudent = _context.Students.Find(id);

        if (existStudent == null)
        {
            Console.WriteLine("Not found");

            return;
        }

        _context.Students.Remove(existStudent);
        _context.SaveChanges();
    }

    public void UpdateStudent(int id, Student student)
    {
        var existStudent = _context.Students.Find(id);

        if (existStudent == null)
        {
            Console.WriteLine("Not found");

            return;
        }

        existStudent.Name = student.Name;
        _context.SaveChanges();
    }
}