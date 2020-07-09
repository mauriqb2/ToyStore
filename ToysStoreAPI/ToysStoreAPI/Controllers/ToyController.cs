using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ToysStoreAPI.Exceptions;
using ToysStoreAPI.Models;
using ToysStoreAPI.Services;

namespace ToysStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class ToyController : Controller
    {
        private IToyService service;

        public ToyController(IToyService service)
        {
            this.service = service;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<ToyModel>> GetToys(string orderBy = "id")
        {
            try
            {
                return Ok(service.GetToys(orderBy));
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
        public ActionResult<ToyModel> GetToy(int id)
        {
            try
            {
                return Ok(service.GetToy(id));
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
        public ActionResult<ToyModel> CreateToy([FromBody] ToyModel toy)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newToy = service.CreateToy(toy);
                return Created($"/api/Toys/{newToy.Id}", newToy);
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
        public ActionResult<bool> DeleteToy(int id)
        {
            try
            {
                var res = service.DeleteToy(id);
                return Ok(res);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult<bool> UpdateToy(int id, [FromBody] ToyModel toy)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        if (state.Key == nameof(toy.Name) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                    }
                }

                return Ok(service.UpdateToy(id, toy));
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
