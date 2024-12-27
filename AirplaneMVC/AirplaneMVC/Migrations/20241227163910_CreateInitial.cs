using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirplaneMVC.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airline",
                columns: table => new
                {
                    AirlineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.AirlineID);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    RouteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<float>(type: "real", nullable: true),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.RouteID);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    AircraftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.AircraftID);
                    table.ForeignKey(
                        name: "FK_Aircraft_Airline_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "Airline",
                        principalColumn: "AirlineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airline_PhoneNumbers",
                columns: table => new
                {
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AirlineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline_PhoneNumbers", x => new { x.Phone, x.AirlineID });
                    table.ForeignKey(
                        name: "FK_Airline_PhoneNumbers_Airline_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "Airline",
                        principalColumn: "AirlineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_Airline_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "Airline",
                        principalColumn: "AirlineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AirlineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Airline_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "Airline",
                        principalColumn: "AirlineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AircraftID = table.Column<int>(type: "int", nullable: false),
                    RouteID = table.Column<int>(type: "int", nullable: false),
                    Passengers = table.Column<int>(type: "int", nullable: true),
                    PricePerPassenger = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepartureDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArrivalDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TravelTime = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => new { x.AircraftID, x.RouteID });
                    table.ForeignKey(
                        name: "FK_Assignment_Aircraft_AircraftID",
                        column: x => x.AircraftID,
                        principalTable: "Aircraft",
                        principalColumn: "AircraftID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_Route_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Route",
                        principalColumn: "RouteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    CrewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajorPilot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssistantPilot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hostess1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hostess2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AircraftID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.CrewID);
                    table.ForeignKey(
                        name: "FK_Crew_Aircraft_AircraftID",
                        column: x => x.AircraftID,
                        principalTable: "Aircraft",
                        principalColumn: "AircraftID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Qualifications",
                columns: table => new
                {
                    Skill = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Qualifications", x => new { x.Skill, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_Employee_Qualifications_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_AirlineID",
                table: "Aircraft",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_Airline_PhoneNumbers_AirlineID",
                table: "Airline_PhoneNumbers",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_RouteID",
                table: "Assignment",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_AircraftID",
                table: "Crew",
                column: "AircraftID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AirlineID",
                table: "Employee",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Qualifications_EmployeeID",
                table: "Employee_Qualifications",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AirlineID",
                table: "Transactions",
                column: "AirlineID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airline_PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "Employee_Qualifications");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Airline");
        }
    }
}
