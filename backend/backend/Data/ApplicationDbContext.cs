using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
