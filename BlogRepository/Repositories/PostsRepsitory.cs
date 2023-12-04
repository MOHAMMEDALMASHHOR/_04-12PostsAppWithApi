using BlogEntity.Models;

namespace BlogRepository.Repositories;
public static class PostsRepsitory
{
    private static List<Posts> posts {get;set;}
    static PostsRepsitory()
    {
        posts = new List<Posts>();
    }
    public static void AddPost(Posts post){
        if (post is null)
        {
            return;
        }
        posts.Add(post);
    }
    public static void AddComment(int postId, Comments comment){
        if (comment is null)
        {
            return;
        }
        for (int i = 0; i < posts.Count; i++)//We can't use LINQ here
        {
            if (posts[i].PostId.Equals(postId))
            {
                posts[i].CommentsList.Add(comment);
                return;
            }
        }
    }
    public static List<Posts> GetAllPosts(){
        return posts;
    }
    public static List<Posts> GetAllPostsByAuthor(int userId){
        return posts.Where(post=> post.Author.UserId.Equals(userId)).ToList();
    }
    public static Posts? GetOnePostByAuthor(int postId, int userId){
        return posts.Where(post=>post.PostId.Equals(postId)&& post.Author.UserId.Equals(userId)).SingleOrDefault();
    }
}