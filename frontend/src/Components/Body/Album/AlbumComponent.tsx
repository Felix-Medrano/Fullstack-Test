import { useEffect, useState } from "react";
import { useAlbums } from "../../../Hooks/Albums/useAlbum";
import { useAlbumById } from "../../../Hooks/Albums/useAlbumById";
import { useAlbumsByUser } from "../../../Hooks/Albums/useAlbumByUser";
import "./AlbumComponent.css";

function AlbumComponent() {
  //Estados para la seleccion e input
  const [searchType, setSearchType] = useState("All");
  const [inputValue, setInputValue] = useState("");
  const [error, setError] = useState("");
  const [currentLoading, setLoading] = useState(false);
  const [data, setData] = useState("");

  const { data: albums, loading: albumsLoading, error: albumsError } = useAlbums();
  const { data: albumById, loading: albumLoading, error: albumError } = useAlbumById(inputValue);
  const { data: albumsByUser, loading: albumsUserLoading, error: albumsUserError } = useAlbumsByUser(inputValue);

  // Log updates and errors
  useEffect(() => {
    console.log("Component updated");
    if (error) {
      console.log("Error received:", error);
    }
  }, [error, data, currentLoading]);

  // Manejar el cambio del combo box
  const handleSearchTypeChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setSearchType(e.target.value);
    setInputValue("");
    setError("");
    setData("");
  };

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setInputValue(e.target.value);
  };

  const handleSearch = () => {
    setError("");
    switch (searchType) {
      case "All":
        setData(albums); // Assuming albums is an array or null
        setLoading(albumsLoading);
        setError(albumsError);
        break;
      case "Id":
        setData(albumById ? [albumById] : []);
        setLoading(albumLoading);
        setError(albumError);
        break;
      case "User Id":
        setData(albumsByUser);
        setLoading(albumsUserLoading);
        setError(albumsUserError);
        break;
      default:
        setData("");
        setLoading(false);
        setError("");
    }
  };


  return (
    <div className="container">      
      {/* Combo Box */}
      <div className="search-controls">
        <label htmlFor="searchType">Tipo de busqueda: </label>
        <select
          id="searchType"
          value={searchType}
          onChange={handleSearchTypeChange}
        >
          <option value="All">Todos</option>
          <option value="Id">Id</option>
          <option value="User Id">User Id</option>
        </select>
        {searchType !== "All" && (
          <input
            type="text"
            className="search-input"
            value={inputValue}
            onChange={handleInputChange}
            placeholder={`Enter ${searchType}`}
          />
        )}
        <button onClick={handleSearch} className="search-button">
          <i className="fas fa-search">Buscar</i>
        </button>
      </div>
        
      <h2>Posts</h2>
      <div className="card">
        <ul>
          {currentLoading && <li>Loading...</li>}
          {/* TODO: Handle error display properly */}
          {/* When using Id or Usier Id, an error is printed, followed by the correct information */}
          {/* {error && <li>Error: {error}</li>} */}
          {Array.isArray(data) ? (
            data.map((data) => (
              <li key={data.id}>
                <h3>{data.title}</h3>
              </li>
            ))
          ) : (
            data && (
              <li key={data.id}>
                <h3>{data.title}</h3>
              </li>
            )
          )}
        </ul>
      </div>
    </div>
  );
};

export default AlbumComponent;
  