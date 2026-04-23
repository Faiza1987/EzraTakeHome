# 📝 Ezra Task Manager

A production-minded Task Management MVP built with a focus on **Clean Architecture** and **Operational Readiness**.

### 🏗️ Architecture & Decisions
* **N-Tier Design**: Separated into API, Service, and Data layers to ensure high testability and maintainable business logic.
* **Dependency Injection**: Decoupled the Service layer via interfaces (`ITaskService`) for easy mocking and future scalability.
* **Global Exception Handling**: Implemented custom Middleware to catch unhandled errors and return consistent JSON responses—a critical "production-ready" feature.

### 🎨 Frontend Design
* **Modern SaaS Aesthetic**: Implemented a centered, card-based layout with a clean typography stack (Inter) to provide a professional user experience.
* **Component-Driven State**: Utilized React Functional Components and Hooks for predictable state management of the task list.
* **UX Details**: Added subtle hover states and dynamic visibility for administrative actions (like the delete button) to keep the interface focused and clutter-free.

### ⚖️ Trade-offs & Future Work
* **In-Memory Store**: Used EF Core In-Memory for portability; would transition to a persistent store like **PostgreSQL** or **SQL Server** for a production environment.
* **State Management**: Utilized React Hooks for this MVP; would scale to **React Query** or **Redux** for more complex data synchronization.
* **Future Scalability**: Potential additions include Pagination, Soft Deletes, and SignalR for real-time updates.

### 🚀 Setup
**1. Backend (.NET 10)**
```bash
cd EzraTaskApi
dotnet run
