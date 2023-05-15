using System.ComponentModel.DataAnnotations;

namespace Super_Book_Store.Models
{
    
    public class Sach
    {
        [Key]
        public string SachID {get; set; }
        
        public string SachName {get; set; }
        
        
    }
}