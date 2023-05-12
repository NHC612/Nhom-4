using System.ComponentModel.DataAnnotations;

namespace Super_Book_Store.Models
{
    
    public class KhachHang
    {
        [Key]
        public string KhachHangID {get; set; }
        public string KhachHangName {get; set; }
        public int PhoneNumber {get; set; }
        public string Address {get; set; }
        
    }
}