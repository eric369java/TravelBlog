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

        public ArticleView(Article _Article) {
            MainArticle = _Article; 
            Remarks = new List<Remark>(); 
            Images = new List<Image>(); 
        }
        
        public ArticleView(Article _Article, List<Remark> _Remarks, List<Image> _Images) {
            MainArticle = _Article; 
            Remarks = _Remarks; 
            Images = _Images; 
        }
    }
}
