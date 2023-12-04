using BlogEntity.Models;
using BlogRepository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;
[ApiController]
[Route("api/posts")]
public class PostsController:ControllerBase
{
    [HttpGet]
    public IActionResult GetAllPosts(){
        var result = PostsRepsitory.GetAllPosts();
        
        return result is null?NoContent():Ok(result);
    }
    [HttpGet("GetAllPostByAuthor/{id:int}")]
    public IActionResult GetAllPostsByAuthor(int id){//The name of the parameter must be the same with the name of the Route
        var result = PostsRepsitory.GetAllPostsByAuthor(id);
        
        return result is null?NoContent():Ok(result);
    }
    [HttpGet("GetOnePostByAuthor/{postId:int},{userId:int}")]
    public IActionResult GetOnePostByAuthor([FromRoute(Name ="postId")]int postId,[FromRoute(Name ="userId")]int userId){
        var result = PostsRepsitory.GetOnePostByAuthor(postId,userId);
        return result is null?NoContent():Ok(result);
    }
    [HttpPost("AddOnePost")]
    public IActionResult AddOnePost([FromBody]Posts post){
        if (post is null)
        {
            return BadRequest();
        }
        PostsRepsitory.AddPost(post);
        return Ok($"The {post} is added Successfully");
    }
    [HttpPost("AddOneComment/{postId:int}")]
    public IActionResult AddOneComment([FromRoute(Name ="postId")]int postId,[FromBody]Comments comment){
        if (comment is null)
        {
            return NotFound();
        }
        PostsRepsitory.AddComment(postId,comment);
    return Ok($"The Comment: {comment} is add successfully to the post number: {postId}");
    }
}