using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;


using Data;
using shared.Model;

namespace Service;

public class PostService
{
    private PostContext database {get; }

    public PostService(PostContext database){
        this.database = database;
    }

    public void SeedData(){
        Post post = database.Posts.FirstOrDefault()!;
        if (post == null){
            database.Add(new Post { NameOfAuthor = "Greg Albertsen", PostString = "Hvad skal man lave som nyuddannet bondemand?", Upvotes = 2, Downvotes = 50});
            database.Add(new Post { NameOfAuthor = "Tobias Rahim", PostString = "How much wood could a woodchug chug if a woodchug could chug wood?", Upvotes = 200, Downvotes = 0});
            database.Add(new Post { NameOfAuthor = "Mikkel Allansen", PostString = "Hvad er den bedste far joke i historien?", Upvotes = 5, Downvotes = 2});
            database.SaveChanges();
            }

        Comment comment = database.Comments.FirstOrDefault()!;
        if (comment == null){
            post.Comments.Add(new Comment {CommentString = "Få en ny uddannelse", Upvotes = 500, Downvotes = 123, Post = post});
            post.Comments.Add(new Comment {CommentString = "Stop it GOKU!", Upvotes = 2131, Downvotes = 23, Post = post});
            post.Comments.Add(new Comment {CommentString = "Hvordan får man en fisk til at svømme hurtigere? Man tuner den XD", Upvotes = 123423, Downvotes = 0, Post = post});
            database.SaveChanges();
        }      
    }

// METODER TIL AT HENTE POSTS
// Metode til at hente alle posts
    public List<Post> GetPosts() {
        return database.Posts.ToList();
    }

// Metode til at hente post på id
    public Post GetPost(int id) {
        return database.Posts.Include(p => p.Comments).FirstOrDefault(p => p.PostID == id);
    }

// METODE TIL AT LAVE ET POST
    public string CreatePost(string nameofauthor, string content) {
        database.Posts.Add(new Post { NameOfAuthor = nameofauthor, PostString = content, Upvotes = 0, Downvotes = 0});
        database.SaveChanges();
        return "Post Created";
    }
    public string CreateComment(string commentstring) {
        database.Comments.Add(new Comment { CommentString = commentstring});
        database.SaveChanges();
        return "Comment Created";
    }

// METODER TIL AT ÆNDRE VOTES
// Metoder til at ændre votes for Posts
    public Post PostChangeUpvote(int postid) {
        Post post = database.Posts.FirstOrDefault(p => p.PostID == postid);
        post.Upvotes++;
        database.SaveChanges();
        return post;
    }

    public Post PostChangeDownvote(int postid) {
        Post post = database.Posts.FirstOrDefault(p => p.PostID == postid);
        post.Downvotes--;
        database.SaveChanges();
        return post;
    }
// Metoder til at ændre votes for Comments
    public Comment CommentChangeUpvote(int commentid) {
        Comment comment = database.Comments.FirstOrDefault(c => c.CommentID == commentid);
        comment.Upvotes++;
        database.SaveChanges();
        return comment;
    }
    public Comment CommentChangeDownvote(int commentid) {
        Comment comment = database.Comments.FirstOrDefault(c => c.CommentID == commentid);
        comment.Downvotes--;
        database.SaveChanges();
        return comment;
    }
}
