using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using Blog.Models; 
using Blog.Data;

namespace Blog.Tests;
public static class ContextGenerator
{
    public static AppDbContext Generate()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        
        return new AppDbContext(optionsBuilder);
    }
}
