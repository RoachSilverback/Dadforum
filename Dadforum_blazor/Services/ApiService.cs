using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

using shared.Model;


namespace Dadforum_blazor.Data;

public class ApiService
{
    private readonly HttpClient http;
    private readonly IConfiguration configuration;
    private readonly string baseAPI = "";

    public ApiService(HttpClient http, IConfiguration configuration)
    {
        this.http = http;
        this.configuration = configuration;
        this.baseAPI = configuration["base_api"];
    }

    public async Task<Post[]> GetPosts()
    {
        string url = $"{baseAPI}/api/posts";
        return await http.GetFromJsonAsync<Post[]>(url);
    }

    public async Task<Post> GetPost(int id)
    {
        string url = $"{baseAPI}/api/posts/{id}";
        return await http.GetFromJsonAsync<Post>(url);
    }

    public async Task<Comment> CreateComment(string author, string commentstring, int postId)
    {
        string url = $"{baseAPI}/api/Comments";

        HttpResponseMessage msg = await http.PostAsJsonAsync(url, new {author, commentstring, postId});
        
        string json = msg.Content.ReadAsStringAsync().Result;

        Comment? newComment = JsonSerializer.Deserialize<Comment>(json, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true // Ignore case when matching JSON properties to C# properties 
        });

        return newComment;
    }

    public async Task<Post> CreatePost(string nameofauthor, string poststring, string content)
    {
        string url = $"{baseAPI}/api/Createposts";

        HttpResponseMessage msg = await http.PostAsJsonAsync(url, new {nameofauthor, poststring, content});

        string json = msg.Content.ReadAsStringAsync().Result;

        Post? newPost = JsonSerializer.Deserialize<Post>(json, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        });
        return newPost;
    }

    public async Task<Comment> UpvoteComment(int id)
    {
        string url = $"{baseAPI}/api/comments/{id}/upvote";

        HttpResponseMessage msg = await http.PutAsJsonAsync(url, "");

        string json = msg.Content.ReadAsStringAsync().Result;

        Comment? upvoteComment = JsonSerializer.Deserialize<Comment>(json, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        });
        return upvoteComment;
    }

    public async Task<Comment> DownvoteComment(int id)
    {
        string url = $"{baseAPI}/api/comments/{id}/downvote";

        HttpResponseMessage msg = await http.PutAsJsonAsync(url, "");

        string json = msg.Content.ReadAsStringAsync().Result;

        Comment? downvoteComment = JsonSerializer.Deserialize<Comment>(json, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        });
        return downvoteComment;
    }

    public async Task<Post> UpvotePost(int id)
    {
        string url = $"{baseAPI}/api/posts/{id}/upvote";

        HttpResponseMessage msg = await http.PutAsJsonAsync(url, "");

        string json = msg.Content.ReadAsStringAsync().Result;

        Post? upvotePost = JsonSerializer.Deserialize<Post>(json, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        });
        return upvotePost;
    }

    public async Task<Post> DownvotePost(int id)
    {
        string url = $"{baseAPI}/api/posts/{id}/downvote";

        HttpResponseMessage msg = await http.PutAsJsonAsync(url, "");

        string json = msg.Content.ReadAsStringAsync().Result;

        Post? downvotePost = JsonSerializer.Deserialize<Post>(json, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        });
        return downvotePost;
    }
}




