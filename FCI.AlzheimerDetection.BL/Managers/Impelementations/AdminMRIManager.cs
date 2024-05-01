using FCI.AlzheimerDetection.BL.DTOs.MRIDTOs;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.DAL.Models;
using FCI.AlzheimerDetection.DAL.Shared;
using FCI.AlzheimerDetection.DAL.UOW;
using FluentValidation;
using System.Text;

namespace FCI.AlzheimerDetection.BL.Managers.Impelementations;

public class AdminMRIManager : IAdminMRIManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidatorFactory _validatorFactory;

    public AdminMRIManager(IUnitOfWork unitOfWork, IValidatorFactory validatorFactory)
    {
        _unitOfWork = unitOfWork;
        _validatorFactory = validatorFactory;
    }

    public async Task<Result> UploadAdminMRI(UploadAdminMRIDTO uploadAdminMRIDTO, int adminId)
    {
        var validator = _validatorFactory.GetValidator<UploadAdminMRIDTO>();
        var validationResult = await validator.ValidateAsync(uploadAdminMRIDTO);

        if (!validationResult.IsValid)
        {
            var errors = new StringBuilder();
            foreach (var error in validationResult.Errors)
            {
                errors.AppendLine(error.ErrorMessage);
            }
            return Result.Failure(errors.ToString());
        }

        using var memoryStream = new MemoryStream();
        await uploadAdminMRIDTO.MRI.CopyToAsync(memoryStream);

        var mri = new MRI
        {
            Content = memoryStream.ToArray(),
            Name = uploadAdminMRIDTO.MRI.FileName,
            Extension = Path.GetExtension(uploadAdminMRIDTO.MRI.FileName)
        };

        var adminMri = new AdminMRI
        {
            MRI = mri,
            AdminId = adminId
        };

        _unitOfWork.adminMRIRepository.Create(adminMri);

        return _unitOfWork.Commit() == 0
            ? Result.Failure("Failed to Upload MRI")
            : Result.Success("Image Uploaded SuccessFully");
    }
}