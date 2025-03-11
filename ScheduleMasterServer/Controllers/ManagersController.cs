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
using Org.BouncyCastle.Utilities;

namespace ScheduleMasterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerService _service;

        public ManagersController(IManagerService managerService)
        {
            _service = managerService;
        }

        // GET: api/<ManagersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> Get()
        {
            var managers = await _service.GetAllAsync();
            if(managers == null)
                return NotFound();
            return Ok(managers);
        }

        // GET: api/<ManagersController>/5
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

        // PUT: api/<ManagersController>/5
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

        // POST: api/<ManagersController>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manager>> Post(Manager manager)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.AddAsync(manager);
            if (id == 0)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        // GET: api/<ManagersController>/5/teachers
        [HttpGet("{id}/teachers")]
        public async Task<IActionResult> GetTeachersByParameters(int id, [FromQuery] string? firstName = null, [FromQuery] string? lastName = null,
            [FromQuery] string? mail = null, [FromQuery] string? subjects = null, [FromQuery] string? cellPhone = null, [FromQuery] string? telephone = null)
        {
            List<string> subjectsList = subjects == null && subjects?.Length > 0 ? null : subjects?.Split(',').ToList();
            var managers = await _service.GetTeachersByParametersAsync(id, firstName, lastName, mail, subjectsList, cellPhone, telephone);
            if (managers == null)
                return NotFound();
            return Ok(managers);
        }
    }
}
