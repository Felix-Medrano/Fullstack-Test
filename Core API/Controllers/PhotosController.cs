using Core_API.Classes.Base;
using Core_API.Models;

using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
  [ApiController]
  [Route("Placeholder")]
  public class PhotosController : BaseClassController
  {
    //=================================================================
    //Get Functions
    [HttpGet]
    [Route("GetAllPhotos")]
    public async Task<ActionResult<IEnumerable<PlaceholderPhotoModel>>> GetAllPhotos()
    {
      var photos = await httpService.GetAsync<PlaceholderPhotoModel[]>(urlData.PhotosUrl);
      return Ok(photos);
    }

    [HttpGet]
    [Route("GetPhotoById/{id}")]
    public async Task<ActionResult<PlaceholderPhotoModel>> GetPhotoById(int id)
    {
      var photos = await httpService.GetAsync<PlaceholderPhotoModel[]>(urlData.PhotosUrl);
      var photo = photos.FirstOrDefault(p => p.Id == id);
      if (photo == null)
      {
        return NotFound();
      }
      return Ok(photo);
    }

    [HttpGet]
    [Route("GetPhotosByAlbumId/{albumId}")]
    public async Task<ActionResult<IEnumerable<PlaceholderPhotoModel>>> GetPhotosByAlbumId(int albumId)
    {
      var photos = await httpService.GetAsync<PlaceholderPhotoModel[]>(urlData.PhotosUrl);
      var photosByAlbum = photos.Where(p => p.AlbumId == albumId).ToList();
      if (photosByAlbum.Count == 0)
      {
        return NotFound();
      }
      return Ok(photosByAlbum);
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
