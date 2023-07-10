﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticaWebServices.Data;

#nullable disable

namespace PracticaWebServices.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnrollmentSection", b =>
                {
                    b.Property<int>("enrollmentsid")
                        .HasColumnType("int");

                    b.Property<int>("sectionsid")
                        .HasColumnType("int");

                    b.HasKey("enrollmentsid", "sectionsid");

                    b.HasIndex("sectionsid");

                    b.ToTable("EnrollmentSection");
                });

            modelBuilder.Entity("PracticaWebServices.Entities.Enrollment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTimeOffset>("created_date")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("deleted_date")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("id_persona")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("id_persona");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("PracticaWebServices.Entities.Faculty", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTimeOffset>("created_date")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("deleted_date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("PracticaWebServices.Entities.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ci")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("created_date")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("deleted_date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PracticaWebServices.Entities.School", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTimeOffset>("created_date")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("deleted_date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("id_faculty")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("id_faculty");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("PracticaWebServices.Entities.Section", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTimeOffset>("created_date")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("deleted_date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("hl")
                        .HasColumnType("real");

                    b.Property<float>("hp")
                        .HasColumnType("real");

                    b.Property<float>("ht")
                        .HasColumnType("real");

                    b.Property<int?>("id_school")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("semester")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("uc")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_school");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("EnrollmentSection", b =>
                {
                    b.HasOne("PracticaWebServices.Entities.Enrollment", null)
                        .WithMany()
                        .HasForeignKey("enrollmentsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticaWebServices.Entities.Section", null)
                        .WithMany()
                        .HasForeignKey("sectionsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PracticaWebServices.Entities.Enrollment", b =>
                {
                    b.HasOne("PracticaWebServices.Entities.Person", "person")
                        .WithMany("enrollments")
                        .HasForeignKey("id_persona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("person");
                });

            modelBuilder.Entity("PracticaWebServices.Entities.School", b =>
                {
                    b.HasOne("PracticaWebServices.Entities.Faculty", "faculty")
                        .WithMany("schools")
                        .HasForeignKey("id_faculty");

                    b.Navigation("faculty");
                });

            modelBuilder.Entity("PracticaWebServices.Entities.Section", b =>
                {
                    b.HasOne("PracticaWebServices.Entities.School", "school")
                        .WithMany("sections")
                        .HasForeignKey("id_school");

                    b.Navigation("school");
                });

            modelBuilder.Entity("PracticaWebServices.Entities.Faculty", b =>
                {
                    b.Navigation("schools");
                });

            modelBuilder.Entity("PracticaWebServices.Entities.Person", b =>
                {
                    b.Navigation("enrollments");
                });

            modelBuilder.Entity("PracticaWebServices.Entities.School", b =>
                {
                    b.Navigation("sections");
                });
#pragma warning restore 612, 618
        }
    }
}
