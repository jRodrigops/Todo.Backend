using AutoMapper;
using Todo.Backend.DTOs;
using Todo.Backend.Models;

namespace Todo.Backend.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<CreateToDoTaskRequestDTO, ToDoTask>();
        CreateMap<ToDoTask, CreateToDoTaskResponseDTO>();
        CreateMap<ToDoTask, ListToDoTaskResponseDTO>();
        CreateMap<UpdateDescriptionToDoTaskRequestDTO, ToDoTask>();
        CreateMap<ToDoTask, UpdateDescriptionToDoTaskResponseDTO>();
        CreateMap<UpdateStatusToDoTaskRequestDTO, ToDoTask>();
        CreateMap<ToDoTask, UpdateStatusToDoTaskResponseDTO>();
    }
}
