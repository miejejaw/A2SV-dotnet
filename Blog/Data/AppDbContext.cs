using Microsoft.EntityFrameworkCore;
using Blog.Models;
using System.Linq;

namespace Blog.Data;

public class AppDbContext : DbContext
{
    public virtual DbSet<BlogPost> BlogPosts { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder){

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BlogPost>(entity =>{
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
           
        });

        modelBuilder.Entity<Comment>(entity =>{
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd();

            //1 - Many
            entity.HasOne(c => c.BlogPost)
                  .WithMany(p => p.Comments)
                  .HasForeignKey(c => c.PostId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK_Comment_Post");
        
        });
        
    }
}

// entity.Property(c => c.CreatedAt)
            //       .ValueGeneratedOnAdd()
            //       .HasDefaultValueSql("GETUTCDATE()");

 // entity.Property(p => p.CreatedAt)
            //       .ValueGeneratedOnAdd()
            //       .HasDefaultValueSql("GETUTCDATE()");
