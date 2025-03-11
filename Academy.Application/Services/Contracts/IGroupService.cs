using Academy.Application.DTOs;
using Academy.Domain.Entities;

namespace Academy.Application.Services.Contracts;

public interface IGroupService
{
    GroupDto GetGroup(Func<Group, bool> predicate);
    List<GroupDto> GetGroups(Func<Group, bool> predicate);
    void AddGroup(GroupCreateDto group);
    void RemoveGroup(int id);
    void UpdateGroup(int id, Group group);
}
