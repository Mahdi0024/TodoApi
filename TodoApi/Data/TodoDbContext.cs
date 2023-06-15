using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data;

public sealed class TodoDbContext : DbContext
{
    public DbSet<Board> Boards { get; set; }
    public DbSet<Todo> Todos { get; set; }

    public TodoDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Board>().HasKey(b => b.Id);
        modelBuilder.Entity<Todo>().HasKey(t => t.Id);
    }
}