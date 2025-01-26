import { useFetch } from "../../Fetchs/useFetch";

export function useAlbumById(id: number | string) {
  const { data, loading, error } = useFetch(`http://localhost:5000/Placeholder/GetAlbumById/${id}`);
  return { data, loading, error };
}