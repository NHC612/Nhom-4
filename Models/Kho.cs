using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Super_Book_Store.Models
{
    
    public class Kho
    {
        [Key]
        public string BookName {get; set; }
        public int SoLuong {get; set; }
        public int TonKho {get; set; }
        public int NhapKho {get; set; }
        public int XuatKho {get; set; }
        
     
    }
}