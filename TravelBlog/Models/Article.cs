namespace TravelBlog.Models
{
    public class Article 
    { 
        public int Id {get; set;}
        public string Title {get; set;}
        public DateTime PublishDate {get; set;}
        public string Continent {get; set;}
        public string Country {get; set;}
        public string Introduction {get; set;}
        public string CoverImage {get; set;}

        public ICollection<Paragraph> Paragraphs {get; } = new List<Paragraph>();  

        public ICollection<Remark> Remarks {get; } = new List<Remark>(); 
    }
}

