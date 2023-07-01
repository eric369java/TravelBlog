using System.ComponentModel.DataAnnotations; 

namespace TravelBlog.Models
{
    public class Article 
    {   [Key]
        public string ArticleId {get; set;}
        public string Title {get; set;}
        public DateTime PublishDate {get; set;}
        public string Continent {get; set;}
        public string Country {get; set;}
        public string Introduction {get; set;}
        public string Background {get;set;}
        public string CoverImage {get; set;}
    
        public Article(string _ArticleId, string _Title, 
            DateTime _PublishDate, string _Continent, string _Country, string _Introduction, string _Background, string _CoverImage) {
            
            ArticleId = _ArticleId; 
            Title = _Title; 
            PublishDate = _PublishDate; 
            Continent = _Continent; 
            Country = _Country; 
            Introduction = _Introduction; 
            Background = _Background; 
            CoverImage = _CoverImage; 
        }
    }
}

