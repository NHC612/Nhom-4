using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Super_Book_Store.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public string KhachHangID {get; set; }
        public string KhachHangName {get; set; }
        public string Sex {get; set; }
        public string BookNameID {get; set; }
        [ForeignKey("BookNameID")]
        public Kho? Kho {get; set; }
        public string LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        
        public Language? Language { get; set; }
        public string PhoneNumber{get; set; }
        public string Address{get; set; }
        
    }
}