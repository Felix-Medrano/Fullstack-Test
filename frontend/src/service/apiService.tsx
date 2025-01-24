import { Promise } from 'es6-promise';

const BASE_URL = "http://localhost:5049/Placeholder";

export const apiService = {
    get: async <T>(endpoint: string): Promise<T> => {
        const response = await fetch(`${BASE_URL}${endpoint}`);
        if (!response.ok) {
            throw new Error(`Error al obtener datos: ${response.statusText}`);
        }
        return response.json();
    },

    post: async <T, U>(endpoint: string, data: T): Promise<U> => {
        const response = await fetch(`${BASE_URL}${endpoint}`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data),
        });
        if (!response.ok) {
            throw new Error(`Error al crear datos: ${response.statusText}`);
        }
        return response.json();
    },

    put: async <T, U>(endpoint: string, data: T): Promise<U> => {
        const response = await fetch(`${BASE_URL}${endpoint}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data),
        });
        if (!response.ok) {
            throw new Error(`Error al actualizar datos: ${response.statusText}`);
        }
        return response.json();
    },

    delete: async (endpoint: string): Promise<void> => {
        const response = await fetch(`${BASE_URL}${endpoint}`, { method: "DELETE" });
        if (!response.ok) {
            throw new Error(`Error al eliminar datos: ${response.statusText}`);
        }
    },
};