namespace Academy.Domain.Entities;

public class Student : Entity
{
    public string Name { get; set; }

    public int GroupId { get; set; }
    public Group? Group { get; set; }
}

public class Group : Entity
{
    public string Name { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
}

public class Entity
{
    public int Id { get; set; }
}