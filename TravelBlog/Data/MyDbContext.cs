using Microsoft.EntityFrameworkCore;
using TravelBlog.Models; 

namespace TravelBlog.Data 
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() {}
        
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Article> Articles {get; set;}

        public DbSet<Remark> Remarks {get; set;}

        public DbSet<Paragraph> Paragraphs {get; set;}

        public DbSet<Image> Images {get; set;}
    }
}