using FCI.AlzheimerDetection.BL.DTOs.PatientDTOs;
using FCI.AlzheimerDetection.BL.Enums;
using FCI.AlzheimerDetection.BL.Helper;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCI.AlzheimerDetection.Presentation.Controllers;

[Route(ApiRoutes.Patients.Base)]
[ApiController]
[Authorize(Roles = nameof(AppRoles.Admin))]
public class PatientController(IPatientManager patientManager, UserUtility userUtility) : ControllerBase
{
    [HttpPost(ApiRoutes.Patients.Create)]
    [Authorize(Roles = nameof(AppRoles.Admin))]
    public async Task<ActionResult<CreatePatientDTO>> CreatePatient(CreatePatientDTO createPatientDto)
    {
        var adminId = int.Parse(userUtility.GetUserId());
        var result = await patientManager.CreatePatient(adminId, createPatientDto);
        return result.IsSuccess ?
            Ok("Patient Created Successfully") :
            BadRequest(result);
    }

    [HttpGet(ApiRoutes.Patients.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var result = await patientManager.GetAllPatients();
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }

    [HttpGet(ApiRoutes.Patients.Get)]
    public async Task<IActionResult> GetPatient(int id)
    {
        var result = await patientManager.GetPatientById(id);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }

    [HttpPut(ApiRoutes.Patients.Update)]
    public async Task<IActionResult> UpdatePatient(int id, UpdatePatientDTO updatePatientDto)
    {
        var result = await patientManager.UpdatePatient(id, updatePatientDto);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }

    [HttpDelete(ApiRoutes.Patients.Delete)]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var result = await patientManager.DeletePatient(id);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }

    [HttpGet(ApiRoutes.Patients.GetAllPaged)]
    public async Task<IActionResult> GetAllPatientsWithPaging(int pageNumber, int pageSize)
    {
        var result = await patientManager.GetAllPatientsWithPaging(pageNumber, pageSize);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }

    [HttpGet(ApiRoutes.Patients.Find)]
    public async Task<IActionResult> Find(string key)
    {
        var result = await patientManager.Search(key);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }
    
    [HttpGet(ApiRoutes.Patients.FindPaged)]
    public async Task<IActionResult> Search(string key, int pageNumber, int pageSize)
    {
        var result = await patientManager.Search(key, pageNumber, pageSize);
        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }
}