using Building.Context.Context;
using Building.Dtos;
using Building.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        IBuildingService BuildingService;
        public BuildingController(IBuildingService _buildingService)
        {
            BuildingService = _buildingService;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var query = BuildingService.GetAll();
            return Ok(query);
        }


        [HttpGet("{Id}")]


        public IActionResult GetOne(int Id)
        {
            var query = BuildingService.GetOne(Id);
            return Ok(query);
        }


        [HttpPost]


        public IActionResult Create([FromBody] BuildingDto dto)
        {
            var result = BuildingService.Create(dto);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Failed to create Building.");
        }


        [HttpPut("{Id}")]


        public IActionResult Update(int Id, BuildingDto dto)
        {
            var result = BuildingService.Update(Id, dto);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Failed to update building.");
        }


        [HttpDelete("{Id}")]

        public IActionResult Delete(int Id)
        {
            var result = BuildingService.Delete(Id);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Failed to delete building.");
        }
    }
}
