using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
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

    [HttpPost("Create")]
    public async Task<ActionResult> Create(CreateToDoTaskRequestDTO requestDto)
    {
        return Ok(await _iToDoTaskService.CreateTask(requestDto));
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _iToDoTaskService.GetAllTasks());
    }

    [HttpPut("Description")]
    public async Task<ActionResult> UpdateDescription(UpdateDescriptionToDoTaskRequestDTO request, int id)
    {
        return Ok(await _iToDoTaskService.UpdateDescription(request, id));
    }

    [HttpPut("Status")]
    public async Task<ActionResult> UpdateStatus(int id)
    {
        return Ok(await _iToDoTaskService.UpdateStatus(id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _iToDoTaskService.DeleteTask(id);

        return Ok();
    }
}
