using System.ComponentModel.DataAnnotations;

namespace Super_Book_Store.Models
{
    
    public class KhachHang
    {
        [Key]
        public string CodeKhachHang {get; set; }
        public string KhachHangName {get; set; }
        public string PhoneNumber {get; set; }
        public string Address {get; set; }
        
    }
}