using FCI.AlzheimerDetection.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace FCI.AlzheimerDetection.BL.Helper;

public static class IdentityHelper
{
    public static async Task<Admin> FindBySSNAsync(this UserManager<Admin> userManager, string ssn) =>
       await userManager.Users.FirstOrDefaultAsync(u => u.SSN == ssn);

    public static async Task<Relative> FindBySSNAsync(this UserManager<Relative> userManager, string ssn) =>
     await userManager.Users.FirstOrDefaultAsync(u => u.SSN == ssn);

    public static string GetErrorResult(this string s, IdentityResult identityResult)
    {
        StringBuilder errors = new();
        foreach (var error in identityResult.Errors)
            errors.AppendLine(error.Description);
        return errors.ToString();
    }
}