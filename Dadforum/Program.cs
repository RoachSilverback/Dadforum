using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text.Json;

using Data;
using Service;
using shared.Model;

var builder = WebApplication.CreateBuilder(args);


// Sætter CORS så apien kan bruges fra andre domæner
var AllowThings = "_AllowThings";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowThings, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Tilføj DbContext som service
builder.Services.AddDbContext<PostContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ContextSQLite")));

builder.Services.AddScoped<PostService>();

var app = builder.Build();

// Seed data hvis nødvendigt
using (var scope = app.Services.CreateScope())
{
    var postService = scope.ServiceProvider.GetRequiredService<PostService>();
    postService.SeedData(); // Fylder data på databasen, hvis databasen er tom. XD
}

app.UseHttpsRedirection();
app.UseCors(AllowThings);

JsonSerializerOptions options = new()
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};

app.MapGet("/api/posts", (PostService service) =>
{
    return service.GetPosts();
});

app.MapGet("/api/posts/{id}", (PostService service, int id) => {
    return service.GetPost(id);
});

app.MapPost("/api/posts", (PostService service, NewPostData data) =>
{
    string result = service.CreatePost(data.NameOfAuthor, data.PostString);
    return result;
});

app.MapPut("/api/posts/{id}/upvote", (PostService service, int id) => {
    Post result = service.PostChangeUpvote(id);
    return result;
});

app.MapPut("/api/posts/{id}/downvote", (PostService service, int id) => {
    Post result = service.PostChangeDownvote(id);
    return result;
});

app.MapPut("/api/comments/{id}/upvote", (PostService service, int id) => {
    Comment result = service.CommentChangeUpvote(id);
    return result;
});

app.MapPut("/api/comments/{id}/downvote", (PostService service, int id) => {
    Comment result = service.CommentChangeDownvote(id);
    return result;
});

app.Run();

record NewPostData(string NameOfAuthor, string PostString);