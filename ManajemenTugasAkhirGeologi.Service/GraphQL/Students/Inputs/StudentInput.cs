namespace ManajemenTugasAkhirGeologi.Service.GraphQL.Students.Inputs;

public class StudentInput
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Nim { get; set; } = string.Empty;
}