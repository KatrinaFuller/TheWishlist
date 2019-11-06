using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using TheWistlist.Models;

namespace TheWistlist.Repositories
{
  public class ListWishesRepository
  {
    private readonly IDbConnection _db;
    public ListWishesRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Wish> GetListWishesByListId(int listId, string userId)
    {
      string sql = @"
      SELECT * FROM listwishes lw
      INNER JOIN wishes w ON w.id = lw.wishId
      WHERE(listId = @listId AND lw.userId = @userId)";
      return _db.Query<Wish>(sql, new { listId, userId });
    }

    public void CreateListWish(int ListId, int WishId, string userId)
    {
      string sql = @"
      INSERT INTO listwishes
      (listId, wishId, userId)
      VALUES
      (@ListId, @WishId, @UserId)";
      _db.Execute(sql, new { ListId, WishId, userId });
    }

    public ListWish GetListWishByListIdWishIdAndUserId(ListWish lWish)
    {
      string sql = "SELECT * FROM listwishes WHERE wishId = @wishId AND listId = @listId";
      return _db.QueryFirstOrDefault<ListWish>(sql, lWish);
    }

    public void RemoveListWish(int id)
    {
      string sql = "DELETE FROM listwishes WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}