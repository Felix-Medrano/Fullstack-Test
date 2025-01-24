namespace Core_API.Models
{
  public class PlaceholderToDoModel
  {
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool Completed { get; set; }
  }
}
