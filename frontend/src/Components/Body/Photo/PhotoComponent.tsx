import { useFetch } from "../../../Fetchs/useFetch";
import "./PhotoComponent.css";

function PhotoComponent() {
  const { data, loading, error } = useFetch("http://localhost:5000/Placeholder/GetAllPhotos");

  return (
    <div className="container">
      <h2>Posts</h2>
      <div className="card">
        <ul>
          {loading && <li>Loading...</li>}
          {error && <li>Error: {error}</li>}
          {data && data.map((post) => (
            <li key={post.id}>
              <h3>{post.title}</h3>
              <p>{post.url}</p>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}

export default PhotoComponent;
  