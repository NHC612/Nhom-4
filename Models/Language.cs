using System.ComponentModel.DataAnnotations;

namespace Super_Book_Store.Models
{
    
    public class Language
    {
        [Key]
        public string LanguageID {get; set; }
        
        public string  LanguageName {get; set; }
        
    }
}