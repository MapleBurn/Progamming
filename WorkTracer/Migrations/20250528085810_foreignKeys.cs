using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkTracer.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventWeeks_Users_UserRecordId",
                table: "EventWeeks");

            migrationBuilder.DropIndex(
                name: "IX_EventWeeks_UserRecordId",
                table: "EventWeeks");

            migrationBuilder.DropColumn(
                name: "UserRecordId",
                table: "EventWeeks");

            migrationBuilder.CreateIndex(
                name: "IX_EventWeeks_UserId",
                table: "EventWeeks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventWeeks_Users_UserId",
                table: "EventWeeks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventWeeks_Users_UserId",
                table: "EventWeeks");

            migrationBuilder.DropIndex(
                name: "IX_EventWeeks_UserId",
                table: "EventWeeks");

            migrationBuilder.AddColumn<int>(
                name: "UserRecordId",
                table: "EventWeeks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventWeeks_UserRecordId",
                table: "EventWeeks",
                column: "UserRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventWeeks_Users_UserRecordId",
                table: "EventWeeks",
                column: "UserRecordId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
