const BASE_URL = "http://localhost:5250/api/tasks";

export async function getTasks() {
  const res = await fetch(BASE_URL);
  return res.json();
}

export async function createTask(title) {
  const res = await fetch(BASE_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({ title })
  });

  return res.json();
}

export async function toggleTask(id) {
  const res = await fetch(`${BASE_URL}/${id}`, {
    method: "PUT"
  });

  return res.json();
}

export async function deleteTask(id) {
  await fetch(`${BASE_URL}/${id}`, {
    method: "DELETE"
  });
}