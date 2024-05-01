using FCI.AlzheimerDetection.BL.DTOs.MedicineDTOs;
using FCI.AlzheimerDetection.BL.Enums;
using FCI.AlzheimerDetection.BL.Helper;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCI.AlzheimerDetection.Presentation.Controllers;

[Route(ApiRoutes.Medicines.Base)]
[ApiController]
[Authorize(Roles = nameof(AppRoles.Admin))]
public class MedicineController : ControllerBase
{
    private readonly IMedicineManager _medicineManager;
    private readonly UserUtility _userUtility;

    public MedicineController(IMedicineManager medicineManager, UserUtility userUtility)
    {
        _medicineManager = medicineManager;
        _userUtility = userUtility;
    }

   [HttpPost(ApiRoutes.Medicines.Create)]
    public async Task<ActionResult<CreateMedicineDTO>> CreateMedicine(CreateMedicineDTO medicineDTO)
    {
        var id = int.Parse(_userUtility.GetUserId());
        var result = await _medicineManager.CreateMedicine(medicineDTO, id);
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpGet(ApiRoutes.Medicines.GetAll)]
    public async Task<ActionResult<IQueryable<ReadMedicineDTO>>> GetAllMedicines()
    {
        var result = await _medicineManager.GetAllMedicines();
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpDelete(ApiRoutes.Medicines.Delete)]
    public async Task<IActionResult> DeleteMedicine(int id)
    {
        var result = await _medicineManager.DeleteMedicine(id);
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpGet(ApiRoutes.Medicines.Get)]
    public async Task<ActionResult<ReadMedicineDTO>> GetMedicine(int id)
    {
        var result = await _medicineManager.GetMedicine(id);
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }

   [HttpPut(ApiRoutes.Medicines.Update)]
    public async Task<IActionResult> UpdateMedicine(int id, UpdateMedicineDTO medicineDTO)
    {
        var result = await _medicineManager.UpdateMedicine(id, medicineDTO);
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }
}