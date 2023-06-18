﻿// <auto-generated />
using System;
using DomainLayer.MigrationFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DomainLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomainLayer.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DomainLayer.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DomainLayer.EmployeeEvaluation", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EvaluationId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "EvaluationId");

                    b.HasIndex("EvaluationId");

                    b.ToTable("GetEmployeeEvaluations");
                });

            modelBuilder.Entity("DomainLayer.EmployeeEvaluationAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EmployeeAnswer")
                        .HasColumnType("float");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<double>("FinalAnswer")
                        .HasColumnType("float");

                    b.Property<double>("ManagerAnswer")
                        .HasColumnType("float");

                    b.Property<int>("QuestionsEvaluationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("QuestionsEvaluationId");

                    b.ToTable("EmployeeEvaluationAnswers");
                });

            modelBuilder.Entity("DomainLayer.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EvaluationCreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EvaluationEndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EvaluationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EvaluationStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EvaluationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("DomainLayer.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("DomainLayer.QuestionsEvaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EvaluationId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvaluationId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionsEvaluations");
                });

            modelBuilder.Entity("DomainLayer.Employee", b =>
                {
                    b.HasOne("DomainLayer.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DomainLayer.EmployeeEvaluation", b =>
                {
                    b.HasOne("DomainLayer.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Evaluation", "Evaluation")
                        .WithMany()
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Evaluation");
                });

            modelBuilder.Entity("DomainLayer.EmployeeEvaluationAnswer", b =>
                {
                    b.HasOne("DomainLayer.Employee", "Employee")
                        .WithMany("EmployeeEvaluationAnswers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.QuestionsEvaluation", "QuestionsEvaluation")
                        .WithMany("EmployeeEvaluationAnswers")
                        .HasForeignKey("QuestionsEvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("QuestionsEvaluation");
                });

            modelBuilder.Entity("DomainLayer.Evaluation", b =>
                {
                    b.HasOne("DomainLayer.Department", "Department")
                        .WithMany("Evaluations")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DomainLayer.QuestionsEvaluation", b =>
                {
                    b.HasOne("DomainLayer.Evaluation", "Evaluation")
                        .WithMany("QuestionsEvaluations")
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Questions", "Questions")
                        .WithMany("QuestionsEvaluations")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evaluation");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("DomainLayer.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Evaluations");
                });

            modelBuilder.Entity("DomainLayer.Employee", b =>
                {
                    b.Navigation("EmployeeEvaluationAnswers");
                });

            modelBuilder.Entity("DomainLayer.Evaluation", b =>
                {
                    b.Navigation("QuestionsEvaluations");
                });

            modelBuilder.Entity("DomainLayer.Questions", b =>
                {
                    b.Navigation("QuestionsEvaluations");
                });

            modelBuilder.Entity("DomainLayer.QuestionsEvaluation", b =>
                {
                    b.Navigation("EmployeeEvaluationAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}
