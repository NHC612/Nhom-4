using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Super_Book_Store.Models
{
    
    public class BookType
    {
        [Key]
        public string BookID {get; set; }
        
        public string  BookName {get; set; }
        public string  AuthorName {get; set; }
        public string  BookTypeName {get; set; }
        public string  LanguageID {get; set; }
        [ForeignKey("LanguageID")]
        public Language? Language {get; set; }

        
    }
}