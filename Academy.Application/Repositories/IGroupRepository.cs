using Academy.Domain.Entities;

namespace Academy.Application.Repositories;

public interface IGroupRepository : IRepository<Group>
{
    void OnlyGroup();
}