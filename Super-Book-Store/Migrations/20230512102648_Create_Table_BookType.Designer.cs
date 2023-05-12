﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Super_Book_Store.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230512102648_Create_Table_BookType")]
    partial class Create_Table_BookType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Super_Book_Store.Models.BookType", b =>
                {
                    b.Property<string>("BookID")
                        .HasColumnType("TEXT");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookID");

                    b.ToTable("BookType");
                });
#pragma warning restore 612, 618
        }
    }
}
