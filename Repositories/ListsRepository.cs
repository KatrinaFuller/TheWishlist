using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using TheWistlist.Models;

namespace TheWistlist.Repositories
{
  public class ListsRepository
  {
    private readonly IDbConnection _db;
    public ListsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<List> GetListByUserId(string userId)
    {
      string sql = "SELECT * FROM lists WHERE userId = @userId";
      return _db.Query<List>(sql, new { userId });
    }

    public List GetListById(int id)
    {
      string sql = "SELECT * FROM lists WHERE id = @id";
      return _db.QueryFirstOrDefault<List>(sql, new { id });
    }

    public int CreateList(List newList)
    {
      string sql = @"
      INSERT INTO lists
      (name, description, userId)
      VALUES
      (@Name, @Description, @UserId)";
      return _db.ExecuteScalar<int>(sql, newList);
    }
    public void EditList(List list)
    {
      string sql = @"
      UPDATE lists
      SET
        name = @Name,
        description = @Description
      WHERE id = @id";
      _db.Execute(sql, list);
    }

    public void DeleteList(int id)
    {
      string sql = "DELETE FROM lists WHERE id = @id";
      _db.Execute(sql, new { id });
    }

  }
}