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

        public Image(string imageId, string parentArticleId, string imageUrl, string caption, string country, string placeId) {
            ImageId = imageId;
            ParentArticleId = parentArticleId;
            ImageUrl = imageUrl; 
            Caption = caption; 
            Country = country; 
            PlaceId = placeId; 
        }   

    }
}
