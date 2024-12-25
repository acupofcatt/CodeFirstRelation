using System.ComponentModel.DataAnnotations;

namespace CodeFirstRelation.Models;

public class Post
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    [StringLength(100, MinimumLength = 3)]
    public string Content { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }
}