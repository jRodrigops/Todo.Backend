using AutoMapper;
using System.Runtime.CompilerServices;
using Todo.Backend.DTOs;
using Todo.Backend.Models;
using Todo.Backend.Repositories;

namespace Todo.Backend.Services;

public class ToDoTaskService : ToDoTaskServiceInterface
{
    private readonly ToDoTaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public ToDoTaskService(IMapper mapper, ToDoTaskRepository taskRepository)
    {
        _mapper = mapper;       
        _taskRepository = taskRepository;       
    }

    public async Task CreateTask(CreateToDoTaskRequestDTO requestDto)
    {
        var newTask =  _mapper.Map<ToDoTask>(requestDto);

        await _taskRepository.AddTask(newTask);
    }

    public async Task<List<ListToDoTaskResponseDTO>> GetAllTasks()
    {
        List<ToDoTask> lisTasks = await _taskRepository.GetAll();

        List<ListToDoTaskResponseDTO> listTaskResponseDTOs =  _mapper.Map<List<ListToDoTaskResponseDTO>>(lisTasks);

        return listTaskResponseDTOs;
    }
}
