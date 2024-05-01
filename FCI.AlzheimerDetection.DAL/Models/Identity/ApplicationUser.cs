using Microsoft.AspNetCore.Identity;

namespace FCI.AlzheimerDetection.DAL.Models.Identity;

public class ApplicationUser : IdentityUser<int>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}