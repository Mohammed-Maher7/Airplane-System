﻿// <auto-generated />
using System;
using AirplaneMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirplaneMVC.Migrations
{
    [DbContext(typeof(AirplaneContext))]
    [Migration("20241227180958_AddPhoneNumberIDToAirline_PhoneNumbers")]
    partial class AddPhoneNumberIDToAirline_PhoneNumbers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirplaneMVC.Models.Aircraft", b =>
                {
                    b.Property<int>("AircraftID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AircraftID"));

                    b.Property<int>("AirlineID")
                        .HasColumnType("int");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AircraftID");

                    b.HasIndex("AirlineID");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Airline", b =>
                {
                    b.Property<int>("AirlineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AirlineID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AirlineID");

                    b.ToTable("Airline");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Airline_PhoneNumbers", b =>
                {
                    b.Property<int>("PhoneNumberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneNumberID"));

                    b.Property<int>("AirlineID")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneNumberID");

                    b.HasIndex("AirlineID");

                    b.ToTable("Airline_PhoneNumbers");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentID"));

                    b.Property<int>("AircraftID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ArrivalDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DepartureDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Passengers")
                        .HasColumnType("int");

                    b.Property<decimal?>("PricePerPassenger")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RouteID")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("TravelTime")
                        .HasColumnType("time");

                    b.HasKey("AssignmentID");

                    b.HasIndex("AircraftID");

                    b.HasIndex("RouteID");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Crew", b =>
                {
                    b.Property<int>("CrewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrewID"));

                    b.Property<int>("AircraftID")
                        .HasColumnType("int");

                    b.Property<string>("AssistantPilot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hostess1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hostess2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MajorPilot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CrewID");

                    b.HasIndex("AircraftID");

                    b.ToTable("Crew");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AirlineID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("AirlineID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Employee_Qualifications", b =>
                {
                    b.Property<int>("QualificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QualificationID"));

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Skill")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QualificationID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Employee_Qualifications");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Route", b =>
                {
                    b.Property<int>("RouteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteID"));

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Distance")
                        .HasColumnType("real");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RouteID");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Transactions", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"));

                    b.Property<int>("AirlineID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TransactionID");

                    b.HasIndex("AirlineID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Aircraft", b =>
                {
                    b.HasOne("AirplaneMVC.Models.Airline", "Airline")
                        .WithMany("Aircrafts")
                        .HasForeignKey("AirlineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airline");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Airline_PhoneNumbers", b =>
                {
                    b.HasOne("AirplaneMVC.Models.Airline", "Airline")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("AirlineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airline");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Assignment", b =>
                {
                    b.HasOne("AirplaneMVC.Models.Aircraft", "Aircraft")
                        .WithMany("Assignments")
                        .HasForeignKey("AircraftID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirplaneMVC.Models.Route", "Route")
                        .WithMany("Assignments")
                        .HasForeignKey("RouteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Crew", b =>
                {
                    b.HasOne("AirplaneMVC.Models.Aircraft", "Aircraft")
                        .WithMany("Crews")
                        .HasForeignKey("AircraftID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Employee", b =>
                {
                    b.HasOne("AirplaneMVC.Models.Airline", "Airline")
                        .WithMany("Employees")
                        .HasForeignKey("AirlineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airline");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Employee_Qualifications", b =>
                {
                    b.HasOne("AirplaneMVC.Models.Employee", "Employee")
                        .WithMany("EmployeeQualifications")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Transactions", b =>
                {
                    b.HasOne("AirplaneMVC.Models.Airline", "Airline")
                        .WithMany("Transactions")
                        .HasForeignKey("AirlineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airline");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Aircraft", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Crews");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Airline", b =>
                {
                    b.Navigation("Aircrafts");

                    b.Navigation("Employees");

                    b.Navigation("PhoneNumbers");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Employee", b =>
                {
                    b.Navigation("EmployeeQualifications");
                });

            modelBuilder.Entity("AirplaneMVC.Models.Route", b =>
                {
                    b.Navigation("Assignments");
                });
#pragma warning restore 612, 618
        }
    }
}
