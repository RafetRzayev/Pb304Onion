using Academy.Application.DTOs;
using Academy.Application.Repositories;
using Academy.Application.Services.Contracts;
using Academy.Domain.Entities;
using System.Linq.Expressions;

namespace Academy.Application.Services;

public class GroupManager : IGroupService
{
    private readonly IGroupRepository _repository;

    public GroupManager(IGroupRepository repository)
    {
        _repository = repository;
    }

    public void AddGroup(GroupCreateDto createDto)
    {
        var group = new Group
        {
            Name = createDto.Name,
        };

        _repository.Add(group);
    }

    public GroupDto GetGroup(Func<Group, bool> predicate)
    {
        var group = _repository.Get(predicate);

        var groupDto = new GroupDto
        {
            Id = group.Id,
            Name = group.Name,
        };

        return groupDto;
    }

    public List<GroupDto> GetGroups(Expression<Func<Group, bool>>? predicate = null)
    {
        var groupDtos = new List<GroupDto>();

        foreach (var item in _repository.GetAll(predicate))
        {
            groupDtos.Add(new GroupDto
            {
                Id = item.Id,
                Name = item.Name,
                Students = item.Students.Select(x => new StudentDto { Id = x.Id, Name = x.Name }).ToList()
            });
        }

        return groupDtos;
    }

    public void RemoveGroup(int id)
    {
        _repository.Remove(id);
    }

    public void UpdateGroup(int id, Group group)
    {
        _repository.Update(id, group);
    }
}
