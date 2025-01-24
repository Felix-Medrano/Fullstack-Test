namespace Core_API.Models
{
  public class PlaceholderPhotoModel
  {
    public int AlbumId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
  }
}
