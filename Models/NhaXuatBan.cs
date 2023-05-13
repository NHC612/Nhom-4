using System.ComponentModel.DataAnnotations;

namespace Super_Book_Store.Models
{
    
    public class NhaXuatBan
    {
        [Key]
        public string NXBName {get; set; }
        
        public string Address {get; set; }
        
    }
}