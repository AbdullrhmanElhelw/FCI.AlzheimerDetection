namespace FCI.AlzheimerDetection.DAL.Models;

public class AppFile
{
    public int Id { get; set; }
    public byte[] Content { get; set; } = [];
    public string Name { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;
}