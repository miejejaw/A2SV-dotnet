using System;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
namespace Blog.Controller;


[ApiController]
[Route("api/[controller]")]
public class CommentManagerController : ControllerBase
{
    public readonly AppDbContext _context;
    public CommentManagerController(AppDbContext context){
        _context = context;
    }

    [HttpGet]
    public ActionResult Get(){
        var comments = _context.Comments.ToList();
        return Ok(comments);
    }

    [HttpPost]
    public IActionResult Post( Comment comment){
        _context.Comments.Add(comment);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = comment.Id }, comment);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IActionResult Put(int id, [FromBody] Comment updatedFields) {

        var existingComment = _context.Comments.SingleOrDefault(com => com.Id == id);
        if(existingComment == null){
            _context.Comments.Add(updatedFields);
            return CreatedAtAction(nameof(Get), new { id = updatedFields.Id }, updatedFields);
        }

        updatedFields.Id = existingComment.Id;
        _context.Entry(existingComment).CurrentValues.SetValues(updatedFields);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult Delete(int id) {
        var comment = _context.Comments.SingleOrDefault(comment => comment.Id == id);
        if(comment == null){
            return NotFound();
        }

        _context.Comments.Remove(comment);
        _context.SaveChanges();
        return NoContent();
    }

}