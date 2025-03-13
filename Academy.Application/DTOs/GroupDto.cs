namespace Academy.Application.DTOs;

public class GroupDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    public List<TeacherDto> Teachers { get; set; } = new List<TeacherDto>();
}

public class GroupCreateDto
{
    public string Name { get; set; }
    public List<int> TeacherIds { get; set; } = new List<int>();
}
