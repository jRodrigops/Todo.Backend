using AutoMapper;
using System.Runtime.CompilerServices;
using Todo.Backend.Context;
using Todo.Backend.DTOs;
using Todo.Backend.Models;
using Todo.Backend.Repositories;
using Todo.Backend.TreatmentException;

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
            throw new TreatedException("Bad Request", StatusCodes.Status400BadRequest, "o campo de descrição passou de 30 caracteres");
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

    public async Task<UpdateDescriptionToDoTaskResponseDTO> UpdateDescription(UpdateDescriptionToDoTaskRequestDTO request, int id)
    {
        ToDoTask? toDoTask = await _taskRepository.GetById(id);

        if(toDoTask == null)
        {
            throw new TreatedException("Not Found", StatusCodes.Status404NotFound, "Esta task nao foi encontrada");
        }
        if(toDoTask.Completed == true)
        {
            throw new TreatedException("Bad Request", StatusCodes.Status400BadRequest, "Task ja completada não pode ser alterada");
        }
        
        toDoTask.Description = request.Description;

        _todoDbContext.SaveChanges();

        UpdateDescriptionToDoTaskResponseDTO updateDescriptionToDoTaskResponse = _mapper.Map<UpdateDescriptionToDoTaskResponseDTO>(toDoTask);

        return updateDescriptionToDoTaskResponse;
    }
    
    public async Task<UpdateStatusToDoTaskResponseDTO> UpdateStatus(int id)
    {
        ToDoTask? toDoTask = await _taskRepository.GetById(id);

        if (toDoTask == null)
        {
            throw new TreatedException("Not Found", StatusCodes.Status404NotFound, "Esta task nao foi encontrada");
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

    public async Task DeleteTask(int id)
    {
        ToDoTask? toDoTask = await _taskRepository.GetById(id);

        if (toDoTask == null)
        {
            throw new TreatedException("Not Found", StatusCodes.Status404NotFound, "Esta task nao foi encontrada");
        }

        _todoDbContext.Remove(toDoTask);
        _todoDbContext.SaveChanges();
    }
}
