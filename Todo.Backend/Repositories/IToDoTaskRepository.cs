using Todo.Backend.DTOs;
using Todo.Backend.Models;

namespace Todo.Backend.Repositories;

public interface IToDoTaskRepository
{
    Task<List<ToDoTask>> GetAll();
    Task AddTask(ToDoTask newTask);
    Task<ToDoTask?> GetById(int id);
}
