using Academy.Application.Repositories;
using Academy.Domain.Entities;
using Academy.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class StudentRepository : EfCoreRepository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context)
    {
    }
}