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
public class PostControllerTest1 
{
    private readonly AppDbContext _context;
    public PostControllerTest1(){
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
 public class PostControllerTest2
 {
    private readonly AppDbContext _context;
    public PostControllerTest2(){
        _context = ContextGenerator.Generate();
    }

    [Fact]
    public void BlogPost_Get(){
        
        var controller = new PostManagerController(_context);  
        // Act
        var result = controller.Get();

        // Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        var posts = Assert.IsType<List<BlogPost>>(okObjectResult.Value);
        // Assert.Single(posts);
        Assert.Equal(2, posts.Count);
    }
 }


 [Collection("SequentialTests")]
 public class PostControllerTest3
 {
    private readonly AppDbContext _context;
    public PostControllerTest3(){
        _context = ContextGenerator.Generate();
    }

    [Fact]
    public void BlogPost_Put(){
        var controller = new PostManagerController(_context);
        var updatedPost = new BlogPost { Title = "Updated Post",Content = "content 4"};

        // Act
        var result = controller.Put(2, updatedPost);

        // Assert
        Assert.IsType<OkResult>(result);

        var postInDatabase = _context.BlogPosts.SingleOrDefault(c => c.Id == 2);
        Assert.NotNull(postInDatabase);
        Assert.Equal(updatedPost.Title, postInDatabase.Title);
        Assert.Equal(updatedPost.Content, postInDatabase.Content);
    }
 }


[Collection("SequentialTests")]
 public class PostControllerTest4
 {
    private readonly AppDbContext _context;
    public PostControllerTest4(){
        _context = ContextGenerator.Generate();
    }
    [Fact]
    public void BlogPost_Delete(){
        
        var controller = new PostManagerController(_context);

        // Act
        var result = controller.Delete(1);

        // Assert
        Assert.IsType<NoContentResult>(result); // Check for 204 No Content status

        // Verify that the post was actually deleted from the database
        Assert.Null(_context.BlogPosts.FirstOrDefault(c => c.Id == 1));
        Assert.NotNull(_context.BlogPosts.FirstOrDefault(c => c.Id == 2));
    }
 }