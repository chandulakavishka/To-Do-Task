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
            var items = await _taskService.GetLatestAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _taskService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TaskItem item)
        {
            var newItem = await _taskService.AddAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}/done")]
        public async Task<IActionResult> MarkAsDone(int id)
        {
            var success = await _taskService.MarkAsDoneAsync(id);
            if (!success) return NotFound();
            return Ok(new { message = "Task marked as done." });
        }
    }
}
