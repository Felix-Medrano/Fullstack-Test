using Core_API.Classes.Base;
using Core_API.Models;

using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
  [ApiController]
  [Route("Placeholder")]
  public class AlbumsController : BaseClassController
  {
    //=================================================================
    //Get Functions
    [HttpGet]
    [Route("GetAllAlbums")]
    public async Task<ActionResult<IEnumerable<PlaceholderAlbumModel>>> GetAllAlbums()
    {
      var albums = await httpService.GetAsync<PlaceholderAlbumModel[]>(urlData.AlbumsUrl);
      return Ok(albums);
    }

    [HttpGet]
    [Route("GetAlbumById/{id}")]
    public async Task<ActionResult<PlaceholderAlbumModel>> GetAlbumById(int id)
    {
      var albums = await httpService.GetAsync<PlaceholderAlbumModel[]>(urlData.AlbumsUrl);
      var album = albums.FirstOrDefault(a => a.Id == id);
      if (album == null)
      {
        return NotFound();
      }
      return Ok(album);
    }

    [HttpGet]
    [Route("GetAlbumsByUserId/{userId}")]
    public async Task<ActionResult<IEnumerable<PlaceholderAlbumModel>>> GetAlbumsByUserId(int userId)
    {
      var albums = await httpService.GetAsync<PlaceholderAlbumModel[]>(urlData.AlbumsUrl);
      var albumsByUser = albums.Where(a => a.UserId == userId).ToList();
      if (albumsByUser.Count == 0)
      {
        return NotFound();
      }
      return Ok(albumsByUser);
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
