using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirplaneMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNumberIDToAirline_PhoneNumbers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_Qualifications",
                table: "Employee_Qualifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airline_PhoneNumbers",
                table: "Airline_PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "Qualifications",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Employee_Qualifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "Skill",
                table: "Employee_Qualifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "QualificationID",
                table: "Employee_Qualifications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "RouteID",
                table: "Assignment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "AircraftID",
                table: "Assignment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentID",
                table: "Assignment",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "AirlineID",
                table: "Airline_PhoneNumbers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Airline_PhoneNumbers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumberID",
                table: "Airline_PhoneNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_Qualifications",
                table: "Employee_Qualifications",
                column: "QualificationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment",
                column: "AssignmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airline_PhoneNumbers",
                table: "Airline_PhoneNumbers",
                column: "PhoneNumberID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AircraftID",
                table: "Assignment",
                column: "AircraftID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_Qualifications",
                table: "Employee_Qualifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_AircraftID",
                table: "Assignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airline_PhoneNumbers",
                table: "Airline_PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "QualificationID",
                table: "Employee_Qualifications");

            migrationBuilder.DropColumn(
                name: "AssignmentID",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "PhoneNumberID",
                table: "Airline_PhoneNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "Skill",
                table: "Employee_Qualifications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Employee_Qualifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<string>(
                name: "Qualifications",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "RouteID",
                table: "Assignment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "AircraftID",
                table: "Assignment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Airline_PhoneNumbers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "AirlineID",
                table: "Airline_PhoneNumbers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_Qualifications",
                table: "Employee_Qualifications",
                columns: new[] { "Skill", "EmployeeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment",
                columns: new[] { "AircraftID", "RouteID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airline_PhoneNumbers",
                table: "Airline_PhoneNumbers",
                columns: new[] { "Phone", "AirlineID" });
        }
    }
}
