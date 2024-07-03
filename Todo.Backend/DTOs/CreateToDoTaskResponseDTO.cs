namespace Todo.Backend.DTOs;

public class CreateToDoTaskResponseDTO
{
    public int idTask{ get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
}
