using Microsoft.EntityFrameworkCore;
using shared.Model;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Data
{
    public class PostContext : DbContext
    {
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments {get; set;}

        // public string DbPath {get; }
        // public PostContext()
        // {
        //     DbPath = "bin/posting.db"; // database filen
        // }
        // protected override void OnConfiguring(
        //     PostContextOptionsBuilder Options)
        //     => Options.UseSqlite($"Data-source={DbPath}");

        public PostContext (DbContextOptions<PostContext> options)
        : base(options)
        {

        }
    }
}