using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using TheWistlist.Models;
using TheWistlist.Services;

namespace TheWistlist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ListsController : ControllerBase
  {
    private readonly ListsService _ls;
    public ListsController(ListsService ls)
    {
      _ls = ls;
    }

    [HttpGet]
    public ActionResult<IEnumerable<List>> GetListByUserId()
    {
      try
      {
        var id = HttpContext.User.FindFirstValue("Id");
        return Ok(_ls.GetListByUserId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<List> GetListById(int id)
    {
      try
      {
        return Ok(_ls.GetListById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<List> CreateList([FromBody] List newList)
    {
      try
      {
        newList.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ls.CreateList(newList));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<List> EditList([FromBody] List editList, int id)
    {
      try
      {
        editList.Id = id;
        return Ok(_ls.EditList(editList));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<int> DeleteList(int id)
    {
      try
      {
        return Ok(_ls.DeleteList(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}