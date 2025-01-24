using Core_API.Classes;
using Core_API.Models;
using Core_API.Service;

using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
  [ApiController]
  [Route("Placeholder")]
  public class PlaceholderController : ControllerBase
  {
    HTTPService httpService = new HTTPService();

    URLData urlData = new URLData();

    #region Posts

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

    #endregion

    #region Comments

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

    #endregion

    #region Albums

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

    #endregion

    #region Photos

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

    #endregion

    #region ToDos

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

    #endregion

    #region Users

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

    #endregion
  }
}