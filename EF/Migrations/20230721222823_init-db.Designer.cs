﻿// <auto-generated />
using System;
using EF.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClassroomManagementSystem.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230721222823_init-db")]
    partial class initdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClassroomManagementSystem.EF.Entities.Classroom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ClassroomNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("ClassroomManagementSystem.EF.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClassroomId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ClassroomManagementSystem.EF.Entities.Student", b =>
                {
                    b.HasOne("ClassroomManagementSystem.EF.Entities.Classroom", "Classroom")
                        .WithMany("Students")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("ClassroomManagementSystem.EF.Entities.Classroom", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
