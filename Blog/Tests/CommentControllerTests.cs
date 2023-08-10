using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using Blog.Models; 
using Blog.Data;
using Blog.Controller;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Tests;

//CommentControllerTests

[Collection("SequentialTests")]
public class CommentControllerTest1 
{
    private readonly AppDbContext _context;
    public CommentControllerTest1(){
        _context = ContextGenerator.Generate();
    }

    [Fact]
    public void Comment_Post(){

        var controller = new CommentManagerController(_context);

        controller.Post(new Comment { Text = "Test Comment 1", PostId = 1 });
        controller.Post(new Comment { Text = "Test Comment 2", PostId = 2 });

        Assert.Equal(2, _context.Comments.Count());
    }
}

 [Collection("SequentialTests")]
 public class CommentControllerTest2
 {
    private readonly AppDbContext _context;
    public CommentControllerTest2(){
        _context = ContextGenerator.Generate();
    }

    [Fact]
    public void Comment_Get(){
        
        var controller = new CommentManagerController(_context);     
        // Act
        var result = controller.Get();

        // Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        var comments = Assert.IsType<List<Comment>>(okObjectResult.Value);
        // Assert.Single(comments);
        Assert.Equal(2, comments.Count);
    }
 }


 [Collection("SequentialTests")]
 public class CommentControllerTest3
 {
    private readonly AppDbContext _context;
    public CommentControllerTest3(){
        _context = ContextGenerator.Generate();
    }

    [Fact]
    public void Comment_Put(){
        var controller = new CommentManagerController(_context);
        var updatedComment = new Comment { Text = "Updated Comment",PostId = 2};

        // Act
        var result = controller.Put(2, updatedComment);

        // Assert
        Assert.IsType<OkResult>(result);

        var commentInDatabase = _context.Comments.SingleOrDefault(c => c.Id == 2);
        Assert.NotNull(commentInDatabase);
        Assert.Equal(updatedComment.Text, commentInDatabase.Text);
        Assert.Equal(updatedComment.PostId, commentInDatabase.PostId);
    }
 }


[Collection("SequentialTests")]
 public class CommentControllerTest4
 {
    private readonly AppDbContext _context;
    public CommentControllerTest4(){
        _context = ContextGenerator.Generate();
    }
    [Fact]
    public void Comment_Delete(){
        
            var controller = new CommentManagerController(_context);

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result); // Check for 204 No Content status

            // Verify that the comment was actually deleted from the database
            Assert.Null(_context.Comments.FirstOrDefault(c => c.Id == 1));
            Assert.NotNull(_context.Comments.FirstOrDefault(c => c.Id == 2));
    }
 }