using Xunit;
using Microsoft.EntityFrameworkCore;
using EzraTaskApi.Services;
using EzraTaskApi.Data;
using EzraTaskApi.DTOs;
using Microsoft.Extensions.Logging.Abstractions;

namespace EzraTaskApi.Tests;

public class TaskServiceTests
{
    private TaskService GetService()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new AppDbContext(options);
        
        return new TaskService(context, new NullLogger<TaskService>());
    }

    [Fact]
    public void CreateTask_ValidTitle_ReturnsTaskResponse()
    {
        // Arrange
        var service = GetService();
        var request = new CreateTaskRequest { Title = "Test Ezra App" };

        // Act
        var result = service.CreateTask(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Ezra App", result.Title);
        Assert.False(result.IsCompleted); // Logic check: New tasks should be incomplete
    }

    [Fact]
    public void CreateTask_EmptyTitle_ThrowsArgumentException()
    {
        // Arrange
        var service = GetService();
        var request = new CreateTaskRequest { Title = "" };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => service.CreateTask(request));
    }

    [Fact]
    public void ToggleTask_ExistingId_FlipsStatus()
    {
        // Arrange
        var service = GetService();
        var task = service.CreateTask(new CreateTaskRequest { Title = "Toggle Test" });

        // Act
        var updated = service.ToggleTask(task.Id);

        // Assert
        Assert.True(updated!.IsCompleted);
    }

    [Fact]
    public void DeleteTask_ExistingId_ReturnsTrue()
    {
        // Arrange
        var service = GetService();
        var task = service.CreateTask(new CreateTaskRequest { Title = "Delete Test" });

        // Act
        var result = service.DeleteTask(task.Id);

        // Assert
        Assert.True(result);
        Assert.Empty(service.GetAllTasks());
    }
}