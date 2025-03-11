using Academy.Application.Repositories;
using Academy.Domain.Entities;
using Academy.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly AppDbContext _context;

    public GroupRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddGroup(Group group)
    {
        _context.Groups.Add(group);
        _context.SaveChanges();
    }

    public Group GetGroup(Func<Group, bool> predicate)
    {
        var group = _context.Groups
            .Include(x => x.Students)
            .FirstOrDefault(predicate);

        return group;
    }

    public List<Group> GetGroups(Func<Group, bool> predicate)
    {
        var groups = _context.Groups
            .Include(x => x.Students)
            .Where(predicate)
            .ToList();

        return groups;
    }

    public void RemoveGroup(int id)
    {
        var existGroup = _context.Groups.Find(id);

        if (existGroup == null)
        {
            Console.WriteLine("Not found");

            return;
        }

        _context.Groups.Remove(existGroup);
        _context.SaveChanges();
    }

    public void UpdateGroup(int id, Group group)
    {
        var existGroup = _context.Groups.Find(id);

        if (existGroup == null)
        {
            Console.WriteLine("Not found");

            return;
        }

        existGroup.Name = group.Name;
        _context.SaveChanges();
    }
}
