using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Todo.Backend.Context;
using Todo.Backend.DTOs;
using Todo.Backend.Models;

namespace Todo.Backend.Repositories;

public class ToDoTaskRepository : ToDoTaskRepositoryInterface
{
    private readonly TodoDbContext _todoDbContext;
    private readonly ToDoTaskRepositoryInterface _taskRepositoryInterface;

    public ToDoTaskRepository(TodoDbContext todoDbContext, ToDoTaskRepositoryInterface taskRepositoryInterface)
    {
        _todoDbContext = todoDbContext;
        _taskRepositoryInterface = taskRepositoryInterface;         
    }

    public async Task AddTask(ToDoTask newTask)
    {
        _todoDbContext.ToDoTask.Add(newTask);
        await _todoDbContext.SaveChangesAsync();
    }

    public async Task<List<ToDoTask>> GetAll()
    {
        List<ToDoTask> tasks = _todoDbContext.ToDoTask.ToList();

        return tasks;
    }
}
