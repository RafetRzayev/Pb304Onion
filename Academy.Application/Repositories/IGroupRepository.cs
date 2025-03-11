using Academy.Domain.Entities;

namespace Academy.Application.Repositories;

public interface IGroupRepository
{
    Group GetGroup(Func<Group, bool> predicate);
    List<Group> GetGroups(Func<Group, bool> predicate);
    void AddGroup(Group group);
    void RemoveGroup(int id);
    void UpdateGroup(int id, Group group);
}
