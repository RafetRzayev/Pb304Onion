namespace Academy.Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int GroupId { get; set; }
    public Group? Group { get; set; }
}

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
}