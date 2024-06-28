using AutoMapper;
using Todo.Backend.DTOs;

namespace Todo.Backend.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<Task, CreateToDoTaskRequestDTO>();
        CreateMap<Task, CreateToDoTaskResponseDTO>();
        CreateMap<Task, ListToDoTaskResponseDTO>();
    }
}
