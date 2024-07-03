using System.Reflection.Metadata.Ecma335;

namespace Todo.Backend.DTOs;

public class UpdateDescriptionToDoTaskResponseDTO
{
    public int IdTask { get; set; }
    public string Description { get; set; }
}
