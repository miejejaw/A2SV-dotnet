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
public class CommentControllerPostTest 
{
    private readonly AppDbContext _context;
    public CommentControllerPostTest(){
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
 public class CommentControllerGetTest
 {
    private readonly AppDbContext _context;
    public CommentControllerGetTest(){
        _context = ContextGenerator.Generate();
    }

    [Fact]
    public void TestOkResult(){
        
        var controller = new CommentManagerController(_context);     
        // Act
        var result = controller.Get();

        // Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        var comments = Assert.IsType<List<Comment>>(okObjectResult.Value);
  
        Assert.Equal(2, comments.Count);
    }
 }


 [Collection("SequentialTests")]
 public class CommentControllerPutTest
 {
    private readonly AppDbContext _context;
    public CommentControllerPutTest(){
        _context = ContextGenerator.Generate();
    }

    [Fact]
    public void TestNoContentResult(){
        var controller = new CommentManagerController(_context);
        var updatedComment = new Comment { Text = "Updated Comment",PostId = 2};

        // Act
        var result = controller.Put(2, updatedComment);

        // Assert
        Assert.IsType<NoContentResult>(result);

        var commentInDatabase = _context.Comments.SingleOrDefault(c => c.Id == 2);
        Assert.NotNull(commentInDatabase);
        Assert.Equal(updatedComment.Text, commentInDatabase.Text);
        Assert.Equal(updatedComment.PostId, commentInDatabase.PostId);
    }

    [Fact]
    public void TestCreatedAtActionResult(){
        var controller = new CommentManagerController(_context);
        var updatedComment = new Comment { Text = "Updated Comment",PostId = 2};

        // Act
        var result = controller.Put(11, updatedComment);

        //Assert
        Assert.IsType<CreatedAtActionResult>(result);

        var createdAtActionResult = (CreatedAtActionResult)result;
        Assert.NotNull(createdAtActionResult);
    }
 }


[Collection("SequentialTests")]
 public class CommentControllerDeleteTest
 {
    private readonly AppDbContext _context;
    public CommentControllerDeleteTest(){
        _context = ContextGenerator.Generate();
    }
    [Fact]
    public void TestNoContentResult(){
        
            var controller = new CommentManagerController(_context);

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result); // Check for 204 No Content status

            // Verify that the comment was actually deleted from the database
            Assert.Null(_context.Comments.FirstOrDefault(c => c.Id == 1));
            Assert.NotNull(_context.Comments.FirstOrDefault(c => c.Id == 2));
    }

    [Fact]
    public void TestNotFoundResult(){
        var controller = new CommentManagerController(_context);
        var result = controller.Delete(10);

        Assert.IsType<NotFoundResult>(result);
    }

 }