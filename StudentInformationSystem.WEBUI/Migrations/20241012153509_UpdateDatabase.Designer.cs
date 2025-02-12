﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentInformationSystem.Data.Concrete.EfCore;

#nullable disable

namespace StudentInformationSystem.Data.Migrations
{
    [DbContext(typeof(SISContext))]
    [Migration("20241012153509_UpdateDatabase")]
    partial class UpdateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("StudentInformationSystem.Entity.Lesson", b =>
                {
                    b.Property<int>("LessonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LessonID");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EnrollmentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<char>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UnenrollmentDate")
                        .HasColumnType("TEXT");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.StudentLesson", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LessonID")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentID", "LessonID");

                    b.HasIndex("LessonID");

                    b.ToTable("StudentLessons");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.StudentTeacher", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherID")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentID", "TeacherID");

                    b.HasIndex("TeacherID");

                    b.ToTable("StudentTeachers");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EnrollmentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<char>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("IBAN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherScore")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UnenrollmentDate")
                        .HasColumnType("TEXT");

                    b.HasKey("TeacherID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.TeacherLesson", b =>
                {
                    b.Property<int>("TeacherID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LessonID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeacherID", "LessonID");

                    b.HasIndex("LessonID");

                    b.ToTable("TeacherLessons");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.StudentLesson", b =>
                {
                    b.HasOne("StudentInformationSystem.Entity.Lesson", "Lesson")
                        .WithMany("StudentLessons")
                        .HasForeignKey("LessonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentInformationSystem.Entity.Student", "Student")
                        .WithMany("StudentLessons")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.StudentTeacher", b =>
                {
                    b.HasOne("StudentInformationSystem.Entity.Student", "Student")
                        .WithMany("StudentTeachers")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentInformationSystem.Entity.Teacher", "Teacher")
                        .WithMany("StudentTeachers")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.TeacherLesson", b =>
                {
                    b.HasOne("StudentInformationSystem.Entity.Lesson", "Lesson")
                        .WithMany("TeacherLessons")
                        .HasForeignKey("LessonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentInformationSystem.Entity.Teacher", "Teacher")
                        .WithMany("TeacherLessons")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.Lesson", b =>
                {
                    b.Navigation("StudentLessons");

                    b.Navigation("TeacherLessons");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.Student", b =>
                {
                    b.Navigation("StudentLessons");

                    b.Navigation("StudentTeachers");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.Teacher", b =>
                {
                    b.Navigation("StudentTeachers");

                    b.Navigation("TeacherLessons");
                });
#pragma warning restore 612, 618
        }
    }
}
