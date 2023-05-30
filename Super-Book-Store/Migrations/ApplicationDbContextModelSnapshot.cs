﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Super_Book_Store.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Super_Book_Store.Models.BookType", b =>
                {
                    b.Property<string>("BookID")
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookTypeNew")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeBook")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookID");

                    b.HasIndex("LanguageID");

                    b.HasIndex("TypeBook");

                    b.ToTable("BookType");
                });

            modelBuilder.Entity("Super_Book_Store.Models.DonHang", b =>
                {
                    b.Property<string>("DonHangID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookNameID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KhachHangName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NhanVienName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DonHangID");

                    b.HasIndex("BookNameID");

                    b.HasIndex("KhachHangName");

                    b.HasIndex("LanguageID");

                    b.HasIndex("NhanVienName");

                    b.ToTable("DonHang");
                });

            modelBuilder.Entity("Super_Book_Store.Models.KhachHang", b =>
                {
                    b.Property<string>("KhachHangID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookNameID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KhachHangName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("KhachHangID");

                    b.HasIndex("BookNameID");

                    b.HasIndex("LanguageID");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("Super_Book_Store.Models.Kho", b =>
                {
                    b.Property<string>("BookID")
                        .HasColumnType("TEXT");

                    b.Property<string>("BookStoreExists")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExportBook")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InventoryBook")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumberbBook")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeBook")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookID");

                    b.HasIndex("LanguageID");

                    b.ToTable("Khoss");
                });

            modelBuilder.Entity("Super_Book_Store.Models.Language", b =>
                {
                    b.Property<string>("LanguageID")
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LanguageID");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("Super_Book_Store.Models.NhanVien", b =>
                {
                    b.Property<string>("NhanVienID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NhanVienName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("NhanVienID");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("Super_Book_Store.Models.BookType", b =>
                {
                    b.HasOne("Super_Book_Store.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Super_Book_Store.Models.Kho", "Kho")
                        .WithMany()
                        .HasForeignKey("TypeBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kho");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Super_Book_Store.Models.DonHang", b =>
                {
                    b.HasOne("Super_Book_Store.Models.Kho", "Kho")
                        .WithMany()
                        .HasForeignKey("BookNameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Super_Book_Store.Models.KhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("KhachHangName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Super_Book_Store.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Super_Book_Store.Models.NhanVien", "NhanVien")
                        .WithMany()
                        .HasForeignKey("NhanVienName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("Kho");

                    b.Navigation("Language");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("Super_Book_Store.Models.KhachHang", b =>
                {
                    b.HasOne("Super_Book_Store.Models.Kho", "Kho")
                        .WithMany()
                        .HasForeignKey("BookNameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Super_Book_Store.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kho");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Super_Book_Store.Models.Kho", b =>
                {
                    b.HasOne("Super_Book_Store.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });
#pragma warning restore 612, 618
        }
    }
}
