import { Link } from "react-router-dom";
import './NavigationList.css';

function NavigationList() {
  return (
    <nav className="navigation">
      <ul>
        <li><Link to="/albums">Albums</Link></li>
        <li><Link to="/comments">Comments</Link></li>
        <li><Link to="/photos">Photos</Link></li>
        <li><Link to="/posts">Posts</Link></li>
        <li><Link to="/todos">ToDos</Link></li>
        <li><Link to="/users">Users</Link></li>
      </ul>
    </nav>
  );
}

export default NavigationList;