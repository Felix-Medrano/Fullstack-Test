using Core_API.Classes.Base;
using Core_API.Models;

using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
  [ApiController]
  [Route("Placeholder")]
  public class ToDosController : BaseClassController
  {
    //=================================================================
    //Get Functions
    [HttpGet]
    [Route("GetAllToDos")]
    public async Task<ActionResult<IEnumerable<PlaceholderToDoModel>>> GetAllToDos()
    {
      var todos = await httpService.GetAsync<PlaceholderToDoModel[]>(urlData.ToDosUrl);
      return Ok(todos);
    }

    [HttpGet]
    [Route("GetToDoById/{id}")]
    public async Task<ActionResult<PlaceholderToDoModel>> GetToDoById(int id)
    {
      var todos = await httpService.GetAsync<PlaceholderToDoModel[]>(urlData.ToDosUrl);
      var todo = todos.FirstOrDefault(t => t.Id == id);
      if (todo == null)
      {
        return NotFound();
      }
      return Ok(todo);
    }

    [HttpGet]
    [Route("GetToDosByUserId/{userId}")]
    public async Task<ActionResult<IEnumerable<PlaceholderToDoModel>>> GetToDosByUserId(int userId)
    {
      var todos = await httpService.GetAsync<PlaceholderToDoModel[]>(urlData.ToDosUrl);
      var todosByUser = todos.Where(t => t.UserId == userId).ToList();
      if (todosByUser.Count == 0)
      {
        return NotFound();
      }
      return Ok(todosByUser);
    }

    //=================================================================
    //Post Functions

    //=================================================================
    //Put Functions

    //=================================================================
    //Patch Functions

    //=================================================================
    //Delete Functions
  }
}
