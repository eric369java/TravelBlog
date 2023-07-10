namespace TravelBlog.Models
{
    public class Remark 
    {   
        public int Id {get; set;}
        public string Type {get; set;} 
        public string Text {get; set;}
        public int  ArticleId {get; set;}
        public Article Article {get; set;} = null!; 
    }
}