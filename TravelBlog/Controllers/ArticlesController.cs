using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models; 

namespace TravelBlog.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase 
{   
    [HttpGet("{articleId: string}")]
    public ArticleModel Get(string articleId) 
    {   
        //Connect to DB
        //Retrieve article record from DB 
        //Retrieve all sections for the article 
        //Instantiate object 
        //Return it; 
        //Get Article from DB and return it; 
        return null; 
    }

}