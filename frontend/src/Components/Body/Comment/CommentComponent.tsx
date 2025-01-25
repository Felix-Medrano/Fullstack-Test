import { useFetch } from "../../../Fetchs/useFetch";
import "./CommentComponent.css";

  function CommentComponent() {
    const { data, loading, error } = useFetch("http://localhost:5000/Placeholder/GetAllComments");

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
                <p>{post.body}</p>
              </li>
            ))}
          </ul>
        </div>
      </div>
    );
  };

  export default CommentComponent;
  