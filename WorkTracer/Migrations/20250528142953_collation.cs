using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkTracer.Migrations
{
    /// <inheritdoc />
    public partial class collation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventWeekId",
                table: "PlannerEvents");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "TEXT",
                nullable: false,
                collation: "NOCASE",
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldCollation: "NOCASE");

            migrationBuilder.AddColumn<int>(
                name: "EventWeekId",
                table: "PlannerEvents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
