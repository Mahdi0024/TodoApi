using TodoApi.Models;

namespace TodoApi.Services.Contracts;

public interface ITodoService
{
    Task<Todo> GetTodo(Guid todoId);

    Task<Todo> CreateTodo(Guid boardId, string title);

    Task DeleteTodo(Guid todoId);

    Task<Todo> UpdateTodoTitle(Guid todoId, string title);

    Task<Todo> UpdateTodoStatus(Guid todoId, bool isDone);

    Task<Board> GetBoard(Guid boardId, bool includeTodos);

    Task<Board> CreateBoard(string name);

    Task DeleteBoard(Guid boardId);

    Task<IEnumerable<Board>> GetBoards();

    Task<Board> EditBoardTitle(Guid id, string name);

    Task<IEnumerable<Todo>> GetBoardUndoneTodos(Guid boardId);
}