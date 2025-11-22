using AutoMapper;
using Todo.Backend.DTOs;
using Todo.Backend.Models;

namespace Todo.Backend.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<CreateToDoTaskRequestDTO, ToDoTask>()
            .ForMember(dest => dest.Completed, opt => opt.MapFrom(src => false));
        CreateMap<ToDoTask, CreateToDoTaskResponseDTO>();
        CreateMap<ToDoTask, ListToDoTaskResponseDTO>();
        CreateMap<UpdateDescriptionToDoTaskRequestDTO, ToDoTask>();
        CreateMap<ToDoTask, UpdateDescriptionToDoTaskResponseDTO>();
        CreateMap<UpdateStatusToDoTaskRequestDTO, ToDoTask>();
        CreateMap<ToDoTask, UpdateStatusToDoTaskResponseDTO>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Completed));
    }
}
