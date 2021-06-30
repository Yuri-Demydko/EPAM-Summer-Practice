﻿// <auto-generated />
using System;
using EFDAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFDAO.Migrations
{
    [DbContext(typeof(EFDBContext))]
    [Migration("20210630174611_Init_0")]
    partial class Init_0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DTO.Entities.EFBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EFUserProfileId")
                        .HasColumnType("int");

                    b.Property<int?>("EFUserProfileId1")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EFUserProfileId");

                    b.HasIndex("EFUserProfileId1");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DTO.Entities.EFUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DTO.Entities.EFUserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("DTO.Entities.EFBook", b =>
                {
                    b.HasOne("DTO.Entities.EFUserProfile", null)
                        .WithMany("FavoriteBooks")
                        .HasForeignKey("EFUserProfileId");

                    b.HasOne("DTO.Entities.EFUserProfile", null)
                        .WithMany("UploadedBooks")
                        .HasForeignKey("EFUserProfileId1");
                });

            modelBuilder.Entity("DTO.Entities.EFUserProfile", b =>
                {
                    b.HasOne("DTO.Entities.EFUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DTO.Entities.EFUserProfile", b =>
                {
                    b.Navigation("FavoriteBooks");

                    b.Navigation("UploadedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
