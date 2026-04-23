using EzraTaskApi.DTOs;

namespace EzraTaskApi.Services.Interfaces;

public interface ITaskService
{
    List<TaskResponse> GetAllTasks();
    TaskResponse CreateTask(CreateTaskRequest request);
    TaskResponse? ToggleTask(int id);
    bool DeleteTask(int id);
}