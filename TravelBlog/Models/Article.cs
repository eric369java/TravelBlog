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

        public Article(string articleId, string title, 
            DateTime publishDate, string continent, string country, string introduction, string background, string coverImage) {
            
            ArticleId = articleId; 
            Title = title; 
            PublishDate = publishDate; 
            Continent = continent; 
            Country = country; 
            Introduction = introduction; 
            Background = background; 
            CoverImage = coverImage; 
        }
    }
}

