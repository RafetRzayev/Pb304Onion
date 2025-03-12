using Academy.Application.Repositories;
using Academy.Domain.Entities;
using Academy.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class GroupRepository : EfCoreRepository<Group>, IGroupRepository
{
    private readonly AppDbContext _context;

    public GroupRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public void OnlyGroup()
    {
        throw new NotImplementedException();
    }
}
