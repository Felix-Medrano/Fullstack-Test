import { useFetch } from "../../Fetchs/useFetch";

export function useAlbums() {
  const { data, loading, error } = useFetch("http://localhost:5000/Placeholder/GetAllAlbums");
  return { data, loading, error };
}