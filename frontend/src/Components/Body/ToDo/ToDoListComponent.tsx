import './ToDoListComponent.css'
import { useFetch } from '../../../Fetchs/useFetch'
import { useState } from 'react';

function ToDoListComponent() {
  const { data, loading, error } = useFetch("http://localhost:5000/Placeholder/GetAllToDos");

  // Estado para filtros
  const [filter, setFilter] = useState<"all" | "completed" | "not-completed">("all");
  const [searchText, setSearchText] = useState("");

  // Filtrar las tareas según el estado
  const filteredData = data
    ? data.filter((todo) => {
        if (filter === "completed") return todo.completed;
        if (filter === "not-completed") return !todo.completed;
        return true; // "all" muestra todas las tareas
      })
    : [];

  // Filtrar por texto de búsqueda
  const finalData = filteredData.filter((todo) =>
    todo.title.toLowerCase().includes(searchText.toLowerCase())
  );

  return (
    <div className="container">
      <h2 className="componentTitle">To Do List</h2>

      {/* Controles de filtro */}
      <div className="filter-controls">
        <select
          value={filter}
          onChange={(e) => setFilter(e.target.value as "all" | "completed" | "not-completed")}
        >
          <option value="all">All</option>
          <option value="completed">Completed</option>
          <option value="not-completed">Not Completed</option>
        </select>

        <input
          type="text"
          placeholder="Title..."
          value={searchText}
          onChange={(e) => setSearchText(e.target.value)}
        />
      </div>

      {/* Contenido principal */}
      <div className="card">
        {loading && <p>Loading...</p>}
        {error && <p>Error: {error}</p>}

        <div className="todo-grid">
          {finalData.length > 0 ? (
            finalData.map((todo) => (
              <div
                key={todo.id}
                className={`todo-item ${todo.completed ? "completed" : "not-completed"}`}
              >
                <h3 className="marginless">User ID: {todo.userId}</h3>
                <p className="marginless">ID: {todo.id}</p>
                <p className="marginless">Title: {todo.title}</p>
                <p className="marginless">
                  Completed: {todo.completed ? "Yes" : "No"}
                </p>
              </div>
            ))
          ) : (
            <p>No tasks found.</p>
          )}
        </div>
      </div>
    </div>
  );
}

export default ToDoListComponent;