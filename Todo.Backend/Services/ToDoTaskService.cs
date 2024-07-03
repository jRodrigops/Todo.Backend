using AutoMapper;
using System.Runtime.CompilerServices;
using Todo.Backend.Context;
using Todo.Backend.DTOs;
using Todo.Backend.Models;
using Todo.Backend.Repositories;

namespace Todo.Backend.Services;

public class ToDoTaskService : IToDoTaskService
{
    private readonly IToDoTaskRepository _taskRepository;
    private readonly IMapper _mapper;
    private readonly TodoDbContext _todoDbContext;

    public ToDoTaskService(IMapper mapper, IToDoTaskRepository taskRepository, TodoDbContext todoDbContext)
    {
        _mapper = mapper;       
        _taskRepository = taskRepository;       
        _todoDbContext = todoDbContext;     
    }

    public async Task<CreateToDoTaskResponseDTO> CreateTask(CreateToDoTaskRequestDTO requestDto)
    {
        if(requestDto.Description.Length > 30)
        {
            throw new Exception("o campo de descrição passou de 30 caracteres");
        }

        var newTask = _mapper.Map<ToDoTask>(requestDto);

        await _taskRepository.AddTask(newTask);

        CreateToDoTaskResponseDTO responseDto = _mapper.Map<CreateToDoTaskResponseDTO>(newTask);

        return responseDto;
    }

    public async Task<List<ListToDoTaskResponseDTO>> GetAllTasks()
    {
        List<ToDoTask> listTasks = await _taskRepository.GetAll();

        List<ListToDoTaskResponseDTO> listTaskResponseDTOs =  _mapper.Map<List<ListToDoTaskResponseDTO>>(listTasks);

        return listTaskResponseDTOs;
    }

    public async Task<UpdateDescriptionToDoTaskResponseDTO> UpdateDescription(UpdateDescriptionToDoTaskRequestDTO request)
    {
        ToDoTask? toDoTask = await _taskRepository.GetById(request.IdTask);

        if(toDoTask == null)
        {
            throw new Exception("Esta Task não Existe");
        }    

        toDoTask.Description = request.Description;

        _todoDbContext.SaveChanges();

        UpdateDescriptionToDoTaskResponseDTO updateDescriptionToDoTaskResponse = _mapper.Map<UpdateDescriptionToDoTaskResponseDTO>(toDoTask);

        return updateDescriptionToDoTaskResponse;
    }

    public async Task<UpdateStatusToDoTaskResponseDTO> UpdateStatus(UpdateStatusToDoTaskRequestDTO requestDto)
    {
        ToDoTask? toDoTask = await _taskRepository.GetById(requestDto.IdTask);

        if (toDoTask == null)
        {
            throw new Exception("Esta Task não Existe");
        }

        if (toDoTask.Completed == false)
        {
            toDoTask.Completed = true;
        }
        else
        {
            toDoTask.Completed = false;
        }
        
        _todoDbContext.SaveChanges();

        UpdateStatusToDoTaskResponseDTO responseDto = _mapper.Map<UpdateStatusToDoTaskResponseDTO>(toDoTask);

        return responseDto;
    }

    public async Task DeleteTask(DeleteToDoTaskRequestDTO requestDto)
    {
        ToDoTask? toDoTask = await _taskRepository.GetById(requestDto.idTask);

        if (toDoTask == null)
        {
           throw new Exception("Esta Task não Existe");
        }

        _todoDbContext.Remove(toDoTask);
        _todoDbContext.SaveChanges();
    }
}
