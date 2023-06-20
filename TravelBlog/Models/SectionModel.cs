namespace TravelBlog.Models
{
    public class SectionModel 
    {
        private string _subtitle {get; set;}
        private string _placeId {get; set;}

        private string[] _paragraphs {get; set;}

        SectionModel(string subtitle, string placeId, string[] paragraphs) {
            _subtitle = subtitle; 
            _placeId = placeId;
            _paragraphs = paragraphs; 
        }

    }
}