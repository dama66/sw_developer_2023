﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Swd.TimeManager.Model;

#nullable disable

namespace Swd.TimeManager.Model.Migrations
{
    [DbContext(typeof(TimeManagerContext))]
    partial class TimeManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Swd.TimeManager.Model.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("[LastName] + ' ' + [FirstName]", true);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nVarchar(100)");

                    b.Property<DateOnly>("EntryDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("ExitDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nVarchar(50)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("LastName")
                        .HasDatabaseName("idx_lastname");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Swd.TimeManager.Model.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nVarchar(50)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("Name")
                        .HasDatabaseName("idx_projectname");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Swd.TimeManager.Model.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nVarchar(50)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("Name")
                        .HasDatabaseName("idx_taskname");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("Swd.TimeManager.Model.TimeRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.Property<decimal>("Duration")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasDefaultValue(0m);

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<long>("TaskId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nVarchar(50)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("Date")
                        .HasDatabaseName("idx_taskname");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TaskId");

                    b.ToTable("TimeRecord");
                });

            modelBuilder.Entity("Swd.TimeManager.Model.TimeRecord", b =>
                {
                    b.HasOne("Swd.TimeManager.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Swd.TimeManager.Model.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Swd.TimeManager.Model.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Project");

                    b.Navigation("Task");
                });
#pragma warning restore 612, 618
        }
    }
}
