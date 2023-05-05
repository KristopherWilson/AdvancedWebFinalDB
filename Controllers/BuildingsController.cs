using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class BuildingsController : ControllerBase
{
    
    IService _service;

    public BuildingsController(IService service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetBuildings")]
    public async Task<IActionResult> GetAllBuildings()
    {
        var _buildings = await _service.GetAll();
        return Ok(_buildings);
    }

    [HttpGet("{id}", Name = "GetBuildingById")]
    public async Task<IActionResult> GetBuildingById(string id)
    {
        var _building = await _service.GetById(id);
        return Ok(_building);
    }

    [HttpPost(Name = "AddBuilding")]
    public async Task<IActionResult> PostBuilding(string name, string id)
    {
        var result = await _service.CreateBuilding(name, id);
        return Ok(true);
    }

    [HttpPut("{id}", Name = "UpdateBuilding")]
    public async Task<IActionResult> PutBuilding(string name, string id)
    {
        var result = await _service.UpdateBuilding(name,id);
        return Ok(true);
    }

    [HttpDelete("{id}", Name = "DeleteBuilding")]
    public async Task<IActionResult> DeleteBuilding(string id)
    {
        var result = await _service.DeleteById(id);
        return Ok(result);
    }

}