using FCI.AlzheimerDetection.BL.DTOs.MRIDTOs;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.DAL.Models;
using FCI.AlzheimerDetection.DAL.Shared;
using FCI.AlzheimerDetection.DAL.UOW;
using FluentValidation;
using System.Text;

namespace FCI.AlzheimerDetection.BL.Managers.Impelementations;

public class NormalUserMRIManager : INormalUserMRIManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidatorFactory _validatorFactory;

    public NormalUserMRIManager(IUnitOfWork unitOfWork, IValidatorFactory validatorFactory)
    {
        _unitOfWork = unitOfWork;
        _validatorFactory = validatorFactory;
    }

    public async Task<Result> UploadMRI(UploadNormalUserMRI userMRI, int normalUserId)
    {
        var validationResult = await _validatorFactory
            .GetValidator<UploadNormalUserMRI>()
            .ValidateAsync(userMRI);

        if (!validationResult.IsValid)
        {
            var errors = new StringBuilder();

            foreach (var error in validationResult.Errors)
                errors.AppendLine(error.ErrorMessage);

            return Result.Failure(errors.ToString());
        }

        var memoryStream = new MemoryStream();
        await userMRI.MRI.CopyToAsync(memoryStream);

        var mri = new MRI
        {
            Content = memoryStream.ToArray(),
            Name = userMRI.MRI.FileName,
            Extension = Path.GetExtension(userMRI.MRI.FileName)
        };

        var normalUserMRI = new NormalUserMRI
        {
            MRI = mri,
            NormalUserId = normalUserId
        };

        _unitOfWork.normalUserMRIRepository.Create(normalUserMRI);

        return _unitOfWork.Commit() == 0
            ? Result.Failure("Failed to upload MRI")
            : Result.Success();
    }

    public async Task<Result> UploadMultipleMRI(UploadMultipleMRIDTO multipleMRIDTO, int normalUserId)
    {
        var validationResult = await _validatorFactory
            .GetValidator<UploadMultipleMRIDTO>()
            .ValidateAsync(multipleMRIDTO);

        if (!validationResult.IsValid)
        {
            var errors = new StringBuilder();

            foreach (var error in validationResult.Errors)
                errors.AppendLine(error.ErrorMessage);

            return Result.Failure(errors.ToString());
        }

        foreach (var file in multipleMRIDTO.MRIs)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var mri = new MRI
            {
                Content = memoryStream.ToArray(),
                Name = file.FileName,
                Extension = Path.GetExtension(file.FileName)
            };
            var normalUserMRI = new NormalUserMRI
            {
                MRI = mri,
                NormalUserId = normalUserId
            };
            _unitOfWork.normalUserMRIRepository.Create(normalUserMRI);
        }

        return _unitOfWork.Commit() == 0
            ? Result.Failure("Failed to upload MRI")
            : Result.Success();
    }
}