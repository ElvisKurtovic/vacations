using System;
using System.Collections.Generic;
using vacations.Models;
using vacations.Services;
using Microsoft.AspNetCore.Mvc;

namespace vacations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CruiseController : ControllerBase
    {

        private readonly CruiseService _service;

        public CruiseController(CruiseService service)
        {
            _service = service;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Cruise>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")] // GETBYID
        public ActionResult<Cruise> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost] // POST
        public ActionResult<Cruise> Create([FromBody] Cruise newCruise)
        {
            try
            {
                return Ok(_service.Create(newCruise));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Cruise> Edit([FromBody] Cruise editCruise, int id)
        {
            try
            {
                editCruise.Id = id;
                return Ok(_service.Edit(editCruise));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")] // DELETE
        public ActionResult<Cruise> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}