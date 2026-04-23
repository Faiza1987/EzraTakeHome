using EzraTaskApi.Data;
using EzraTaskApi.DTOs;
using EzraTaskApi.Models;
using EzraTaskApi.Services.Interfaces;
using Microsoft.Extensions.Logging; // Add this using statement

namespace EzraTaskApi.Services;

public class TaskService : ITaskService
{
    private readonly AppDbContext _context;
    private readonly ILogger<TaskService> _logger; // 1. Define the logger field

    // 2. Inject the logger through the constructor
    public TaskService(AppDbContext context, ILogger<TaskService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public List<TaskResponse> GetAllTasks()
    {
        return _context.Tasks
            .Select(t => new TaskResponse
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt
            })
            .ToList();
    }

    public TaskResponse CreateTask(CreateTaskRequest request)
    {
        // 3. Now _logger will work perfectly!
        _logger.LogInformation("Creating new task: {Title}", request.Title);
        
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Title is required");
        }

        var task = new TaskItem
        {
            Title = request.Title
        };

        _context.Tasks.Add(task);
        _context.SaveChanges();

        return new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt
        };
    }

    // ... ToggleTask and DeleteTask stay the same
    public TaskResponse? ToggleTask(int id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return null;

        task.IsCompleted = !task.IsCompleted;
        _context.SaveChanges();

        return new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt
        };
    }

    public bool DeleteTask(int id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;

        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return true;
    }
}