import { useFetch } from '../Fetchs/useFetch'

function ToDoListComponent() {
  const { data, loading, error } = useFetch("http://localhost:5000/Placeholder/GetAllToDos");

  return (
    <div className="card">
      <ul>
        {loading && <li>Loading...</li>}
        {error && <li>Error: {error}</li>}
        {data && data.map((todo) => (
          <li key={todo.id}>{todo.title}</li>
        ))}
      </ul>
    </div>
  );
}

export default ToDoListComponent;