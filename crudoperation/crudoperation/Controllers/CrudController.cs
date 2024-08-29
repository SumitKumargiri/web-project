using crudoperation.Interface;
using crudoperation.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudoperation.Controllers
{
   
        // GET: CrudController    
        [Route("[controller]")]
        [ApiController]
        public class CrudController : ControllerBase
        {
            private readonly Icrud _crudService;

            public CrudController(Icrud crudService)
            {
                _crudService = crudService;
            }

            [HttpGet("getoperation")]
            public async Task<IActionResult> GetEmployees()
            {
                var result = await _crudService.Getcrud();
                return Ok(result);
            }

        [HttpPost("insertoperation")]
        public async Task<IActionResult> InsertEmployee([FromBody] Crud model)
        {
            var result = await _crudService.InsertCrud(model);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("updateoperation")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Crud model)
        {
            var result = await _crudService.UpdateCrud(model);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("deleteoperation/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _crudService.DeleteCrud(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
    }

