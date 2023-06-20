namespace TravelBlog.Models
{
    public class ArticleModel 
    {
        private string _id {get; set;}
        private string _title {get; set;}
        private DateTime _publishDate {get; set;}
        private string _continent {get; set;}
        private string _country {get; set;}
        private string _region {get; set;}
        private string _introduction {get; set;}
        private SectionModel[] _sections {get; set;}

        public ArticleModel(string id, string title, DateTime publishDate, string continent, string country, string region, string introduction, SectionModel[] sections) {
            _id = id; 
            _title = title; 
            _publishDate = publishDate; 
            _continent = continent; 
            _country = country; 
            _region = region; 
            _introduction = introduction; 
            _sections = sections; 
        }
    }
}

