using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Super_Book_Store.Models
{   
    [Table("Language")]
    public class Language
    {
        [Key]
        public string LanguageID { get; set; }
        public string LanguageName { get; set; }
        


    }
}