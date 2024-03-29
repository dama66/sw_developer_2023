﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Swd.Messanger.Model;

#nullable disable

namespace Swd.Messanger.Model.Migrations
{
    [DbContext(typeof(MessangerContext))]
    partial class MessangerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Swd.Messanger.Model.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Confirmed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Delivered")
                        .HasColumnType("datetime2");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.Property<DateTime>("Sent")
                        .HasColumnType("datetime2");

                    b.Property<string>("SentMessage")
                        .IsRequired()
                        .HasColumnType("nVarchar(MAX)");

                    b.Property<long>("StateId")
                        .HasColumnType("bigint");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Validity")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("StateId");

                    b.HasIndex("TypeId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Swd.Messanger.Model.MessageState", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nVarchar(20)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("MessageState");
                });

            modelBuilder.Entity("Swd.Messanger.Model.MessageType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("MessageType");
                });

            modelBuilder.Entity("Swd.Messanger.Model.Message", b =>
                {
                    b.HasOne("Swd.Messanger.Model.MessageState", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Swd.Messanger.Model.MessageType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
