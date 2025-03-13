using Academy.Application.Repositories;
using Academy.Domain.Entities;
using Academy.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Academy.Infrastructure.Repositories;

public class TeacherRepository : EfCoreRepository<Teacher>, ITeacherRepository
{
    private readonly AppDbContext _context;

    public TeacherRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public override List<Teacher> GetAll(Expression<Func<Teacher, bool>>? predicate = null)
    {
        var teachers = _context.Teachers
            .Include(x => x.TeacherGroups)
            .ThenInclude(y => y.Group)
            .ToList();

        return teachers;
    }
}