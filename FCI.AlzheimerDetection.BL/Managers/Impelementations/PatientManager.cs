using FCI.AlzheimerDetection.BL.DTOs.PatientDTOs;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.DAL.Shared;
using FCI.AlzheimerDetection.DAL.UOW;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text;
using FCI.AlzheimerDetection.DAL.Models;

namespace FCI.AlzheimerDetection.BL.Managers.Impelementations;

public class PatientManager : IPatientManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidatorFactory _validatorFactory;

    public PatientManager(IUnitOfWork unitOfWork, IValidatorFactory validatorFactory)
    {
        _unitOfWork = unitOfWork;
        _validatorFactory = validatorFactory;
    }

    public Task<Result> CreatePatient(int adminId, CreatePatientDTO patientDTO)
    {
        var _createPatientValidator = _validatorFactory.GetValidator<CreatePatientDTO>();
        var validationResult = _createPatientValidator.Validate(patientDTO);

        if (!validationResult.IsValid)
        {
            var error = new StringBuilder();
            foreach (var failure in validationResult.Errors)
            {
                error.AppendLine(failure.ErrorMessage);
            }
            return Task.FromResult(Result.Failure(error.ToString()));
        }


        var patientToAdd = new Patient()
        {
            FirstName = patientDTO.FirstName,
            LastName = patientDTO.LastName,
            AdminId = adminId,
            SSN = patientDTO.SSN,
            City = patientDTO.City,
            ZipCode = patientDTO.ZipCode,
            BirthDate = patientDTO.BirthDate,
            Phone = patientDTO.Phone
        };

        _unitOfWork.patientRepository.Create(patientToAdd);
        return _unitOfWork.Commit() == 0
            ? Task.FromResult(Result.Failure("Failed To Save"))
            : Task.FromResult(Result.Success());
    }

    public Task<Result> DeletePatient(int id)
    {
        var patientIsExists = _unitOfWork.patientRepository.GetById(id);

        if (patientIsExists is null)
            return Task.FromResult(Result.Failure("Patient Not Found"));

        _unitOfWork.patientRepository.Delete(patientIsExists);
        return _unitOfWork.Commit() == 0
            ? Task.FromResult(Result.Failure("Failed To Save"))
            : Task.FromResult(Result.Success());
    }

    public Task<Result<IQueryable<ReadPatientDTO>>> GetAllPatients()
    {
        var list = _unitOfWork.patientRepository.GetAll();
        var mappedList = _unitOfWork.patientRepository.GetAll().Select(p => new ReadPatientDTO(
            p.FirstName, p.LastName, p.SSN, p.City, p.Street, p.ZipCode, p.BirthDate, p.Phone
            ));

        return Task.FromResult(Result.Success(mappedList));
    }

    public Task<Result<IQueryable<ReadPatientDTO>>> GetAllPatientsWithPaging(int pageNumber, int pageSize)
    {
        var list = _unitOfWork.patientRepository.GetAll();
        var mappedList = _unitOfWork.patientRepository.GetAll()
            .Select(p => new ReadPatientDTO(
                       p.FirstName, p.LastName, p.SSN, p.City, p.Street, p.ZipCode, p.BirthDate, p.Phone
                                  ));

        return Task.FromResult(Result.Success(mappedList.Skip((pageNumber - 1) * pageSize).Take(pageSize)));
    }

    public Task<Result<ReadPatientDTO>> GetPatientById(int id)
    {
        var p = _unitOfWork.patientRepository.GetById(id);
        var mappedPatient = new ReadPatientDTO(p.FirstName, p.LastName, p.SSN, p.City, p.Street, p.ZipCode, p.BirthDate, p.Phone);
        return Task.FromResult(Result.Success(mappedPatient));
    }

    public Task<Result<IQueryable<ReadPatientDTO>>> Search(string key)
    {
        var list = _unitOfWork.patientRepository.FindAll(p =>
                EF.Functions.Like(p.FirstName, $"%{key}%")
                || EF.Functions.Like(p.LastName, $"%{key}%")
                || EF.Functions.Like(p.SSN, $"%{key}%"))
            .Select(p => new ReadPatientDTO(
                p.FirstName, p.LastName, p.SSN, p.City, p.Street, p.ZipCode, p.BirthDate, p.Phone
            ));

        return Task.FromResult(Result.Success(list));
    }

    public Task<Result<IQueryable<ReadPatientDTO>>> Search(string key, int pageNumber, int pageSize)
    {
        var list = _unitOfWork.patientRepository.FindAll(p =>
                EF.Functions.Like(p.FirstName, $"%{key}%")
                || EF.Functions.Like(p.LastName, $"%{key}%")
                || EF.Functions.Like(p.SSN, $"%{key}%"))
            .Select(p => new ReadPatientDTO(
                p.FirstName, p.LastName, p.SSN, p.City, p.Street, p.ZipCode, p.BirthDate, p.Phone
            ));

        return Task.FromResult(Result.Success(list.Skip((pageNumber - 1) * pageSize).Take(pageSize)));
    }

    public Task<Result> UpdatePatient(int id, UpdatePatientDTO patientDTO)
    {
        var patientIsExists = _unitOfWork.patientRepository.GetById(id);

        if (patientIsExists is null)
            return Task.FromResult(Result.Failure("Patient Not Found"));

        var getValidator = _validatorFactory.GetValidator<UpdatePatientDTO>();
        var validationResult = getValidator.Validate(patientDTO);

        if (!validationResult.IsValid)
        {
            var error = new StringBuilder();
            foreach (var failure in validationResult.Errors)
            {
                error.AppendLine(failure.ErrorMessage);
            }
            return Task.FromResult(Result.Failure(error.ToString()));
        }

        patientIsExists.FirstName = patientDTO.FirstName;
        patientIsExists.LastName = patientDTO.LastName;
        patientIsExists.City = patientDTO.City;
        patientIsExists.Street = patientDTO.Street;
        patientIsExists.ZipCode = patientDTO.ZipCode;
        patientIsExists.Phone = patientDTO.Phone;

        _unitOfWork.patientRepository.Update(patientIsExists);
        return _unitOfWork.Commit() == 0
            ? Task.FromResult(Result.Failure("Failed To Save"))
            : Task.FromResult(Result.Success());
    }
}