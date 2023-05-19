using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Super_Book_Store.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public string NhanVienID {get; set; }
        public string NhanVienName {get; set; }
        public string Sex {get; set; }
        public string Address{get; set; }
        
    }
}