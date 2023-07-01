using System.ComponentModel.DataAnnotations; 

namespace TravelBlog.Models
{
    public class Image 
    {   
        [Key]
        public string ImageId {get; set;}
        public string ParentArticleId {get; set;}
        public string ImageUrl {get; set;}
        public string Caption {get; set;}
        public string Country {get; set;}
        public string PlaceId {get; set;}
    
        public Image(string _ImageId, string _ParentArticleId, string _ImageUrl, string _Caption, string _Country, string _PlaceId) {
            ImageId = _ImageId;
            ParentArticleId = _ParentArticleId;
            ImageUrl = _ImageUrl; 
            Caption = _Caption; 
            Country = _Country; 
            PlaceId = _PlaceId; 
        }   

    }
}
