using Academy.Application.Repositories;
using Academy.Domain.Entities;
using Academy.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Academy.Infrastructure.Repositories;

public class GroupRepository : EfCoreRepository<Group>, IGroupRepository
{
    private readonly AppDbContext _context;

    public GroupRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public override List<Group> GetAll(Expression<Func<Group, bool>>? predicate = null)
    {
        var groups = _context.Groups
            .Include(x => x.Students)
            .Include(x => x.TeacherGroups).ThenInclude(x => x.Teacher)
            .ToList();

        return groups;
    }

    public void OnlyGroup()
    {
        throw new NotImplementedException();
    }
}
