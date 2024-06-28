using Todo.Backend.DTOs;

namespace Todo.Backend.Services;

public interface ToDoTaskServiceInterface 
{
    Task CreateTask(CreateToDoTaskRequestDTO requestDto);
    Task<List<ListToDoTaskResponseDTO>> GetAllTasks();
}
