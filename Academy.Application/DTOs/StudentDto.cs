namespace Academy.Application.DTOs;

public class StudentDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? GroupName { get; set; }
}

public class StudentCreateDto
{
    public string Name { get; set; }
    public int GroupId { get; set; }
}