using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Super_Book_Store.Models
{
    [Table("Khoss")]
    public class Kho
    {
        [Key]
        public string BookID {get; set; }
        public string TypeBook {get; set; }
        public string NumberbBook {get; set; }
        public string LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language? Language { get; set; }  
        public string BookStoreExists{get; set; }
        public string InventoryBook {get; set; }
        public string ExportBook {get; set; }

        
     
    }
}