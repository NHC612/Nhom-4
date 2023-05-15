using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Super_Book_Store.Models
{
    
    public class KhachHang
    {
        [Key]
        public string CodeKhachHang {get; set; }
        public string KhachHangName {get; set; }
        public string PhoneNumber {get; set; }
        public string Address {get; set; }
        public string SachID {get; set; }
        [ForeignKey("SachID")]
        public Sach? Sach {get; set;}
        
        
        
    }
}