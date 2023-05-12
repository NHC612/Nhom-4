
using System.ComponentModel.DataAnnotations;

namespace Super_Book_Store.Models
{
    public class BookType
    {
        [Key]
        public string BookID { get; set;}
        public string BookName { get; set; }
        public string BookTypeName { get; set; }
       

    }
}