using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using System.Linq; 
using TravelBlog.Data; 
using TravelBlog.Models; 
using TravelBlog.Views; 

namespace TravelBlog.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase 
{   
    private readonly MyDbContext Context; 

    public ArticleController(MyDbContext _Context) {
        Context = _Context; 
    }

    [HttpGet("{id:string}")]
    public ActionResult<ArticleView> Get(string id) 
    {   
        /*
        TODO: Error Handling and Input valid
        */ 

        var QueryResult = 
            from a in Context.Articles
            where a.ArticleId == id 
            join r in Context.Remarks on a.ArticleId equals r.ParentArticleId into group1
            from g1 in group1.DefaultIfEmpty()
            join i in Context.Images on g1.ParentArticleId equals i.ParentArticleId into group2 
            from g2 in group2.DefaultIfEmpty()
            select new {
                ArticleId = a.ArticleId,
                Title = a.Title, 
                PublishDate = a.PublishDate, 
                Continent = a.Continent, 
                Country = a.Country, 
                Introduction = a.Introduction,
                Background = a.Background, 
                CoverImage = a.CoverImage,
                RemarkId = g1 == null ? g1.RemarkId : string.Empty, 
                RemarkType = g1 == null ? g1.Type : string.Empty, 
                RemarkText = g1 == null ? g1.Text : string.Empty,
                ImageId = g2 == null ? g2.ImageId : string.Empty, 
                ImageUrl = g2 == null ? g2.ImageUrl : string.Empty, 
                Caption = g2 == null ? g2.Caption : string.Empty,
                PlaceId = g2 == null ? g2.PlaceId : string.Empty
            }; 
        

        //Create Main Article 
        var FirstItem = QueryResult.First(); 
        Article Article = new Article(FirstItem.ArticleId, FirstItem.Title, FirstItem.PublishDate, FirstItem.Continent,
            FirstItem.Country, FirstItem.Introduction, FirstItem.Background, FirstItem.CoverImage); 
        ArticleView ArticleView = new ArticleView(Article); 

        //If Image exists, add to Images
        //If Remark hasn't been seen before, add to Remarks
        HashSet<string> RemarkSet = new HashSet<string>(); 
        foreach(var item in QueryResult) {
            
            if(item.ImageId != null) {
                ArticleView.Images.Add(new Image(item.ImageId, item.ArticleId, item.ImageUrl, item.Caption, item.Country, item.PlaceId)); 
            }

            if(!RemarkSet.Contains(item.RemarkId)) {
                ArticleView.Remarks.Add(new Remark(item.RemarkId, item.RemarkType, item.ArticleId, item.RemarkText)); 
                RemarkSet.Add(item.RemarkId); 
            }
        }

        return ArticleView; 
    }

}