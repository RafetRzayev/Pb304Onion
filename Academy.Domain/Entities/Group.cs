namespace Academy.Domain.Entities;

public class Group : Entity
{
    public string Name { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
    public List<TeacherGroup> TeacherGroups { get; set; } = new List<TeacherGroup>();
}
