import { useFetch } from "../../Fetchs/useFetch";

export function useAlbumsByUser(userId: number | string) {
  const { data, loading, error } = useFetch(`http://localhost:5000/Placeholder/GetAlbumsByUserId/${userId}`);
  return { data, loading, error };
}