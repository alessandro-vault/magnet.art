namespace API.Training.Domain.Models;

public class Provider
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ApiUrl { get; set; }
    public bool? KeyRequired { get; set; } = false;
    public string? ApiKey { get; set; }
}