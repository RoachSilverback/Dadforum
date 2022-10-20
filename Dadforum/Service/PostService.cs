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
            database.Add(new Post { DateOfSubmission = DateTime.Now, NameOfAuthor = "Greg Albertsen", PostString = "Hvad skal man lave som nyuddannet bondemand?", Content = "Imagine at skrive reel seeddata", Upvotes = 2, Downvotes = 50});
            database.Add(new Post { DateOfSubmission = DateTime.Now, NameOfAuthor = "Tobias Rahim", PostString = "How much wood could a woodchug chug if a woodchug could chug wood?", Content = "Imagine at skrive mere reel seeddata", Upvotes = 30, Downvotes = 0});
            database.Add(new Post { DateOfSubmission = DateTime.Now, NameOfAuthor = "Mikkel Allansen", PostString = "Hvad er den bedste far joke i historien?", Content="Imagine at skrive en tredje seeddata", Upvotes = 5, Downvotes = 2});
            database.SaveChanges();
            }

        Comment comment = database.Comments.FirstOrDefault()!;
        if (comment == null){
            post.Comments.Add(new Comment {DateOfComment = DateTime.Now, Author = "Knud Erik", CommentString = "Få en ny uddannelse", Upvotes = 300, Downvotes = 123, Post = post});
            post.Comments.Add(new Comment {DateOfComment = DateTime.Now, Author = "Peter Plys", CommentString = "Stop it GOKU!", Upvotes = 131, Downvotes = 23, Post = post});
            post.Comments.Add(new Comment {DateOfComment = DateTime.Now, Author = "Mama cita", CommentString = "Hvordan får man en fisk til at svømme hurtigere? Man tuner den XD", Upvotes = 123, Downvotes = 0, Post = post});
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
    public string CreatePost(DateTime dateofsubmission, string nameofauthor, string poststring, string content) {
        database.Posts.Add(new Post {DateOfSubmission = DateTime.Now, NameOfAuthor = nameofauthor, PostString = poststring, Content = content, Upvotes = 0, Downvotes = 0});
        database.SaveChanges();
        return "Post Created";
    }
    public string CreateComment(DateTime dateofcomment, string author, string commentstring, int postID) {
        Post post = database.Posts.FirstOrDefault(p => p.PostID == postID);
        database.Comments.Add(new Comment { DateOfComment = DateTime.Now, Author = author, CommentString = commentstring, Post = post});
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
        post.Downvotes++;
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
        comment.Downvotes++;
        database.SaveChanges();
        return comment;
    }
}
