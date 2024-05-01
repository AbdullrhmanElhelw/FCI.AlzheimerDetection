using FCI.AlzheimerDetection.BL.DTOs.AdminDTOs;
using FCI.AlzheimerDetection.BL.DTOs.EmailServiceDTOs;
using FCI.AlzheimerDetection.DAL.Shared;

namespace FCI.AlzheimerDetection.BL.Managers.Abstractions;

public interface IAdminManager
{
    Task<Result> Create(CreateAdminDTO registerDTO);

    Task<Result> Login(LoginAdminDTO loginDTO);

    Task<Result> Delete(int id);

    Task<Result> ChangePassword(int id, ChangePasswordDTO passwordDTO);

    Task<Result<ReadAdminDTO>> GetAdmin(string ssn);

    Task<Result<IQueryable<ReadAdminDTO>>> GetAllAdmins();

    Task<Result<IQueryable<ReadAdminDTO>>> GetAllAdminsWithPaging(int pageNumber, int pageSize, string orderBy = "SSN");

    Task<Result<IQueryable<ReadAdminDTO>>> FindAllByName(string Name);
}