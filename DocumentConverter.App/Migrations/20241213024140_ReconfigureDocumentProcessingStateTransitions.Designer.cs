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
    [Migration("20241213024140_ReconfigureDocumentProcessingStateTransitions")]
    partial class ReconfigureDocumentProcessingStateTransitions
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
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("documents", (string)null);
                });

            modelBuilder.Entity("DocumentConverter.App.Models.DocumentFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uuid")
                        .HasColumnName("document_id");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("format");

                    b.Property<long>("Size")
                        .HasColumnType("bigint")
                        .HasColumnName("size");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("document_files", (string)null);
                });

            modelBuilder.Entity("DocumentConverter.App.Models.DocumentFileProcessingState", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("DocumentFileId")
                        .HasColumnType("uuid")
                        .HasColumnName("document_file_id");

                    b.Property<string>("FromState")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("from_state");

                    b.Property<string>("ToState")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("to_state");

                    b.HasKey("Id");

                    b.ToTable("DocumentFileProcessingStates");
                });

            modelBuilder.Entity("DocumentConverter.App.Models.DocumentFileProcessingStateTransition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("DocumentFileId")
                        .HasColumnType("uuid")
                        .HasColumnName("document_file_id");

                    b.Property<string>("FromState")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("from_state");

                    b.Property<string>("ToState")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("to_state");

                    b.HasKey("Id");

                    b.HasIndex("DocumentFileId");

                    b.ToTable("document_file_processing_state_transitions", (string)null);
                });

            modelBuilder.Entity("DocumentConverter.App.Models.DocumentProcessingStateTransition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uuid")
                        .HasColumnName("document_id");

                    b.Property<string>("FromState")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("from_state");

                    b.Property<string>("ToState")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("to_state");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("document_processing_state_transitions", (string)null);
                });

            modelBuilder.Entity("DocumentConverter.App.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("DownloadLimit")
                        .HasColumnType("integer")
                        .HasColumnName("download_limit");

                    b.Property<int>("FileSizeLimit")
                        .HasColumnType("integer")
                        .HasColumnName("file_size_limit");

                    b.Property<int>("UploadLimit")
                        .HasColumnType("integer")
                        .HasColumnName("upload_limit");

                    b.HasKey("Id");

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
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DocumentConverter.App.Models.DocumentFileProcessingStateTransition", b =>
                {
                    b.HasOne("DocumentConverter.App.Models.DocumentFile", null)
                        .WithMany("ProcessingStateTransitions")
                        .HasForeignKey("DocumentFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DocumentConverter.App.Models.DocumentProcessingStateTransition", b =>
                {
                    b.HasOne("DocumentConverter.App.Models.Document", null)
                        .WithMany("ProcessingStateTransitions")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DocumentConverter.App.Models.Document", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("ProcessingStateTransitions");
                });

            modelBuilder.Entity("DocumentConverter.App.Models.DocumentFile", b =>
                {
                    b.Navigation("ProcessingStateTransitions");
                });

            modelBuilder.Entity("DocumentConverter.App.Models.User", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
