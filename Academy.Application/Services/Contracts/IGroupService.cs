using Academy.Application.DTOs;
using Academy.Domain.Entities;
using System.Linq.Expressions;

namespace Academy.Application.Services.Contracts;

public interface IGroupService
{
    GroupDto GetGroup(Func<Group, bool> predicate);
    List<GroupDto> GetGroups(Expression<Func<Group, bool>>? predicate = null);
    void AddGroup(GroupCreateDto group);
    void RemoveGroup(int id);
    void UpdateGroup(int id, Group group);
}
