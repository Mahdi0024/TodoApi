using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoApi.Dtos;
using TodoApi.Services.Contracts;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public sealed class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid todoId)
    {
        return Ok(await _todoService.GetTodo(todoId));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid todoId)
    {
        await _todoService.DeleteTodo(todoId);
        return Ok(new
        {
            Success = true,
            StatusCode = HttpStatusCode.OK
        });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTitle(UpdateTitleRequest request)
    {
        return Ok(await _todoService.UpdateTodoTitle(request.Id, request.Title));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStatus(UpdateTodoStatusRequest request)
    {
        return Ok(await _todoService.UpdateTodoStatus(request.Id, request.IsDone));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoRequest request)
    {
        return Ok(await _todoService.CreateTodo(request.BoardId, request.Title));
    }
}