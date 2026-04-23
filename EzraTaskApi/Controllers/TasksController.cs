using Microsoft.AspNetCore.Mvc;
using EzraTaskApi.Services.Interfaces;
using EzraTaskApi.DTOs;

namespace EzraTaskApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public ActionResult<List<TaskResponse>> GetAll()
    {
        return Ok(_taskService.GetAllTasks());
    }

    [HttpPost]
    public ActionResult<TaskResponse> Create(CreateTaskRequest request)
    {
        var task = _taskService.CreateTask(request);
        return Ok(task);
    }

    [HttpPut("{id}")]
    public ActionResult<TaskResponse> Toggle(int id)
    {
        var task = _taskService.ToggleTask(id);

        if (task == null) return NotFound();

        return Ok(task);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = _taskService.DeleteTask(id);

        if (!success) return NotFound();

        return NoContent();
    }
}