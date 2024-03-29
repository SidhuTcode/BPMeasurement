﻿// <auto-generated />
using System;
using BPMeasurement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BPMeasurement.Migrations
{
    [DbContext(typeof(BPContext))]
    partial class BPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BPMeasurement.Models.BloodMeasurement", b =>
                {
                    b.Property<int>("BPId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BPId"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Diastolic")
                        .HasColumnType("int");

                    b.Property<string>("PositionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Systolic")
                        .HasColumnType("int");

                    b.HasKey("BPId");

                    b.HasIndex("PositionId");

                    b.ToTable("BPMeasurements");

                    b.HasData(
                        new
                        {
                            BPId = 1,
                            Date = new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Diastolic = 80,
                            PositionId = "A",
                            Systolic = 120
                        },
                        new
                        {
                            BPId = 2,
                            Date = new DateTime(2023, 10, 7, 18, 16, 57, 646, DateTimeKind.Local).AddTicks(890),
                            Diastolic = 121,
                            PositionId = "L",
                            Systolic = 181
                        },
                        new
                        {
                            BPId = 3,
                            Date = new DateTime(2023, 10, 7, 18, 16, 57, 646, DateTimeKind.Local).AddTicks(945),
                            Diastolic = 90,
                            PositionId = "T",
                            Systolic = 150
                        });
                });

            modelBuilder.Entity("BPMeasurement.Models.Position", b =>
                {
                    b.Property<string>("PositionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            PositionId = "A",
                            Name = "Standing"
                        },
                        new
                        {
                            PositionId = "T",
                            Name = "Sitting"
                        },
                        new
                        {
                            PositionId = "L",
                            Name = "Lying Down"
                        });
                });

            modelBuilder.Entity("BPMeasurement.Models.BloodMeasurement", b =>
                {
                    b.HasOne("BPMeasurement.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}
