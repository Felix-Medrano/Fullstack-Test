import { useFetch } from "../../../Fetchs/useFetch";
import "./UserComponent.css";

  function UserComponent() {
    const { data, loading, error } = useFetch("http://localhost:5000/Placeholder/GetAllUsers");

    return (
      <div className="container">
        <h2>Posts</h2>
        <div className="card">
          <ul>
            {loading && <li>Loading...</li>}
            {error && <li>Error: {error}</li>}
            {data && data.map((post) => (
              <li key={post.id}>
                <h3>{post.name}</h3>
                <p>{post.userName}</p>
                <p>{post.email}</p>
              </li>
            ))}
          </ul>
        </div>
      </div>
    );
  };

  export default UserComponent;
  