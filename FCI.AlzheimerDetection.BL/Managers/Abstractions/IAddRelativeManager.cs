using FCI.AlzheimerDetection.BL.DTOs.RelativeDTOs;
using FCI.AlzheimerDetection.DAL.Shared;

namespace FCI.AlzheimerDetection.BL.Managers.Abstractions;

public interface IAddRelativeManager
{
    Task<Result> AddRelative(AddRelativeDTO relativeDTO, string adminId, int patientId);
}