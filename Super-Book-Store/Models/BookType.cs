
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Super_Book_Store.Models
{   
    [Table("BookType")]
    public class BookType
    {
        [Key]
        public string BookID { get; set;}
        public string TypeBook { get; set; }
        [ForeignKey("TypeBook")]
        public Kho? Kho { get; set; }  
        public string BookTypeNew { get; set; }
        public string AuthorName { get; set; }
        public string LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        
        public Language? Language { get; set; }   
       

    }
}