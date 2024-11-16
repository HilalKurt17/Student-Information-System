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
    [Migration("20241116142426_PasswordsTableCreated")]
    partial class PasswordsTableCreated
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

                    b.Property<string>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("DueTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FailedTopics")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsGraded")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LessonID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentAssignmentFilePath")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SubmittedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubmittedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeacherAssignmentFilePath")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedTime")
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

            modelBuilder.Entity("StudentInformationSystem.Entity.Passwords", b =>
                {
                    b.Property<int>("PasswordsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("userMail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PasswordsID");

                    b.ToTable("Passwords");
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

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
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
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentPosition")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mail")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReferenceLetterFilePath")
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

                    b.Property<bool>("UnenrollmentState")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

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
                    b.Property<int>("PrivateLessonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ELClassification")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EnrollmentState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LessonDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LessonDetails")
                        .HasColumnType("TEXT");

                    b.Property<string>("LessonEndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LessonEndTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LessonMode")
                        .HasColumnType("TEXT");

                    b.Property<string>("LessonName")
                        .HasColumnType("TEXT");

                    b.Property<double>("LessonPrice")
                        .HasColumnType("REAL");

                    b.Property<string>("LessonStartDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LessonStartTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("RemoveLesson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<int?>("StudentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentTeacherComment")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeacherLessonScore")
                        .HasColumnType("INTEGER");

                    b.HasKey("PrivateLessonID");

                    b.HasIndex("TeacherID");

                    b.HasIndex("StudentID", "TeacherID");

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

                    b.Property<bool>("IsApproved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0);

                    b.Property<bool>("UnenrollmentState")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.HasKey("TeacherID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudentInformationSystem.Entity.TeacherLesson", b =>
                {
                    b.Property<int>("TeacherID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LessonID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsChecked")
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
                        .HasForeignKey("StudentID");

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
