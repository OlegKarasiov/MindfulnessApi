using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MindfulnessApi.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Result_Tests_TestId",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Result",
                table: "Result");

            migrationBuilder.RenameTable(
                name: "Result",
                newName: "Results");

            migrationBuilder.RenameColumn(
                name: "Derscription",
                table: "Tests",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Result_TestId",
                table: "Results",
                newName: "IX_Results_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Tests_TestId",
                table: "Results",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Tests_TestId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.RenameTable(
                name: "Results",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tests",
                newName: "Derscription");

            migrationBuilder.RenameIndex(
                name: "IX_Results_TestId",
                table: "Result",
                newName: "IX_Result_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Result",
                table: "Result",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Tests_TestId",
                table: "Result",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id");
        }
    }
}
