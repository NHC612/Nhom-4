using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Super_Book_Store.Models
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public string DonHangID {get; set; }
        public string KhachHangName {get; set; }
         [ForeignKey("KhachHangName")]
        public KhachHang? KhachHang {get; set; }
        public string BookNameID {get; set; }
        [ForeignKey("BookNameID")]
        public Kho? Kho {get; set; }
        public string LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        
        public Language? Language { get; set; }
        public string NhanVienName {get; set; }
        [ForeignKey("NhanVienName")]
        
        public NhanVien? NhanVien { get; set; }

        public string Address {get; set; }
        

        
    }
}