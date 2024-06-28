using Todo.Backend.Models;

namespace Todo.Backend.Repositories;

public interface ToDoTaskRepositoryInterface
{
    Task<List<ToDoTask>> GetAll();
    Task AddTask(ToDoTask newTask);
}
