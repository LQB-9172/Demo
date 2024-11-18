﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test.Data;

#nullable disable

namespace test.Migrations
{
    [DbContext(typeof(Datacontext))]
    [Migration("20241007042536_test2")]
    partial class test2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("test.Data.Audio", b =>
                {
                    b.Property<int>("AudioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AudioID"));

                    b.Property<string>("AudioURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExerciseID")
                        .HasColumnType("int");

                    b.Property<int?>("LessonID")
                        .HasColumnType("int");

                    b.HasKey("AudioID");

                    b.HasIndex("ExerciseID");

                    b.HasIndex("LessonID");

                    b.ToTable("Audio");
                });

            modelBuilder.Entity("test.Data.Exercise", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseID"));

                    b.Property<string>("AnswerType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AudioID")
                        .HasColumnType("int");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageID")
                        .HasColumnType("int");

                    b.Property<int>("LessonID")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseID");

                    b.HasIndex("LessonID");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("test.Data.Image", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExerciseID")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LessonID")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionID")
                        .HasColumnType("int");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("ImageID");

                    b.HasIndex("ExerciseID");

                    b.HasIndex("LessonID");

                    b.HasIndex("QuestionID")
                        .IsUnique()
                        .HasFilter("[QuestionID] IS NOT NULL");

                    b.HasIndex("StudentID")
                        .IsUnique()
                        .HasFilter("[StudentID] IS NOT NULL");

                    b.HasIndex("TeacherID")
                        .IsUnique()
                        .HasFilter("[TeacherID] IS NOT NULL");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("test.Data.Lesson", b =>
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

                    b.HasKey("LessonID");

                    b.HasIndex("ProgressID");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("test.Data.Progress", b =>
                {
                    b.Property<int>("ProgressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgressID"));

                    b.Property<DateTime?>("CompleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<int>("LessonID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int?>("TestID")
                        .HasColumnType("int");

                    b.Property<int>("TimeSpent")
                        .HasColumnType("int");

                    b.HasKey("ProgressID");

                    b.HasIndex("StudentID")
                        .IsUnique();

                    b.ToTable("Progress");
                });

            modelBuilder.Entity("test.Data.Question", b =>
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

                    b.Property<int>("CorrectAnswer")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestID")
                        .HasColumnType("int");

                    b.HasKey("QuestionID");

                    b.HasIndex("TestID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("test.Data.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.HasIndex("UserID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("test.Data.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("TeacherID");

                    b.HasIndex("UserID");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("test.Data.Test", b =>
                {
                    b.Property<int>("TestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestID"));

                    b.Property<int>("MaxScore")
                        .HasColumnType("int");

                    b.Property<int?>("ProgressID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestID");

                    b.HasIndex("ProgressID");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("test.Data.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Role")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("test.Data.Audio", b =>
                {
                    b.HasOne("test.Data.Exercise", null)
                        .WithMany("Audios")
                        .HasForeignKey("ExerciseID");

                    b.HasOne("test.Data.Lesson", "Lesson")
                        .WithMany("Audio")
                        .HasForeignKey("LessonID");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("test.Data.Exercise", b =>
                {
                    b.HasOne("test.Data.Lesson", "Lesson")
                        .WithMany("Exercise")
                        .HasForeignKey("LessonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("test.Data.Image", b =>
                {
                    b.HasOne("test.Data.Exercise", "Exercise")
                        .WithMany("Image")
                        .HasForeignKey("ExerciseID");

                    b.HasOne("test.Data.Lesson", "Lesson")
                        .WithMany("Image")
                        .HasForeignKey("LessonID");

                    b.HasOne("test.Data.Question", "Question")
                        .WithOne("Image")
                        .HasForeignKey("test.Data.Image", "QuestionID");

                    b.HasOne("test.Data.Student", "Student")
                        .WithOne("Images")
                        .HasForeignKey("test.Data.Image", "StudentID");

                    b.HasOne("test.Data.Teacher", "Teacher")
                        .WithOne("Images")
                        .HasForeignKey("test.Data.Image", "TeacherID");

                    b.Navigation("Exercise");

                    b.Navigation("Lesson");

                    b.Navigation("Question");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("test.Data.Lesson", b =>
                {
                    b.HasOne("test.Data.Progress", null)
                        .WithMany("Lesson")
                        .HasForeignKey("ProgressID");
                });

            modelBuilder.Entity("test.Data.Progress", b =>
                {
                    b.HasOne("test.Data.Student", "Student")
                        .WithOne("Progress")
                        .HasForeignKey("test.Data.Progress", "StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("test.Data.Question", b =>
                {
                    b.HasOne("test.Data.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("test.Data.Student", b =>
                {
                    b.HasOne("test.Data.User", "User")
                        .WithMany("Student")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("test.Data.Teacher", b =>
                {
                    b.HasOne("test.Data.User", "User")
                        .WithMany("Teacher")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("test.Data.Test", b =>
                {
                    b.HasOne("test.Data.Progress", null)
                        .WithMany("Test")
                        .HasForeignKey("ProgressID");
                });

            modelBuilder.Entity("test.Data.Exercise", b =>
                {
                    b.Navigation("Audios");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("test.Data.Lesson", b =>
                {
                    b.Navigation("Audio");

                    b.Navigation("Exercise");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("test.Data.Progress", b =>
                {
                    b.Navigation("Lesson");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("test.Data.Question", b =>
                {
                    b.Navigation("Image");
                });

            modelBuilder.Entity("test.Data.Student", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Progress");
                });

            modelBuilder.Entity("test.Data.Teacher", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("test.Data.Test", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("test.Data.User", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
