import { useEffect, useState } from "react";

export function useFetch<T>(url: string) {
  const [data, setData] = useState<T | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | "">("");

  useEffect(() => {
    setLoading(true);
    fetch(url)
      .then((res) => {
        if (!res.ok) {
          setError(`HTTP error! status: ${res.status}`);
          return;
        }
        return res.json();
      })
      .then((data) => { setData(data); })
      .catch((err) => {
          setError(err.message);

      })
      .finally(() => { setLoading(false); });

  }, [url]);

  return { data, loading, error };
}