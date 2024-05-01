using FCI.AlzheimerDetection.BL.DTOs.MRIDTOs;
using FCI.AlzheimerDetection.DAL.Shared;

namespace FCI.AlzheimerDetection.BL.Managers.Abstractions;

public interface IAdminMRIManager
{
    Task<Result> UploadAdminMRI(UploadAdminMRIDTO uploadAdminMRIDTO, int adminId);
}