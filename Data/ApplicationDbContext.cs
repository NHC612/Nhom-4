using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Super_Book_Store.Models;
namespace Super_Book_Store.Data
{
     public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Super_Book_Store.Models.KhachHang> KhachHang { get; set; } = default!;

        public DbSet<Super_Book_Store.Models.Kho> Kho { get; set; } = default!;

        public DbSet<Super_Book_Store.Models.NhaXuatBan> NhaXuatBan { get; set; } = default!;

        public DbSet<Super_Book_Store.Models.Language> Language { get; set; } = default!;

        public DbSet<Super_Book_Store.Models.BookType> BookType { get; set; } = default!;

        public DbSet<Super_Book_Store.Models.NhanVien> NhanVien { get; set; } = default!;
       

        

     

        

        
    }

}