import { useEffect, useState } from "react";

export function useFetch<T>(url: string) {
  const [data, setData] = useState<T | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const abortController = new AbortController();
    setLoading(true);
    fetch(url, { signal: abortController.signal })
      .then((res) => {
        if (!res.ok) {
          setError(`HTTP error! status: ${res.status}`);
          return;
        }
        return res.json();
      })
      .then((data) => { setData(data); })
      .catch((err) => {
        if (err.name === "AbortError") {
          console.log("Request was cancelled")
        }
        else {
          setError(err.message);
        }
      })
      .finally(() => { setLoading(false); });

    return () => abortController.abort();
  }, [url]);

  return { data, loading, error };
}