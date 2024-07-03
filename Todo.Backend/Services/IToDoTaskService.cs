using Todo.Backend.DTOs;

namespace Todo.Backend.Services;

public interface IToDoTaskService 
{
    Task<CreateToDoTaskResponseDTO> CreateTask(CreateToDoTaskRequestDTO requestDto);
    Task<List<ListToDoTaskResponseDTO>> GetAllTasks();
    Task<UpdateDescriptionToDoTaskResponseDTO> UpdateDescription(UpdateDescriptionToDoTaskRequestDTO request);
    Task<UpdateStatusToDoTaskResponseDTO> UpdateStatus(UpdateStatusToDoTaskRequestDTO requestDto);
    Task DeleteTask(DeleteToDoTaskRequestDTO requestDto);
}
