
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Super_Book_Store.Models
{   
    [Table("BookType")]
    public class BookType
    {
        [Key]
        public int BookID { get; set;}
         public string BookNameID { get; set; }
         [ForeignKey("BookNameID")]
        public Kho? Kho {get; set; }
        public string BookTypeNew { get; set; }
        public string AuthorName { get; set; }
        
        public string LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        
        public Language? Language { get; set; }   
       

    }
}