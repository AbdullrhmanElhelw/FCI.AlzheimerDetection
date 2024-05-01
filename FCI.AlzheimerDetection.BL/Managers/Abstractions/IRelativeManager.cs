using FCI.AlzheimerDetection.BL.DTOs.RelativeDTOs;
using FCI.AlzheimerDetection.DAL.Shared;

namespace FCI.AlzheimerDetection.BL.Managers.Abstractions;

public interface IRelativeManager
{
    Task<Result> Login(LoginRelativeDTO relativeDTO);
}