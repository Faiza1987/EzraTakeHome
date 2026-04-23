import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import App from './App';
import * as api from './services/api';

jest.mock('./services/api');

describe('Ezra Task App Frontend', () => {
  const mockTasks = [
    { id: 1, title: 'Learn .NET Core', isCompleted: false },
    { id: 2, title: 'Build React UI', isCompleted: true },
  ];

  beforeEach(() => {
    jest.clearAllMocks();
    api.getTasks.mockResolvedValue(mockTasks);
  });

  test('renders the task list from the API', async () => {
    render(<App />);
    
    expect(screen.getByText(/Ezra Task App/i)).toBeInTheDocument();

    const task1 = await screen.findByText('Learn .NET Core');
    const task2 = await screen.findByText('Build React UI');

    expect(task1).toBeInTheDocument();
    expect(task2).toBeInTheDocument();
  });

test('adds a new task through the input and button', async () => {
    api.createTask.mockResolvedValue({ id: 3, title: 'New Task', isCompleted: false });
    render(<App />);

    const input = screen.getByPlaceholderText(/New task/i);
    const addButton = screen.getByText(/Add/i);

    fireEvent.change(input, { target: { value: 'New Task' } });
    fireEvent.click(addButton);

    await waitFor(() => {
      expect(api.createTask).toHaveBeenCalledWith('New Task');
    });
    
    await waitFor(() => {
      expect(input.value).toBe('');
    });
  });

  test('applies correct styling to completed tasks', async () => {
    render(<App />);

    const completedTask = await screen.findByText('Build React UI');
    
    expect(completedTask).toHaveStyle('text-decoration: line-through');
  });
});