using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using System.Linq; 
using TravelBlog.Data; 
using TravelBlog.Models; 

namespace TravelBlog.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase 
{   
    private readonly MyDbContext Context; 

    public ArticleController(MyDbContext _Context) {
        Context = _Context; 
    }

    [HttpGet("{id:int}")]
    public Article Get(int id) 
    {   
        /*
        TODO: 
        -Error Handling and Input valid
        -Load images on seperate API 
        -Id of article is coordinates
        -Translation of api string to int ids 
        */ 
        var QueryResult = Context.Articles.Where(
            article => article.Id == id
        ).Include(
            article => article.Paragraphs.Where(paragraph => paragraph.ArticleId == id)
        ).FirstOrDefault(); 
        
        return QueryResult; 
    }

}