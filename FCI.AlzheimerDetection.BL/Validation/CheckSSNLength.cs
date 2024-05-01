using FCI.AlzheimerDetection.BL.DTOs.AdminDTOs;
using FCI.AlzheimerDetection.BL.DTOs.RelativeDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FCI.AlzheimerDetection.BL.Validation;

public class CheckSSNLength : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.ContainsKey("relativeDTO") || context.ActionArguments.ContainsKey("adminDTO"))
        {
            var argument = context.ActionArguments;
            if (argument.ContainsKey("relativeDTO"))
            {
                var relativeDTO = argument["relativeDTO"] as AddRelativeDTO;
                if (relativeDTO.SSN.Length != 14)
                {
                    context.Result = new BadRequestObjectResult("SSN must be 14 digits");
                }
            }
            else if (argument.ContainsKey("adminDTO"))
            {
                var adminDTO = argument["adminDTO"] as CreateAdminDTO;
                if (adminDTO.SSN.Length != 14)
                {
                    context.Result = new BadRequestObjectResult("SSN must be 14 digits");
                }
            }
        }
    }
}