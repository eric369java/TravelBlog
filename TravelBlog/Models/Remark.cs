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

        public Remark(string _RemarkId, string _Type, string _ParentArticleId, string _Text) {
            RemarkId = _RemarkId; 
            Type = _Type; 
            ParentArticleId = _ParentArticleId; 
            Text = _Text; 
        }
    }
}