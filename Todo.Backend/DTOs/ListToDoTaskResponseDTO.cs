﻿namespace Todo.Backend.DTOs;

public class ListToDoTaskResponseDTO
{
    public int IdTask { get; set; }
    public string Description { get; set; }

    public bool Completed { get; set; }
}
