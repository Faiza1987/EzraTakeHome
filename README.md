# Ezra Task Manager

This project is a full-stack Task Management MVP built with a focus on **Clean Architecture** and **Operational Readiness**. My goal was to demonstrate a production-minded approach to a standard problem by prioritizing testability and professional error handling.

###  Approach
* **Backend (.NET 10):** I implemented an N-Tier architecture (API, Service, and Data layers). By using Dependency Injection and Service-level interfaces, I kept the business logic decoupled from the infrastructure, making the system easy to test and extend.
* **Operational Readiness:** I added custom Exception Middleware to ensure the API returns consistent, developer-friendly JSON responses instead of raw stack traces—a baseline requirement for any production-ready service.
* **Frontend (React):** I went with a modern, centered UI designed for clarity. I focused on clean typography (Inter) and a card-based layout to provide a professional SaaS aesthetic.

###  Frontend Details
* **UI/UX:** The interface is built to be "distraction-free," featuring subtle hover effects and dynamic visibility for administrative tasks like deleting items.
* **State Management:** I used React Functional Components and Hooks for lightweight, predictable state handling across the task list.

###  Trade-offs & Future Scaling
* **Persistence:** I used EF Core In-Memory for portability in this MVP. In a production environment, I would swap this for a persistent store like PostgreSQL using EF Migrations.
* **Data Flow:** For this scale, standard React hooks are sufficient. For a larger application, I’d integrate **React Query** to handle caching and server-state synchronization more efficiently.
* **Roadmap:** Future additions would include user authentication, soft deletes, and SignalR for real-time updates across clients.

###  Setup & Execution

To run the full application, you will need two terminal windows open (one for the Backend and one for the Frontend).

#### **1. Backend (API)**
From the root directory:
```bash
cd EzraTaskApi
dotnet run

The API typically starts at http://localhost:5250. You can verify it's running by checking the Swagger UI at /swagger.

2. Frontend (Web)
Open a second terminal window. From the root directory:

Bash
cd ezra-task-web
npm install
npm start
This will launch the React app at http://localhost:3000. The frontend is pre-configured to communicate with the .NET backend.
