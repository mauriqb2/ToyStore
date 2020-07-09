using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToysStoreAPI.Exceptions;
using ToysStoreAPI.Models;
using ToysStoreAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToysStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class EnterpriseController : Controller
    {
        private IEnterpriseService service;

        public EnterpriseController(IEnterpriseService service)
        {
            this.service = service;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<EnterpriseModel>> GetEnterprises(string orderBy = "id")
        {
            try
            {
                return Ok(service.GetEnterprises(orderBy));
            }
            catch (BadOperationRequest ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }



        }


        [HttpGet("{id:int}")]
        public ActionResult<EnterpriseModel> GetEnterprise(int id)
        {
            try
            {
                return Ok(service.GetEnterprise(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<EnterpriseModel> CreateEnterprise([FromBody] EnterpriseModel enterprise)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newEnterprise = service.CreateEnterprise(enterprise);
                return Created($"/api/Enterprises/{newEnterprise.Id}", newEnterprise);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteEnterprise(int id)
        {
            try
            {
                var res = service.DeleteEnterprise(id);
                return Ok(res);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult<bool> UpdateEnterprise(int id, [FromBody] EnterpriseModel enterprise)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        if (state.Key == nameof(enterprise.Name) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                    }
                }

                return Ok(service.UpdateEnterprise(id, enterprise));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
