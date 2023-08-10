using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using Blog.Models; 
using Blog.Data;
using Blog.Controller;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Tests;

//PostControllerTests

[Collection("SequentialTests")]
public class PostControllerPostTest 
{
    private readonly AppDbContext _context;
    public PostControllerPostTest(){
        _context = ContextGenerator.Generate();
    }

    [Fact]
    public void BlogPost_Post(){

        var controller = new PostManagerController(_context);

        controller.Post(new BlogPost { Title = "Test Post 1", Content = "content 1" });
        controller.Post(new BlogPost { Title = "Test Post 2", Content = "content 2" });

        Assert.Equal(2, _context.BlogPosts.Count());
    }
}

 [Collection("SequentialTests")]
 public class PostControllerGetTest
 {
    private readonly AppDbContext _context;
    public PostControllerGetTest(){
        _context = ContextGenerator.Generate();
    }

    [Fact]
    public void TestOkResult(){
        
        var controller = new PostManagerController(_context);  
        // Act
        var result = controller.Get();

        // Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        var posts = Assert.IsType<List<BlogPost>>(okObjectResult.Value);
        // Assert.Single(posts);
        Assert.Equal(2, posts.Count);
    }

    [Fact]
    public void TestOkResultById(){
        var controller = new PostManagerController(_context);
        var result = controller.Get(1);
        
        Assert.IsType<OkResult>(result);
    }
    [Fact]
    public void TestNotFoundResult(){
        var controller = new PostManagerController(_context);
        var result = controller.Delete(10);

        Assert.IsType<NotFoundResult>(result);
    }
 }


 [Collection("SequentialTests")]
 public class PostControllerPutTest
 {
    private readonly AppDbContext _context;
    public PostControllerPutTest(){
        _context = ContextGenerator.Generate();
    }

    [Fact]
    public void TestNoContentResult(){
        var controller = new PostManagerController(_context);
        var updatedPost = new BlogPost { Title = "Updated Post",Content = "content 4"};

        // Act
        var result = controller.Put(2, updatedPost);

        // Assert
        Assert.IsType<NoContentResult>(result);

        var postInDatabase = _context.BlogPosts.SingleOrDefault(c => c.Id == 2);
        Assert.NotNull(postInDatabase);
        Assert.Equal(updatedPost.Title, postInDatabase.Title);
        Assert.Equal(updatedPost.Content, postInDatabase.Content);
    }

    [Fact]
    public void TestCreatedAtActionResult(){
        var controller = new PostManagerController(_context);
        
        var updatedPost = new BlogPost { Title = "Updated Post",Content = "content 8"};
        //Act
        var result = controller.Put(8,updatedPost);
        //Assert
        Assert.IsType<CreatedAtActionResult>(result);

        var postInDatabase = _context.BlogPosts.SingleOrDefault(c => c.Id == 8);
        Assert.NotNull(postInDatabase);
        Assert.Equal(updatedPost.Title, postInDatabase.Title);
        Assert.Equal(updatedPost.Content, postInDatabase.Content);
    }
 }

[Collection("SequentialTests")]
 public class PostControllerDeleteTest
 {
    private readonly AppDbContext _context;
    public PostControllerDeleteTest(){
        _context = ContextGenerator.Generate();
    }
    [Fact]
    public void TestNoContentResult(){
        
        var controller = new PostManagerController(_context);

        // Act
        var result = controller.Delete(1);

        // Assert
        Assert.IsType<NoContentResult>(result); // Check for 204 No Content status

        // Verify that the post was actually deleted from the database
        Assert.Null(_context.BlogPosts.FirstOrDefault(c => c.Id == 1));
        Assert.NotNull(_context.BlogPosts.FirstOrDefault(c => c.Id == 2));
    }

    [Fact]
    public void TestNotFoundResult(){
        var controller = new PostManagerController(_context);
        var result = controller.Delete(10);

        Assert.IsType<NotFoundResult>(result);
    }
 }