using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Super_Book_Store.Models
{   
    [Table("Language")]
    public class Language
    {
        [Key]
        public string LanguageID { get; set; }
        public string LanguageName { get; set; }
        // public DbSet<Super_Book_Store.Models.Language> Language { get; set; } = default!;


    }
}