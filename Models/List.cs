using TheWistlist.Interfaces;

namespace TheWistlist.Models
{
  public class List : IList
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}