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
    private readonly IToDoTaskService _iToDoTaskService;

    public ToDoTaskController(IToDoTaskService itoDoTaskService)
    {
        _iToDoTaskService = itoDoTaskService; 
    }


    [HttpPost]
    public async Task<ActionResult> Create(CreateToDoTaskRequestDTO requestDto)
    {
        return Ok(await _iToDoTaskService.CreateTask(requestDto));
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _iToDoTaskService.GetAllTasks());
    }

    [HttpPut("Description")]
    public async Task<ActionResult> UpdateDescription(UpdateDescriptionToDoTaskRequestDTO request)
    {
        return Ok(await _iToDoTaskService.UpdateDescription(request));
    }

    [HttpPut("Status")]
    public async Task<ActionResult> UpdateStatus(UpdateStatusToDoTaskRequestDTO requestDto)
    {
        return Ok(await _iToDoTaskService.UpdateStatus(requestDto));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(DeleteToDoTaskRequestDTO requestDto)
    {
        await _iToDoTaskService.DeleteTask(requestDto);

        return Ok();
    }
}
