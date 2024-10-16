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
    [Migration("20241016201213_ReferencesTableUpdated")]
    partial class ReferencesTableUpdated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("StudentInformationSystem.Entity.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ZipCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("AddressID");

                    b.HasIndex("StudentID")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.Assignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FailedTopics")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsGraded")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Submitted")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("AssignmentID");

                    b.HasIndex("StudentID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Assignments");
                });

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

            modelBuilder.Entity("StudentInformationSystem.Entity.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CVVSecurityCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CardholderName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PaymentId");

                    b.HasIndex("StudentID")
                        .IsUnique();

                    b.ToTable("PaymentDetails");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.References", b =>
                {
                    b.Property<int>("ReferencesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentPosition")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReferenceLetterFilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReferencesID");

                    b.HasIndex("TeacherID");

                    b.ToTable("TeacherReferences");
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

                    b.Property<string>("CVFilePath")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

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
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("INTEGER");

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

                    b.Property<int?>("TeacherScore")
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

            modelBuilder.Entity("StudentInformationSystem.Entity.WorkExperience", b =>
                {
                    b.Property<int>("WorkExperienceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherID")
                        .HasColumnType("INTEGER");

                    b.HasKey("WorkExperienceID");

                    b.HasIndex("TeacherID");

                    b.ToTable("WorkExperiences");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.Address", b =>
                {
                    b.HasOne("StudentInformationSystem.Entity.Student", "Student")
                        .WithOne("Address")
                        .HasForeignKey("StudentInformationSystem.Entity.Address", "StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.Assignment", b =>
                {
                    b.HasOne("StudentInformationSystem.Entity.Student", "Student")
                        .WithMany("Assignments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentInformationSystem.Entity.Teacher", "Teacher")
                        .WithMany("Assignments")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.Payment", b =>
                {
                    b.HasOne("StudentInformationSystem.Entity.Student", "Student")
                        .WithOne("PaymentDetails")
                        .HasForeignKey("StudentInformationSystem.Entity.Payment", "StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.References", b =>
                {
                    b.HasOne("StudentInformationSystem.Entity.Teacher", "Teacher")
                        .WithMany("References")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
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

            modelBuilder.Entity("StudentInformationSystem.Entity.WorkExperience", b =>
                {
                    b.HasOne("StudentInformationSystem.Entity.Teacher", "Teacher")
                        .WithMany("WorkExperiences")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.Lesson", b =>
                {
                    b.Navigation("StudentLessons");

                    b.Navigation("TeacherLessons");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.Student", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Assignments");

                    b.Navigation("PaymentDetails");

                    b.Navigation("StudentLessons");

                    b.Navigation("StudentTeachers");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.Teacher", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("References");

                    b.Navigation("StudentTeachers");

                    b.Navigation("TeacherLessons");

                    b.Navigation("WorkExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
