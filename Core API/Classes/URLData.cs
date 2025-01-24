namespace Core_API.Classes
{
  public class URLData
  {
    private readonly string _baseUrl = "https://jsonplaceholder.typicode.com";

    public string PostsUrl => $"{_baseUrl}/posts";
    public string CommentsUrl => $"{_baseUrl}/comments";
    public string AlbumsUrl => $"{_baseUrl}/albums";
    public string PhotosUrl => $"{_baseUrl}/photos";
    public string ToDosUrl => $"{_baseUrl}/todos";
    public string UsersUrl => $"{_baseUrl}/users";
  }
}
