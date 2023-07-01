using System.ComponentModel.DataAnnotations; 
  
namespace TravelBlog.Models
{
    public class Remark 
    {   
        [Key]
        public string RemarkId {get; set;}
        public string Type {get; set;} 
        public string ParentArticleId {get; set;}
        public string Text {get; set;}

        public Remark(string remarkId, string type, string parentArticleId, string text) {
            RemarkId = remarkId; 
            Type = type; 
            ParentArticleId = parentArticleId; 
            Text = text; 
        }
    }
}