﻿// <auto-generated />
using System;
using Developer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Developer.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220714200652_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Developer.Domain.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DifficultyCoefficient")
                        .HasColumnType("int");

                    b.Property<Guid>("ExerciseBlockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ExerciseNumber")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseBlockId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Developer.Domain.ExerciseBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExerciseType")
                        .HasColumnType("int");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SubType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("ExerciseBlocks");
                });

            modelBuilder.Entity("Developer.Domain.ExerciseOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Format")
                        .HasColumnType("int");

                    b.Property<int>("OptionNumber")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseOptions");
                });

            modelBuilder.Entity("Developer.Domain.ExerciseVariant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DifficultyCoefficient")
                        .HasColumnType("int");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VariantNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseVariants");
                });

            modelBuilder.Entity("Developer.Domain.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LaborIntensity")
                        .HasColumnType("int");

                    b.Property<int>("LessonNumber")
                        .HasColumnType("int");

                    b.Property<int>("LessonType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Developer.Domain.Exercise", b =>
                {
                    b.HasOne("Developer.Domain.ExerciseBlock", "ExerciseBlock")
                        .WithMany("Exercises")
                        .HasForeignKey("ExerciseBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Developer.Domain.ContentUrlVO", "Content", b1 =>
                        {
                            b1.Property<Guid>("ExerciseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ContentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ContentType")
                                .HasColumnType("int");

                            b1.Property<bool>("ReadOnly")
                                .HasColumnType("bit");

                            b1.Property<string>("ServiceUrl")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ExerciseId");

                            b1.ToTable("Exercises");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseId");
                        });

                    b.OwnsOne("Developer.Domain.TestRefVO", "Test", b1 =>
                        {
                            b1.Property<Guid>("ExerciseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ServiceUrl")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("TestId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("ExerciseId");

                            b1.ToTable("Exercises");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseId");
                        });

                    b.Navigation("Content")
                        .IsRequired();

                    b.Navigation("ExerciseBlock");

                    b.Navigation("Test")
                        .IsRequired();
                });

            modelBuilder.Entity("Developer.Domain.ExerciseBlock", b =>
                {
                    b.HasOne("Developer.Domain.Lesson", "Lesson")
                        .WithMany("ExerciseBlocks")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Developer.Domain.ContentUrlVO", "Content", b1 =>
                        {
                            b1.Property<Guid>("ExerciseBlockId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ContentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ContentType")
                                .HasColumnType("int");

                            b1.Property<bool>("ReadOnly")
                                .HasColumnType("bit");

                            b1.Property<string>("ServiceUrl")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ExerciseBlockId");

                            b1.ToTable("ExerciseBlocks");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseBlockId");
                        });

                    b.Navigation("Content")
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("Developer.Domain.ExerciseOption", b =>
                {
                    b.HasOne("Developer.Domain.Exercise", "Exercise")
                        .WithMany("Options")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("Developer.Domain.ExerciseVariant", b =>
                {
                    b.HasOne("Developer.Domain.Exercise", "Exercise")
                        .WithMany("ExerciseVariants")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Developer.Domain.ContentUrlVO", "Content", b1 =>
                        {
                            b1.Property<Guid>("ExerciseVariantId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ContentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ContentType")
                                .HasColumnType("int");

                            b1.Property<bool>("ReadOnly")
                                .HasColumnType("bit");

                            b1.Property<string>("ServiceUrl")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ExerciseVariantId");

                            b1.ToTable("ExerciseVariants");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseVariantId");
                        });

                    b.Navigation("Content")
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("Developer.Domain.Lesson", b =>
                {
                    b.OwnsOne("Developer.Domain.ContentUrlVO", "TheoryBlock", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ContentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ContentType")
                                .HasColumnType("int");

                            b1.Property<bool>("ReadOnly")
                                .HasColumnType("bit");

                            b1.Property<string>("ServiceUrl")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LessonId");

                            b1.ToTable("Lessons");

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.OwnsOne("Developer.Domain.SubjectVO", "Subject", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FullName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ShortName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LessonId");

                            b1.ToTable("Lessons");

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.Navigation("Subject")
                        .IsRequired();

                    b.Navigation("TheoryBlock")
                        .IsRequired();
                });

            modelBuilder.Entity("Developer.Domain.Exercise", b =>
                {
                    b.Navigation("ExerciseVariants");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("Developer.Domain.ExerciseBlock", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("Developer.Domain.Lesson", b =>
                {
                    b.Navigation("ExerciseBlocks");
                });
#pragma warning restore 612, 618
        }
    }
}
