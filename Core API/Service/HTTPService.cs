using Newtonsoft.Json;

using System.Text;

namespace Core_API.Service
{
  public class HTTPService
  {
    private HttpClient httpClient;
    public HTTPService() { httpClient = new HttpClient(); }

    /// <summary>
    /// Envía una solicitud GET a la URL especificada y deserializa la respuesta en el tipo especificado.
    /// </summary>
    /// <typeparam name="T">El tipo en el que deserializar la respuesta.</typeparam>
    /// <param name="url">La URL a la que enviar la solicitud GET.</param>
    /// <returns>La respuesta deserializada.</returns>
    /// <exception cref="Exception">Lanzada si la solicitud GET falla.</exception>
    public async Task<T> GetAsync<T>(string url)
    {
      var response = await httpClient.GetAsync(url);

      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<T>(jsonResponse);
        return data;
      }
      else
      {
        throw new Exception("Failed to fetch users from the API.");
      }
    }

    /// <summary>
    /// Envía una solicitud POST a la URL especificada con los datos especificados y deserializa la respuesta en el tipo especificado.
    /// </summary>
    /// <typeparam name="T">El tipo en el que deserializar la respuesta.</typeparam>
    /// <param name="url">La URL a la que enviar la solicitud POST.</param>
    /// <param name="data">Los datos a enviar en la solicitud POST.</param>
    /// <returns>La respuesta deserializada.</returns>
    /// <exception cref="Exception">Lanzada si la solicitud POST falla.</exception>
    public async Task<T> PostAsync<T>(string url, object data)
    {
      var jsonData = JsonConvert.SerializeObject(data);
      var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

      var response = await httpClient.PostAsync(url, content);

      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<T>(jsonResponse);
        return result;
      }
      else
      {
        throw new Exception("Failed to post data to the API.");
      }
    }

    /// <summary>
    /// Envía una solicitud PUT a la URL especificada con los datos especificados y deserializa la respuesta en el tipo especificado.
    /// </summary>
    /// <typeparam name="T">El tipo en el que deserializar la respuesta.</typeparam>
    /// <param name="url">La URL a la que enviar la solicitud PUT.</param>
    /// <param name="data">Los datos a enviar en la solicitud PUT.</param>
    /// <returns>La respuesta deserializada.</returns>
    /// <exception cref="Exception">Lanzada si la solicitud PUT falla.</exception>
    public async Task<T> PutAsync<T>(string url, object data)
    {
      var jsonData = JsonConvert.SerializeObject(data);
      var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

      var request = new HttpRequestMessage(HttpMethod.Put, url)
      {
        Content = content
      };

      var response = await httpClient.SendAsync(request);

      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<T>(jsonResponse);
        return result;
      }
      else
      {
        throw new Exception("Failed to update data on the API.");
      }
    }

    /// <summary>
    /// Envía una solicitud PATCH a la URL especificada con los datos especificados y deserializa la respuesta en el tipo especificado.
    /// </summary>
    /// <typeparam name="T">El tipo en el que deserializar la respuesta.</typeparam>
    /// <param name="url">La URL a la que enviar la solicitud PATCH.</param>
    /// <param name="data">Los datos a enviar en la solicitud PATCH.</param>
    /// <returns>La respuesta deserializada.</returns>
    /// <exception cref="Exception">Lanzada si la solicitud PATCH falla.</exception>
    public async Task<T> PatchAsync<T>(string url, object data)
    {
      var jsonData = JsonConvert.SerializeObject(data);
      var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

      var request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
      {
        Content = content
      };

      var response = await httpClient.SendAsync(request);

      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<T>(jsonResponse);
        return result;
      }
      else
      {
        throw new Exception("Failed to patch data on the API.");
      }
    }

    /// <summary>
    /// Envía una solicitud DELETE a la URL especificada.
    /// </summary>
    /// <param name="url">La URL a la que enviar la solicitud DELETE.</param>
    /// <exception cref="Exception">Lanzada si la solicitud DELETE falla.</exception>
    public async Task DeleteAsync(string url)
    {
      var response = await httpClient.DeleteAsync(url);

      if (!response.IsSuccessStatusCode)
      {
        throw new Exception("Failed to delete data from the API.");
      }
    }
  }
}
