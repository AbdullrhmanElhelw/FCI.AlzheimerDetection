using FCI.AlzheimerDetection.BL.DTOs.MRIDTOs;
using FCI.AlzheimerDetection.DAL.Shared;

namespace FCI.AlzheimerDetection.BL.Managers.Abstractions;

public interface INormalUserMRIManager
{
    Task<Result> UploadMRI(UploadNormalUserMRI userMRI, int normalUserId);

    Task<Result> UploadMultipleMRI(UploadMultipleMRIDTO multipleMRIDTO, int normalUserId);
}