using FCI.AlzheimerDetection.BL.DTOs.RelativeDTOs;
using FCI.AlzheimerDetection.BL.Enums;
using FCI.AlzheimerDetection.BL.Helper;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.DAL.Models;
using FCI.AlzheimerDetection.DAL.Models.Identity;
using FCI.AlzheimerDetection.DAL.Shared;
using FCI.AlzheimerDetection.DAL.UOW;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace FCI.AlzheimerDetection.BL.Managers.Impelementations;

public class AddRelativeManager : IAddRelativeManager
{
    private readonly UserManager<Relative> _relativeManger;
    private readonly UserManager<Admin> _adminManger;
    private readonly IUnitOfWork _unitOfWork;

    public AddRelativeManager(UserManager<Relative> relativeManger, UserManager<Admin> adminManger, IUnitOfWork unitOfWork)
    {
        _relativeManger = relativeManger;
        _adminManger = adminManger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> AddRelative(AddRelativeDTO relativeDTO, string adminId, int patientId)
    {
        var adminsIsExists = await _adminManger.FindByIdAsync(adminId);
        if (adminsIsExists is null)
            return Result.Failure("Admin Not Found");

        var patientIsExists = _unitOfWork.patientRepository.GetById(patientId);

        if (patientIsExists is null)
            return Result.Failure("Patient Not Found");

        var relative = ToRelativeModel(relativeDTO);

        var createRelativeResult = await _relativeManger.CreateAsync(relative, GeneratePassword(relativeDTO));

        if (!createRelativeResult.Succeeded)
            return Result.Failure("".GetErrorResult(createRelativeResult));

        var addRoleResult = await _relativeManger.AddToRoleAsync(relative, nameof(AppRoles.Relative));

        if (!addRoleResult.Succeeded)
            return Result.Failure("".GetErrorResult(addRoleResult));

        var addRelative = new AddRelative
        {
            Admin = adminsIsExists,
            Patient = patientIsExists,
            Relative = relative
        };

        _unitOfWork.addRelativeRepository.Create(addRelative);

        if (_unitOfWork.Commit() == 0)
            return Result.Failure("Faild To Add Relative");

        return Result.Success("Relative Added Successfully");
    }

    private static Relative ToRelativeModel(AddRelativeDTO relativeDTO) =>
        new()
        {
            FirstName = relativeDTO.FirstName,
            LastName = relativeDTO.LastName,
            BirthDate = relativeDTO.BirthDate,
            SSN = relativeDTO.SSN,
            City = relativeDTO.City,
            Street = relativeDTO.Street,
            ZipCode = relativeDTO.ZipCode,
            UserName = $"{relativeDTO.FirstName.Trim()}{relativeDTO.LastName.Trim()}",
            RelationshipDegree = relativeDTO.RelationshipDegree
        };

    private static string GeneratePassword(AddRelativeDTO addRelativeDTO)
    {
        var password = new StringBuilder();
        password.Append(addRelativeDTO.FirstName[0..2].ToUpper());
        password.Append(addRelativeDTO.LastName[0..2].ToLower());
        password.Append('@');
        password.Append(addRelativeDTO.SSN[..6]);
        return password.ToString();
    }
}

#region Add Relative Steps

// search for current admin  if not exist => return errors
// search for patient if not exist => return false
// map from dto to relative model
// create realtive
// create add realative model contians trhee models admins , patient, relative
// reutrn created successfully

#endregion Add Relative Steps