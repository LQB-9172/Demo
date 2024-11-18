﻿// <auto-generated />
using System;
using Demo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo.Migrations
{
    [DbContext(typeof(Datacontext))]
    partial class DatacontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demo.Data.Audio", b =>
                {
                    b.Property<int>("AudioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AudioId"));

                    b.Property<string>("AudioUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LessonID")
                        .HasColumnType("int");

                    b.HasKey("AudioId");

                    b.HasIndex("LessonID");

                    b.ToTable("Audio");
                });

            modelBuilder.Entity("Demo.Data.Exercise", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseID"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LessonID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseID");

                    b.HasIndex("LessonID");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("Demo.Data.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LessonID")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("LessonID");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Demo.Data.Lesson", b =>
                {
                    b.Property<int>("LessonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LessonID"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProgressID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("completed")
                        .HasColumnType("int");

                    b.HasKey("LessonID");

                    b.HasIndex("ProgressID");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("Demo.Data.Progress", b =>
                {
                    b.Property<int>("ProgressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgressID"));

                    b.Property<double>("CompletionPercentage")
                        .HasColumnType("float");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ProgressID");

                    b.HasIndex("StudentID");

                    b.ToTable("Progress");
                });

            modelBuilder.Entity("Demo.Data.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionID"));

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AudioUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CorrectAnswer")
                        .HasColumnType("int");

                    b.Property<int?>("ExerciseID")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TestID")
                        .HasColumnType("int");

                    b.HasKey("QuestionID");

                    b.HasIndex("ExerciseID");

                    b.HasIndex("TestID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Demo.Data.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Demo.Data.Test", b =>
                {
                    b.Property<int>("TestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProgressID")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestID");

                    b.HasIndex("ProgressID");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("Demo.Data.Audio", b =>
                {
                    b.HasOne("Demo.Data.Lesson", null)
                        .WithMany("Audios")
                        .HasForeignKey("LessonID");
                });

            modelBuilder.Entity("Demo.Data.Exercise", b =>
                {
                    b.HasOne("Demo.Data.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("Demo.Data.Image", b =>
                {
                    b.HasOne("Demo.Data.Lesson", null)
                        .WithMany("Images")
                        .HasForeignKey("LessonID");
                });

            modelBuilder.Entity("Demo.Data.Lesson", b =>
                {
                    b.HasOne("Demo.Data.Progress", null)
                        .WithMany("Lessons")
                        .HasForeignKey("ProgressID");
                });

            modelBuilder.Entity("Demo.Data.Progress", b =>
                {
                    b.HasOne("Demo.Data.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Demo.Data.Question", b =>
                {
                    b.HasOne("Demo.Data.Exercise", null)
                        .WithMany("Questions")
                        .HasForeignKey("ExerciseID");

                    b.HasOne("Demo.Data.Test", null)
                        .WithMany("Questions")
                        .HasForeignKey("TestID");
                });

            modelBuilder.Entity("Demo.Data.Test", b =>
                {
                    b.HasOne("Demo.Data.Progress", null)
                        .WithMany("Tests")
                        .HasForeignKey("ProgressID");
                });

            modelBuilder.Entity("Demo.Data.Exercise", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Demo.Data.Lesson", b =>
                {
                    b.Navigation("Audios");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("Demo.Data.Progress", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Demo.Data.Test", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
