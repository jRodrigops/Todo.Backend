using Microsoft.EntityFrameworkCore;
using Todo.Backend.Models;

namespace Todo.Backend.Context;

public class TodoDbContext  : DbContext
{
    public TodoDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<ToDoTask> ToDoTask { get; set; }
}