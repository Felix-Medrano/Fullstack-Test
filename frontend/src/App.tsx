import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Header from './Components/Header/Header';
import Album from './Components/Body/Album/AlbumComponent';
import Comment from './Components/Body/Comment/CommentComponent'
import Photo from './Components/Body/Photo/PhotoComponent'
import Post from './Components/Body/Post/PostComponent'
import ToDo from './Components/Body/ToDo/ToDoListComponent'
import User from './Components/Body/User/UserComponent'
import './App.css'

function App() {
  return (
    <Router>
      <div>
        {/* Renderizar el Header siempre */}
        <Header />

        {/* Configuración de rutas */}
        <Routes>
          <Route path="/" element={<h2>Bienvenido</h2>} />
          <Route path="/albums/" element={<Album />} />
          <Route path="/comments" element={<Comment />} />
          <Route path="/photos" element={<Photo />} />
          <Route path="/posts" element={<Post />} />
          <Route path="/todos" element={<ToDo />} />
          <Route path="/users" element={<User />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App
