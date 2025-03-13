namespace Academy.Domain.Entities;

public class Student : Entity
{
    public string Name { get; set; }
    public int GroupId { get; set; }
    public Group? Group { get; set; }
}