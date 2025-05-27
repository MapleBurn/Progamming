using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkTracer.Migrations
{
    /// <inheritdoc />
    public partial class moneyColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "PlannerEvents",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRepeating",
                table: "PlannerEvents",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "PlannerEvents");

            migrationBuilder.DropColumn(
                name: "IsRepeating",
                table: "PlannerEvents");
        }
    }
}
