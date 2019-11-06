using System;
using System.Collections.Generic;
using TheWistlist.Models;

namespace TheWistlist.Repositories
{
  public class ListWishesRepository
  {
    internal IEnumerable<List> GetListWishesByListId(int listId, string userId)
    {
      throw new NotImplementedException();
    }

    internal void CreateListWish(int listId, int wishId, string userId)
    {
      throw new NotImplementedException();
    }

    internal ListWish GetListWishByListIdWishIdAndUserId(ListWish listWish)
    {
      throw new NotImplementedException();
    }

    internal void RemoveListWish(int id)
    {
      throw new NotImplementedException();
    }
  }
}