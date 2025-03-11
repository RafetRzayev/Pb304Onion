using Academy.Application.DTOs;
using Academy.Application.Repositories;
using Academy.Application.Services.Contracts;
using Academy.Domain.Entities;

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

        _repository.AddGroup(group);
    }

    public GroupDto GetGroup(Func<Group, bool> predicate)
    {
        var group = _repository.GetGroup(predicate);

        var groupDto = new GroupDto
        {
            Id = group.Id,
            Name = group.Name,
        };

        return groupDto;
    }

    public List<GroupDto> GetGroups(Func<Group, bool> predicate)
    {
        var groupDtos = new List<GroupDto>();

        foreach (var item in _repository.GetGroups(predicate))
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
        _repository.RemoveGroup(id);
    }

    public void UpdateGroup(int id, Group group)
    {
        _repository.UpdateGroup(id, group);
    }
}
