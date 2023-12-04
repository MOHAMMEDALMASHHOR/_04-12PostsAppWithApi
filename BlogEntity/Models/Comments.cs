namespace BlogEntity.Models;

public class Comments
{
    public int CommentId { get; set; }
    public string? Content { get; set; }
    public DateTime PostedDate { get; set; }
    public Users? Author { get; set; }
}