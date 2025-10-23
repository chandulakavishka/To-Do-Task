using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace backend.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<TaskItem>> GetAllAsync()
        //{
        //    return await _context.TaskItems
        //        .OrderByDescending(x => x.CreatedAt)
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<TaskItem>> GetLatestAsync()
        {
            return await _context.TaskItems
                .Where(x => !x.IsCompleted)
                .OrderByDescending(x => x.CreatedAt)
                .Take(5)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.TaskItems.FindAsync(id);
        }

        public async Task<TaskItem> AddAsync(TaskItem item)
        {
            _context.TaskItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> MarkAsDoneAsync(int id)
        {
            var item = await _context.TaskItems.FindAsync(id);
            if (item == null) return false;

            item.IsCompleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
