namespace Core_API.Models
{
  public class PlaceholderCommentModel
  {
    public int PostId { get; set; }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
  }
}
