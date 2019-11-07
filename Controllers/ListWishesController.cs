using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using TheWistlist.Models;
using TheWistlist.Services;

namespace TheWistlist.Controllers
{
  [ApiController]
  [Route("api/{controller}")]
  public class ListWishesController : ControllerBase
  {
    private readonly ListWishesService _lws;
    public ListWishesController(ListWishesService lws)
    {
      _lws = lws;
    }

    [HttpGet("{listId}")]
    public ActionResult<IEnumerable<List>> GetListWishesByListId(int listId)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_lws.GetListWishesByListId(listId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<ListWish> CreateListWish([FromBody] ListWish newListWish)
    {
      try
      {
        newListWish.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_lws.CreateListWish(newListWish));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut]
    public ActionResult<string> RemoveListWish([FromBody] ListWish listWish)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_lws.RemoveListWish(listWish, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}