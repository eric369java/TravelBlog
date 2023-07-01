using System.ComponentModel.DataAnnotations; 
using Microsoft.EntityFrameworkCore; 
using TravelBlog.Models; 

namespace TravelBlog.Views
{
    public class ArticleView
    {   
        public Article MainArticle {get; set;}
        public List<Remark> Remarks {get; set;}
        public List<Image> Images {get; set;}

        public ArticleView(Article article) {
            MainArticle = article; 
            Remarks = new List<Remark>(); 
            Images = new List<Image>(); 
        }
        
        public ArticleView(Article article, List<Remark> remarks, List<Image> images) {
            MainArticle = article; 
            Remarks = remarks; 
            Images = images; 
        }
    }
}
