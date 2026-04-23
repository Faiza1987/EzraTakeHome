# Ezra Task Manager MVP

This is a full-stack task management system built with a focus on **Clean Architecture** and **N-Tier separation**. My goal was to create a solution that isn't just a "to-do list," but a blueprint for a production-ready service.

### 🏗️ Engineering Approach
* **Backend (.NET 10):** I organized the API into distinct layers (Controllers, Services, Data) to keep business logic isolated from infrastructure. I used Dependency Injection throughout to ensure the system is decoupled and easy to test.
* **Operational Readiness:** I implemented a custom Middleware to handle global exceptions. This ensures the API always returns a clean JSON response instead of a raw stack trace if something goes wrong.
* **Frontend (React):** I went with a component-driven approach and a clean, centered UI. The styles use CSS variables for easy theme management and Inter typography for a modern SaaS feel.

### 🎨 Frontend Details
* **User Experience:** I focused on a "less is more" interface. The delete actions are context-aware (appearing on hover), and I used a card-based layout to keep the task list focused and readable.
* **State Management:** Used React Hooks for lightweight, predictable state handling within the application.

### ⚖️ Trade-offs & Future Scaling
* **Persistence:** For this MVP, I used EF Core In-Memory to keep the setup portable. In a real-world scenario, I’d swap this for a persistent PostgreSQL or SQL Server instance using EF Migrations.
* **Data Fetching:** For a simple task list, standard hooks work well. As the data grows, I’d move toward **React Query** for better caching and synchronization.
* **Roadmap:** If I had more time, I’d implement soft deletes, user-based authentication, and SignalR for real-time list updates across different sessions.

### 🚀 How to Run
**1. Backend**
```bash
cd EzraTaskApi
dotnet run
