using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Services;
using Entities.DTOs;

namespace ScheduleMasterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _service;

        public ManagerController(IManagerService managerService)
        {
            _service = managerService;
        }

        // GET: api/managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> Get()
        {
            var managers = await _service.GetAllAsync();
            if(managers == null)
                return NotFound();
            return Ok(managers);
        }

        // GET: api/managers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> Get(int id)
        {
            var manager = await _service.GetByIdAsync(id);

            if (manager == null)
            {
                return NotFound();
            }

            return Ok(manager);
        }

        // PUT: api/managers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Manager manager)
        {
            if (id != manager.Id)
            {
                return BadRequest();
            }

            var updatedManager = await _service.UpdateAsync(id, manager);
            if(updatedManager == null)
                return BadRequest();
            return Ok(updatedManager);
        }

        // POST: api/managers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manager>> Post(Manager manager)
        {
            var id = _service.AddAsync(manager);
            return CreatedAtAction("Get", new { id }, id);
        }

        [HttpGet("{id}/teachers")]
        public async Task<IActionResult> GetTeachersByParameters(int id)
        {
            var managers = await _service.GetTeachersByParametersAsync(id);
            if (managers == null)
                return NotFound();
            return Ok(managers);
        }
    }
}
