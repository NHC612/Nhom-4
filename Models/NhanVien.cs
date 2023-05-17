using System.ComponentModel.DataAnnotations;


namespace Super_Book_Store.Models
{
    
    public class NhanVien
    {
        [Key]
        public string NhanVienID {get; set; }
        public string NhanVienName {get; set; }
        public string Sex {get; set; }
        public string PhoneNumber {get; set; }
        public string Address {get; set; }
        
        
        
        
        
    }
}