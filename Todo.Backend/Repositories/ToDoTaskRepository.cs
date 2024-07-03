using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Todo.Backend.Context;
using Todo.Backend.DTOs;
using Todo.Backend.Models;

namespace Todo.Backend.Repositories;

public class ToDoTaskRepository : IToDoTaskRepository
{
    private readonly TodoDbContext _todoDbContext;

    public ToDoTaskRepository(TodoDbContext todoDbContext)
    {
        _todoDbContext = todoDbContext;
    }

    public async Task AddTask(ToDoTask newTask)
    {
        _todoDbContext.Add(newTask);
        await _todoDbContext.SaveChangesAsync();
    }

    public async Task<List<ToDoTask>> GetAll()
    {
        List<ToDoTask> tasks = _todoDbContext.ToDoTask.ToList();

        return tasks;
    }

    public async Task<ToDoTask?> GetById(int id)
    {
        ToDoTask? todoTask = _todoDbContext.ToDoTask.Where(tdt => tdt.idTask == id).FirstOrDefault();

        return todoTask;
    }
}
