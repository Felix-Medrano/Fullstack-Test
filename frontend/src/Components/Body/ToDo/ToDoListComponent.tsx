import './ToDoListComponent.css'
import { useFetch } from '../../../Fetchs/useFetch'

function ToDoListComponent() {
  const { data, loading, error, handleCancelRequest } = useFetch("http://localhost:5000/Placeholder/GetAllToDos");

  return (
    <div className="container">
      <h2>To Do List</h2>
      <button onClick={handleCancelRequest}>Cancel Request</button>
      <div className="card">
        {loading && <p>Loading...</p>}
        {error && <p>Error: {error}</p>}
        {data && data.map((todo) => (
          <div key={todo.id} className="todo-item">
            <p><strong>User ID:</strong> {todo.userId}</p>
            <p><strong>ID:</strong> {todo.id}</p>
            <p><strong>Title:</strong> {todo.title}</p>
            <p><strong>Completed:</strong> {todo.completed ? 'Yes' : 'No'}</p>
          </div>
        ))}
        {/*<ul>
          {loading && <li>Loading...</li>}
          {error && <li>Error: {error}</li>}
          {data && data.map((todo) => (
            <li key={todo.id}>{todo.title}</li>
          ))}
        </ul>*/}
      </div>
    </div>
  );
}

export default ToDoListComponent;