using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var items = await _taskService.GetAllAsync();
        //    return Ok(items);
        //}

        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            try
            {
                var items = await _taskService.GetLatestAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while geting data.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var item = await _taskService.GetByIdAsync(id);
                if (item == null) return NotFound();
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while geting data..", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TaskItem item)
        {
            try {
                if (item == null)
                    return BadRequest(new { message = "Invalid data." });

                item.Id = 0;
                item.CreatedAt = DateTime.UtcNow;

                var newItem = await _taskService.AddAsync(item);
                return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the data.", error = ex.Message });
            }
        }

        [HttpPut("{id}/done")]
        public async Task<IActionResult> MarkAsDone(int id)
        {
            try
            {
                var success = await _taskService.MarkAsDoneAsync(id);
                if (!success) return NotFound();
                return Ok(new { message = "Task marked as done." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while marking the task as done.", error = ex.Message });
            }
        }
    }
}
