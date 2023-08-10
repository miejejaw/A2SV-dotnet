using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.Models;
public class BlogPost 
{
    public int Id {get; set;}
    public string? Title {get; set;}
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public virtual ICollection<Comment> Comments { get; set; }


    public BlogPost(){
        Comments = new HashSet<Comment>();
    }
}