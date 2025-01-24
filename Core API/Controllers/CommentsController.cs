using Core_API.Classes.Base;
using Core_API.Models;

using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
  [ApiController]
  [Route("Placeholder")]
  public class CommentsController : BaseClassController
  {
    //=================================================================
    //Get Functions
    [HttpGet]
    [Route("GetAllComments")]
    public async Task<ActionResult<IEnumerable<PlaceholderCommentModel>>> GetAllComments()
    {
      var comments = await httpService.GetAsync<PlaceholderCommentModel[]>(urlData.CommentsUrl);
      return Ok(comments);
    }

    [HttpGet]
    [Route("GetCommentById/{id}")]
    public async Task<ActionResult<PlaceholderCommentModel>> GetCommentById(int id)
    {
      var comments = await httpService.GetAsync<PlaceholderCommentModel[]>(urlData.CommentsUrl);
      var comment = comments.FirstOrDefault(c => c.Id == id);
      if (comment == null)
      {
        return NotFound();
      }
      return Ok(comment);
    }

    [HttpGet]
    [Route("GetCommentsByPostId/{postId}")]
    public async Task<ActionResult<IEnumerable<PlaceholderCommentModel>>> GetCommentsByPostId(int postId)
    {
      var comments = await httpService.GetAsync<PlaceholderCommentModel[]>(urlData.CommentsUrl);
      var commentsByPost = comments.Where(c => c.PostId == postId).ToList();
      if (commentsByPost.Count == 0)
      {
        return NotFound();
      }
      return Ok(commentsByPost);
    }

    [HttpGet]
    [Route("GetCommentsByEmail/{email}")]
    public async Task<ActionResult<IEnumerable<PlaceholderCommentModel>>> GetCommentsByEmail(string email)
    {
      var comments = await httpService.GetAsync<PlaceholderCommentModel[]>(urlData.CommentsUrl);
      var commentsByEmail = comments.Where(c => c.Email.ToLower() == email.ToLower()).ToList();
      if (commentsByEmail.Count == 0)
      {
        return NotFound();
      }
      return Ok(commentsByEmail);
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
