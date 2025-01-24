using Core_API.Classes.Base;
using Core_API.Models;

using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
  [ApiController]
  [Route("Placeholder")]
  public class UsersController : BaseClassController
  {
    //=================================================================
    //Get Functions
    [HttpGet]
    [Route("GetAllUsers")]
    public async Task<ActionResult<IEnumerable<PlaceholderUserModel>>> GetAllUsers()
    {
      var users = await httpService.GetAsync<PlaceholderUserModel[]>(urlData.UsersUrl);
      return Ok(users);
    }

    [HttpGet]
    [Route("GetUserById/{id}")]
    public async Task<ActionResult<PlaceholderUserModel>> GetUserById(int id)
    {
      var users = await httpService.GetAsync<PlaceholderUserModel[]>(urlData.UsersUrl);
      var user = users.FirstOrDefault(u => u.Id == id);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(user);
    }

    [HttpGet]
    [Route("GetUserByName/{name}")]
    public async Task<ActionResult<PlaceholderUserModel>> GetUserByName(string name)
    {
      var users = await httpService.GetAsync<PlaceholderUserModel[]>(urlData.UsersUrl);
      var user = users.FirstOrDefault(u => u.Name == name);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(user);
    }

    [HttpGet]
    [Route("GetUserByUsername/{username}")]
    public async Task<ActionResult<PlaceholderUserModel>> GetUserByUsername(string username)
    {
      var users = await httpService.GetAsync<PlaceholderUserModel[]>(urlData.UsersUrl);
      var user = users.FirstOrDefault(u => u.Username == username);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(user);
    }

    [HttpGet]
    [Route("GetUserByEmail/{email}")]
    public async Task<ActionResult<PlaceholderUserModel>> GetUserByEmail(string email)
    {
      var users = await httpService.GetAsync<PlaceholderUserModel[]>(urlData.UsersUrl);
      var user = users.FirstOrDefault(u => u.Email == email);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(user);
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
