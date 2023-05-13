﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Super_Book_Store.Data;

#nullable disable

namespace Super_Book_Store.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230512115614_Create_Table_NhaXuatBan")]
    partial class Create_Table_NhaXuatBan
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Super_Book_Store.Models.KhachHang", b =>
                {
                    b.Property<string>("CodeKhachHang")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KhachHangName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("CodeKhachHang");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("Super_Book_Store.Models.Kho", b =>
                {
                    b.Property<string>("BookName")
                        .HasColumnType("TEXT");

                    b.Property<int>("NhapKho")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SoLuong")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TonKho")
                        .HasColumnType("INTEGER");

                    b.Property<int>("XuatKho")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookName");

                    b.ToTable("Kho");
                });

            modelBuilder.Entity("Super_Book_Store.Models.NhaXuatBan", b =>
                {
                    b.Property<string>("NXBName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("NXBName");

                    b.ToTable("NhaXuatBan");
                });
#pragma warning restore 612, 618
        }
    }
}
