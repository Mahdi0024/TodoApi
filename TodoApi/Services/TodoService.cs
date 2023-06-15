using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Exeptions;
using TodoApi.Models;
using TodoApi.Services.Contracts;

namespace TodoApi.Services;

public sealed class TodoService : ITodoService
{
    private readonly TodoDbContext _db;

    public TodoService(TodoDbContext db)
    {
        _db = db;
    }

    public async Task<Board> CreateBoard(string name)
    {
        var duplicateTitleBoard = await _db.Boards.FirstOrDefaultAsync(b => b.Title == name);
        if (duplicateTitleBoard is not null)
        {
            throw new TodoException("The operation cannot proceed because requested title is duplicate.");
        }

        var borad = new Board()
        {
            Title = name,
        };
        await _db.Boards.AddAsync(borad);
        await _db.SaveChangesAsync();
        return borad;
    }

    public async Task<Todo> CreateTodo(Guid boardId, string title)
    {
        var board = await GetBoard(boardId);

        var duplicateTitleTodo = await _db.Todos.FirstOrDefaultAsync(t => t.BoardId == boardId && t.Title == title);
        if (duplicateTitleTodo is not null)
        {
            throw new TodoException("The operation cannot proceed because requested title is duplicate.");
        }

        var newTodo = new Todo()
        {
            Title = title,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        board.Todos.Add(newTodo);
        await _db.SaveChangesAsync();

        return newTodo;
    }

    public async Task<Todo> GetTodo(Guid todoId)
    {
        var todo = await _db.Todos.FindAsync(todoId);
        if (todo is null)
        {
            throw new TodoException("The requested todo does not exist.");
        }
        return todo;
    }

    public async Task DeleteTodo(Guid todoId)
    {
        var todo = await GetTodo(todoId);

        _db.Todos.Remove(todo);
        _db.SaveChanges();
    }

    public async Task DeleteBoard(Guid boardId)
    {
        var board = await GetBoard(boardId);

        _db.Boards.Remove(board);
        _db.SaveChanges();
    }

    public async Task<IEnumerable<Board>> GetBoards()
    {
        return await _db.Boards.Include(b => b.Todos).ToListAsync();
    }

    public async Task<Board> GetBoard(Guid boardId, bool includeTodos = false)
    {
        var query = _db.Boards.AsQueryable();
        if (includeTodos)
        {
            query = query.Include(b => b.Todos);
        }
        var board = await query.FirstOrDefaultAsync(b => b.Id == boardId);
        if (board is null)
        {
            throw new TodoException("The requested board does not exist.");
        }
        return board;
    }

    public async Task<Todo> UpdateTodoTitle(Guid todoId, string title)
    {
        var todo = await GetTodo(todoId);

        var duplicateTitleTodo = await _db.Todos.FirstOrDefaultAsync(t => t.BoardId == todo.BoardId && t.Title == title);
        if (duplicateTitleTodo is not null)
        {
            throw new TodoException("The operation cannot proceed because requested title is duplicate.");
        }

        todo.Title = title;
        todo.UpdatedAt = DateTime.Now;

        _db.Update(todo);
        await _db.SaveChangesAsync();

        return todo;
    }

    public async Task<Todo> UpdateTodoStatus(Guid todoId, bool isDone)
    {
        var todo = await GetTodo(todoId);
        todo.IsDone = isDone;
        todo.UpdatedAt = DateTime.Now;
        _db.Update(todo);
        await _db.SaveChangesAsync();
        return todo;
    }

    public async Task<Board> EditBoardTitle(Guid id, string title)
    {
        var duplicateTitleBoard = await _db.Boards.FirstOrDefaultAsync(b => b.Title == title);
        if (duplicateTitleBoard is not null)
        {
            throw new TodoException("The operation cannot proceed because requested title is duplicate.");
        }

        var board = await GetBoard(id);
        board.Title = title;
        _db.Update(board);
        await _db.SaveChangesAsync();
        return board;
    }

    public async Task<IEnumerable<Todo>> GetBoardUndoneTodos(Guid boardId)
    {
        var todos = await _db.Todos
            .Where(t => t.BoardId == boardId && t.IsDone == false)
            .ToListAsync();
        return todos;
    }
}