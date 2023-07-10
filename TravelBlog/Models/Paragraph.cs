using System.ComponentModel.DataAnnotations; 

namespace TravelBlog.Models
{
    public class Paragraph 
    {   
        public int Id {get; set;}
        public string SubTitle {get; set;}
        public string Text {get; set;}
        public int ArticleId {get; set;} 
        public Article Article {get; set; } = null!;
    }
}