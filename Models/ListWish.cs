using TheWistlist.Interfaces;

namespace TheWistlist.Models
{
  public class ListWish : IListWish
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public int WishId { get; set; }
    public int ListId { get; set; }
  }
}