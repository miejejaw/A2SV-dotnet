using System;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Blog.Controller;

[ApiController]
[Route("api/[controller]")]
public class PostManagerController : ControllerBase
{
    public readonly AppDbContext _context;
    public PostManagerController(AppDbContext context){
        _context = context;
    }

    [HttpGet]
    public ActionResult Get(){
        
        var blogPosts = _context.BlogPosts.ToList();
        return Ok(blogPosts);
    }

    [HttpGet]
    [Route("{id:int}")]
    public ActionResult Get(int id){
        var blogPost = _context.BlogPosts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
        if (blogPost == null)
            return NotFound();

    
        var blogPostWithComment = new BlogPost
        {
            Id = blogPost.Id,
            Title = blogPost.Title,
            Content = blogPost.Content,
            CreatedAt = blogPost.CreatedAt,
            Comments = blogPost.Comments
                                .Select(c => new Comment { Id = c.Id, Text = c.Text,CreatedAt = c.CreatedAt })
                                .ToList()
        };

        return Ok(blogPostWithComment);
    }
        


    [HttpPost]
    public ActionResult Post([FromBody] BlogPost blogPost){
        _context.BlogPosts.Add(blogPost);
        _context.SaveChanges();
        
        return Ok();
    }

    [HttpPut]
    [Route("{id:int}")]
    public ActionResult Put(int id, [FromBody] BlogPost updatedFields) {
        var existingPost = _context.BlogPosts.SingleOrDefault(post => post.Id == id);
        if(existingPost == null)
            return NotFound();

        updatedFields.Id = existingPost.Id;
        _context.Entry(existingPost).CurrentValues.SetValues(updatedFields);
        _context.SaveChanges();
        
        return Ok();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult Delete(int id) {
        var blogPost = _context.BlogPosts.SingleOrDefault(post => post.Id == id);
        if(blogPost == null){
            return NotFound();
        }

        _context.BlogPosts.Remove(blogPost);
        _context.SaveChanges();
        return NoContent();
    }

}