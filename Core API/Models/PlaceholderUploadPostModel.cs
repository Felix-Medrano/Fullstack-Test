namespace Core_API.Models
{
  public class PlaceholderUploadPostModel
  {
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
  }
}
