using Microsoft.EntityFrameworkCore;
using Todo.Backend.Models;

namespace Todo.Backend.Context;

public class TodoDbContext  : DbContext
{
    public TodoDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<ToDoTask> ToDoTask { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // Configuração da tabela ToDoTask
        mb.Entity<ToDoTask>(entity =>
        {
            entity.ToTable("todoTasks");
            
            entity.HasKey(e => e.idTask);
            
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(30);
            
            entity.Property(e => e.Completed)
                .HasDefaultValue(false);
        });
    }
}