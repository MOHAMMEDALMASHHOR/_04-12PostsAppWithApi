namespace BlogEntity.Models;
public class Posts
{
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime PostedDate { get; set; }
    public Users? Author { get; set; }
    public List<Comments> CommentsList { get; set; }
    public Posts()
    {
        CommentsList = new List<Comments>();
    }
}
