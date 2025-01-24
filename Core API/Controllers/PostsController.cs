using Core_API.Classes.Base;
using Core_API.Models;

using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
  [ApiController]
  [Route("Placeholder")]
  public class PostsController : BaseClassController
  {
    //=================================================================
    //Get Functions
    [HttpGet]
    [Route("GetAllPosts")]
    public async Task<ActionResult<IEnumerable<PlaceholderGetPostModel>>> GetAllPosts()
    {
      var posts = await httpService.GetAsync<PlaceholderGetPostModel[]>(urlData.PostsUrl);
      return Ok(posts);
    }

    [HttpGet]
    [Route("GetPostById/{id}")]
    public async Task<ActionResult<IEnumerable<PlaceholderGetPostModel>>> GetPostById(int id)
    {
      var posts = await httpService.GetAsync<PlaceholderGetPostModel[]>(urlData.PostsUrl);
      var post = posts.Where(p => p.Id == id).ToList();
      if (post.Count == 0)
      {
        return NotFound();
      }
      return Ok(post);
    }

    [HttpGet]
    [Route("GetPostByUserId/{userId}")]
    public async Task<ActionResult<IEnumerable<PlaceholderGetPostModel>>> GetPostByUserId(int userId)
    {
      var posts = await httpService.GetAsync<PlaceholderGetPostModel[]>(urlData.PostsUrl);
      var post = posts.Where(p => p.UserId == userId).ToList();
      if (post.Count == 0)
      {
        return NotFound();
      }
      return Ok(post);
    }

    //=================================================================
    //Post Functions
    [HttpPost]
    [Route("CreatePost")]
    public async Task<ActionResult<PlaceholderGetPostModel>> CreatePost([FromBody] PlaceholderUploadPostModel newPost)
    {
      try
      {
        var response = await httpService.PostAsync<PlaceholderGetPostModel>(urlData.PostsUrl, newPost);
        return Ok(response);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    //=================================================================
    //Put Functions
    [HttpPut]
    [Route("UpdatePost/{id}")]
    public async Task<ActionResult<PlaceholderGetPostModel>> UpdatePost(int id, [FromBody] PlaceholderGetPostModel updatedPost)
    {
      try
      {
        var posts = await httpService.GetAsync<PlaceholderGetPostModel[]>(urlData.PostsUrl);
        var postToUpdate = posts.FirstOrDefault(p => p.Id == id);

        if (postToUpdate == null)
        {
          return NotFound();
        }
        updatedPost.Id = id; // Nos Aseguramos que el Id se mantenga igual
        var response = await httpService.PutAsync<PlaceholderGetPostModel>($"{urlData.PostsUrl}/{id}", updatedPost);

        return Ok(response);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    //=================================================================
    //Patch Functions
    [HttpPatch]
    [Route("PatchPost/{id}")]
    public async Task<ActionResult<PlaceholderGetPostModel>> PatchPost(int id, [FromBody] PlaceholderUpdatePostModel patchData)
    {
      try
      {
        var posts = await httpService.GetAsync<PlaceholderGetPostModel[]>(urlData.PostsUrl);
        var postToUpdate = posts.FirstOrDefault(p => p.Id == id);

        if (postToUpdate == null)
        {
          return NotFound();
        }

        postToUpdate.UserId = patchData.UserId;
        postToUpdate.Title = patchData.Title;
        postToUpdate.Body = patchData.Body;
        var response = await httpService.PatchAsync<PlaceholderGetPostModel>($"{urlData.PostsUrl}/{id}", postToUpdate);

        return Ok(response);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    //=================================================================
    //Delete Functions
    [HttpDelete]
    [Route("DeletePost/{id}")]
    public async Task<ActionResult> DeletePost(int id)
    {
      try
      {
        var url = $"{urlData.PostsUrl}/{id}";
        await httpService.DeleteAsync(url);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }
  }
}
