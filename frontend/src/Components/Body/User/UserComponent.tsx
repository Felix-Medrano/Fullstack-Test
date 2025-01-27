import { useFetch } from "../../../Fetchs/useFetch";
import "./UserComponent.css";

  function UserComponent() {
    const { data, loading, error } = useFetch("http://localhost:5000/Placeholder/GetAllUsers");

    return (
      <div className="container">
        <h2 className="componentTitle">Users</h2>
        <div className="card">
          <ul>
            {loading && <li>Loading...</li>}
            {error && <li>Error: {error}</li>}
            {data && data.map((post) => (
              <li key={post.id} className="bottomMargin10">
                <h3 className="marginless">{post.name}</h3>
                <p className="marginless">{post.username}</p>
                <p className="marginless">{post.email}</p>
              </li>
            ))}
          </ul>
        </div>
      </div>
    );
  };

  export default UserComponent;
  