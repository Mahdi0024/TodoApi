using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoApi.Dtos;
using TodoApi.Services.Contracts;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public sealed class BoardController : ControllerBase
{
    private readonly ITodoService _todoService;

    public BoardController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _todoService.GetBoards());
    }

    [HttpGet]
    public async Task<IActionResult> Get(GetBoardRequest request)
    {
        return Ok(await _todoService.GetBoard(request.Id, request.IncludeTodos));
    }

    [HttpGet]
    public async Task<IActionResult> GetUndone(Guid boardId)
    {
        return Ok(await _todoService.GetBoardUndoneTodos(boardId));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBoardRequest request)
    {
        return Ok(await _todoService.CreateBoard(request.Title));
    }

    [HttpPut]
    public async Task<IActionResult> Rename([FromBody] UpdateTitleRequest request)
    {
        return Ok(await _todoService.EditBoardTitle(request.Id, request.Title));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid boardId)
    {
        await _todoService.DeleteBoard(boardId);
        return Ok(new
        {
            Success = true,
            StatusCode = HttpStatusCode.OK
        });
    }
}