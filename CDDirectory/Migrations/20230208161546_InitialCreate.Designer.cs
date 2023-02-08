﻿// <auto-generated />
using System;
using CDDirectory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CDDirectory.Migrations
{
    [DbContext(typeof(CDContext))]
    [Migration("20230208161546_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("CDDirectory.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("CDDirectory.Models.CD", b =>
                {
                    b.Property<int>("CDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CDId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("UserId");

                    b.ToTable("CD");
                });

            modelBuilder.Entity("CDDirectory.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CDDirectory.Models.CD", b =>
                {
                    b.HasOne("CDDirectory.Models.Artist", "Artist")
                        .WithMany("CD")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CDDirectory.Models.User", "User")
                        .WithMany("CD")
                        .HasForeignKey("UserId");

                    b.Navigation("Artist");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CDDirectory.Models.Artist", b =>
                {
                    b.Navigation("CD");
                });

            modelBuilder.Entity("CDDirectory.Models.User", b =>
                {
                    b.Navigation("CD");
                });
#pragma warning restore 612, 618
        }
    }
}