# 📝 Ezra Task Manager

A production-minded Task Management MVP built with a focus on **Clean Architecture** and **Operational Readiness**.

### 🏗️ Architecture & Decisions
* [cite_start]**N-Tier Design**: Separated into API, Service, and Data layers to ensure high testability and maintainable business logic[cite: 21, 47, 67].
* [cite_start]**Dependency Injection**: Decoupled the Service layer via interfaces (`ITaskService`) for easy mocking and future scalability[cite: 21, 67].
* [cite_start]**Global Exception Handling**: Implemented custom Middleware to catch unhandled errors and return consistent JSON responses—a critical "production-ready" feature[cite: 23, 49].

### ⚖️ Trade-offs & Future Work
* [cite_start]**In-Memory Store**: Used EF Core In-Memory for portability; would transition to a persistent store like **PostgreSQL** or **SQL Server** for a production environment[cite: 64, 68].
* [cite_start]**State Management**: Utilized React Hooks for this MVP; would scale to **React Query** or **Redux** for more complex data synchronization[cite: 65, 68].
* [cite_start]**Future Scalability**: Potential additions include Pagination, Soft Deletes, and SignalR for real-time updates[cite: 70, 71].

### 🚀 Setup
**1. Backend (.NET 10)**
```bash
cd EzraTaskApi
dotnet run
