import { useEffect, useState } from "react";
import { getTasks, createTask, toggleTask, deleteTask } from "./services/api";
import './App.css';

function App() {
  const [tasks, setTasks] = useState([]);
  const [title, setTitle] = useState("");

  async function loadTasks() {
    const data = await getTasks();
    setTasks(data);
  }

  useEffect(() => {
    loadTasks();
  }, []);

  async function handleAdd() {
    if (!title.trim()) return;

    await createTask(title);
    setTitle("");
    loadTasks();
  }

  async function handleToggle(id) {
    await toggleTask(id);
    loadTasks();
  }

  async function handleDelete(id) {
    await deleteTask(id);
    loadTasks();
  }
  
  return (
    <div className="container">
      <h1>Ezra Task App</h1>
      
      <div className="input-group">
        <input 
          type="text" 
          value={title} 
          onChange={(e) => setTitle(e.target.value)} 
          placeholder="Add a new task..." 
        />
        <button className="add-btn" onClick={handleAdd}>
          Add
        </button>
      </div>

      <ul>
        {tasks.map(task => (
          <li key={task.id}>
            <span 
              className={`task-text ${task.isCompleted ? 'completed' : ''}`}
              onClick={() => handleToggle(task.id)}
            >
              {task.title}
            </span>
            <button className="delete-btn" onClick={() => handleDelete(task.id)}>
              Delete
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;