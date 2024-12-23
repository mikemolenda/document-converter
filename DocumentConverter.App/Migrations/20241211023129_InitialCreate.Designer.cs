﻿// <auto-generated />
using System;
using DocumentConverter.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DocumentConverter.App.Migrations
{
    [DbContext(typeof(DocumentConverterAppContext))]
    [Migration("20241211023129_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DocumentConverter.App.Models.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("documents", (string)null);
                });

            modelBuilder.Entity("DocumentConverter.App.Models.DocumentFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DocumentId")
                        .HasColumnType("uuid");

                    b.Property<int>("Format")
                        .HasColumnType("integer");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("document_files", (string)null);
                });

            modelBuilder.Entity("DocumentConverter.App.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DownloadLimit")
                        .HasColumnType("integer");

                    b.Property<int>("FileSizeLimit")
                        .HasColumnType("integer");

                    b.Property<int>("UploadLimit")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("DocumentConverter.App.Models.Document", b =>
                {
                    b.HasOne("DocumentConverter.App.Models.User", null)
                        .WithMany("Documents")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DocumentConverter.App.Models.DocumentFile", b =>
                {
                    b.HasOne("DocumentConverter.App.Models.Document", null)
                        .WithMany("Files")
                        .HasForeignKey("DocumentId");
                });

            modelBuilder.Entity("DocumentConverter.App.Models.Document", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("DocumentConverter.App.Models.User", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
