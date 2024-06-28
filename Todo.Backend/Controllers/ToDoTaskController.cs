using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Todo.Backend.DTOs;
using Todo.Backend.Models;
using Todo.Backend.Services;

namespace Todo.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoTaskController : ControllerBase
{
    private readonly ToDoTaskServiceInterface _iToDoTaskService;

    public ToDoTaskController(ToDoTaskServiceInterface itoDoTaskService)
    {
        _iToDoTaskService = itoDoTaskService; 
    }


    [HttpPost]
    public async Task<ActionResult> Create(CreateToDoTaskRequestDTO requestDto)
    {
        await _iToDoTaskService.CreateTask(requestDto);

        return Ok();
    }
}
