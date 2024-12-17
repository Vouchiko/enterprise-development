﻿// <auto-generated />
using System;
using DispatcherService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DispatcherService.Domain.Migrations
{
    [DbContext(typeof(DispatcherServiceContext))]
    partial class DispatcherServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DispatcherService.Domain.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("DriverLicense")
                        .HasColumnType("text")
                        .HasColumnName("driver_license");

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("Passport")
                        .HasColumnType("text")
                        .HasColumnName("passport");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.HasKey("Id");

                    b.ToTable("drivers");
                });

            modelBuilder.Entity("DispatcherService.Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DriverId")
                        .HasColumnType("integer")
                        .HasColumnName("driver_id");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_time");

                    b.Property<string>("RouteNumber")
                        .HasColumnType("text")
                        .HasColumnName("route_number");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_time");

                    b.Property<int?>("TransportId")
                        .HasColumnType("integer")
                        .HasColumnName("transport_id");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("TransportId");

                    b.ToTable("schedules");
                });

            modelBuilder.Entity("DispatcherService.Domain.Entities.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsLowFloor")
                        .HasColumnType("boolean")
                        .HasColumnName("is_low_floor");

                    b.Property<int?>("MaxCapacity")
                        .HasColumnType("integer")
                        .HasColumnName("max_capacity");

                    b.Property<string>("Model")
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("text")
                        .HasColumnName("registration_number");

                    b.Property<string>("Type")
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<int?>("YearOfManufacture")
                        .HasColumnType("integer")
                        .HasColumnName("year_of_manufacture");

                    b.HasKey("Id");

                    b.ToTable("transports");
                });

            modelBuilder.Entity("DispatcherService.Domain.Entities.Schedule", b =>
                {
                    b.HasOne("DispatcherService.Domain.Entities.Driver", "Driver")
                        .WithMany("Schedules")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DispatcherService.Domain.Entities.Transport", "Transport")
                        .WithMany("Schedules")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Driver");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("DispatcherService.Domain.Entities.Driver", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("DispatcherService.Domain.Entities.Transport", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
