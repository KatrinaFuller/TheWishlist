using System;
using System.Collections.Generic;
using TheWistlist.Models;
using TheWistlist.Repositories;

namespace TheWistlist.Services
{
  public class ListsService
  {
    public readonly ListsRepository _repo;
    public ListsService(ListsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<List> GetListByUserId(string userId)
    {
      IEnumerable<List> exists = _repo.GetListByUserId(userId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public object GetListById(int id)
    {
      List exists = _repo.GetListById(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public object CreateList(List newList)
    {
      int id = _repo.CreateList(newList);
      newList.Id = id;
      return newList;
    }
    public List EditList(List editList)
    {
      List list = _repo.GetListById(editList.Id);
      if (list == null)
      {
        throw new Exception("Invalid Id");
      }
      list.Name = editList.Name;
      list.Description = editList.Description;
      _repo.EditList(list);
      return list;
    }

    public object DeleteList(int id)
    {
      List exists = _repo.GetListById(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.DeleteList(id);
      return "List has been deleted";
    }

  }
}