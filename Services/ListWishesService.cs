using System;
using System.Collections.Generic;
using TheWistlist.Models;
using TheWistlist.Repositories;

namespace TheWistlist.Services
{
  public class ListWishesService
  {
    public readonly ListWishesRepository _repo;
    public readonly ListsRepository _lrepo;
    public readonly WishesRepository _wrepo;
    public ListWishesService(ListWishesRepository repo, ListsRepository lrepo, WishesRepository wrepo)
    {
      _repo = repo;
      _lrepo = lrepo;
      _wrepo = wrepo;
    }
    public IEnumerable<Wish> GetListWishesByListId(int listId, string userId)
    {
      return _repo.GetListWishesByListId(listId, userId);
    }

    public string CreateListWish(ListWish newListWish)
    {
      List list = _lrepo.GetListById(newListWish.ListId);
      if (list == null)
      {
        throw new Exception("Invalid Id");
      }
      Wish wish = _wrepo.GetWishByWishId(newListWish.WishId);
      if (wish == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.CreateListWish(newListWish.ListId, newListWish.WishId, newListWish.UserId);
      return "success";
    }

    public string RemoveListWish(ListWish listWish, string userId)
    {
      ListWish lWish = _repo.GetListWishByListIdWishIdAndUserId(listWish);
      int id = lWish.Id;
      if (lWish == null || lWish.UserId != userId)
      {
        throw new Exception("Invalid List Id");
      }
      _repo.RemoveListWish(id);
      return "Removed ListWish";
    }
  }
}