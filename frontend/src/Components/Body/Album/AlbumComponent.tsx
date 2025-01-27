import { useState } from "react";
import { useAlbums } from "../../../Hooks/Albums/useAlbum";
import { useAlbumById } from "../../../Hooks/Albums/useAlbumById";
import { useAlbumsByUser } from "../../../Hooks/Albums/useAlbumByUser";
import "./AlbumComponent.css";

function AlbumComponent() {
  const [searchType, setSearchType] = useState("All");
  const [inputValue, setInputValue] = useState("");
  const [error, setError] = useState("");
  const [currentLoading, setLoading] = useState(false);
  const [data, setData] = useState(null);
  const [showAlert, setShowAlert] = useState(false);

  const { data: albums, loading: albumsLoading, error: albumsError } = useAlbums();
  const { data: albumById, loading: albumLoading, error: albumError } = useAlbumById(inputValue);
  const { data: albumsByUser, loading: albumsUserLoading, error: albumsUserError } = useAlbumsByUser(inputValue);

  // Manejar el cambio del tipo de búsqueda
  const handleSearchTypeChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setSearchType(e.target.value);
    setInputValue("");
    setError("");
    setData(null);
    setShowAlert(false);
  };

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setInputValue(e.target.value);
    setShowAlert(false);
  };

  const handleInput = (e: React.FormEvent<HTMLInputElement>) => {
    const value = e.currentTarget.value;
    if (!/^[0-9]*$/.test(value)) {
      e.currentTarget.value = value.replace(/[^0-9]/g, "");
    }
  };

  const handleKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key === "Enter") {
      handleSearch();
    }
  };

  const handleSearch = () => {
    if (searchType !== "All" && inputValue.trim() === "") {
      setShowAlert(true);
      return;
    }

    setError("");
    setShowAlert(false);

    switch (searchType) {
      case "All":
        setData(albums);
        setLoading(albumsLoading);
        setError(albumsError || "");
        break;
      case "Id":
        setData(albumById ? [albumById] : []);
        setLoading(albumLoading);
        setError(albumError || "");
        break;
      case "User Id":
        setData(albumsByUser);
        setLoading(albumsUserLoading);
        setError(albumsUserError || "");
        break;
      default:
        setData(null);
        setLoading(false);
        setError("");
    }
  };

  return (
    <div className="container">
      <h2 className="componentTitle">Albums</h2>
      <div className="searchControls">
        <label htmlFor="searchType">Tipo de búsqueda:</label>

        {/* Combo Box */}
        <select id="searchType" value={searchType} onChange={handleSearchTypeChange}>
          <option value="All">Todos</option>
          <option value="Id">Id</option>
          <option value="User Id">User Id</option>
        </select>

        {/* Input */}
        {searchType !== "All" && (
          <input
            type="text"
            className="searchInput"
            value={inputValue}
            onChange={handleInputChange}
            onInput={handleInput}
            onKeyDown={handleKeyDown}
            placeholder={`Enter ${searchType}`}
          />
        )}

        {/* Botón de Búsqueda */}
        <button onClick={handleSearch} className="searchButton">
          Buscar
        </button>
      </div>

      {/* Alerta */}
      {showAlert && <p className="alert">Por favor, ingrese un valor en el campo de búsqueda.</p>}

      {/* Resultados */}
      <div className="card">
        <ul>
          {currentLoading && <li>Loading...</li>}
          {/* TODO: Handle error display properly */}
          {/* When using Id or Usier Id, an error is printed, followed by the correct information */}
          {/* {error && <li>Error: {error}</li>} */}
          {Array.isArray(data) ? (
            data.map((item) => (
              <li key={item.id}>
                <h3>{item.title}</h3>
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
}

export default AlbumComponent;