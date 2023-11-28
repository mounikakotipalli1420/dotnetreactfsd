﻿// <auto-generated />
using System;
using FeedBackAppA.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FeedBackAppA.Migrations
{
    [DbContext(typeof(FeedBackContext))]
    [Migration("20231124110908_mi")]
    partial class mi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FeedBackAppA.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("FeedBackAppA.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("SurveyId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("FeedBackAppA.Models.QuestionResponse", b =>
                {
                    b.Property<int>("QuestionResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionResponseId"), 1L, 1);

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("SurveySubmissionId")
                        .HasColumnType("int");

                    b.HasKey("QuestionResponseId");

                    b.HasIndex("SurveySubmissionId");

                    b.ToTable("QuestionResponses");
                });

            modelBuilder.Entity("FeedBackAppA.Models.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ResponseCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("FeedBackAppA.Models.SurveyReport", b =>
                {
                    b.Property<int>("RespondentCount")
                        .HasColumnType("int");

                    b.Property<int>("SurveyId")
                        .HasColumnType("int");

                    b.Property<string>("SurveyTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SurveyReports");
                });

            modelBuilder.Entity("FeedBackAppA.Models.SurveySubmission", b =>
                {
                    b.Property<int>("SurveySubmissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SurveySubmissionId"), 1L, 1);

                    b.Property<int>("SurveyId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SurveySubmissionId");

                    b.HasIndex("SurveyId")
                        .IsUnique();

                    b.HasIndex("Username1");

                    b.ToTable("SurveySubmissions");
                });

            modelBuilder.Entity("FeedBackAppA.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("Key")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FeedBackAppA.Models.Answer", b =>
                {
                    b.HasOne("FeedBackAppA.Models.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("FeedBackAppA.Models.Question", b =>
                {
                    b.HasOne("FeedBackAppA.Models.Survey", null)
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("FeedBackAppA.Models.QuestionResponse", b =>
                {
                    b.HasOne("FeedBackAppA.Models.SurveySubmission", null)
                        .WithMany("QuestionResponses")
                        .HasForeignKey("SurveySubmissionId");
                });

            modelBuilder.Entity("FeedBackAppA.Models.SurveySubmission", b =>
                {
                    b.HasOne("FeedBackAppA.Models.Survey", "Survey")
                        .WithOne("SurveySubmissions")
                        .HasForeignKey("FeedBackAppA.Models.SurveySubmission", "SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FeedBackAppA.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Username1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FeedBackAppA.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("FeedBackAppA.Models.Survey", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("SurveySubmissions")
                        .IsRequired();
                });

            modelBuilder.Entity("FeedBackAppA.Models.SurveySubmission", b =>
                {
                    b.Navigation("QuestionResponses");
                });
#pragma warning restore 612, 618
        }
    }
}
