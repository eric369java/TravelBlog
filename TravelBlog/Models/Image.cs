using System.ComponentModel.DataAnnotations; 

namespace TravelBlog.Models
{
    public class Image 
    {   
        [Key]
        public int ImageId {get; set;}
        public int ParentArticleId {get; set;}
        public string ImageUrl {get; set;}
        public string Caption {get; set;}
        public string Country {get; set;}
        public string PlaceId {get; set;}

        public Image(int imageId, int parentArticleId, string imageUrl, string caption, string country, string placeId) {
            ImageId = imageId;
            ParentArticleId = parentArticleId;
            ImageUrl = imageUrl; 
            Caption = caption; 
            Country = country; 
            PlaceId = placeId; 
        }   

    }
}
