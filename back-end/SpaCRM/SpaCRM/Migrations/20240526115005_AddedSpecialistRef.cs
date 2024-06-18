using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddedSpecialistRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SpecialistId",
                table: "Bookings",
                column: "SpecialistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Specialists_SpecialistId",
                table: "Bookings",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Specialists_SpecialistId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_SpecialistId",
                table: "Bookings");
        }
    }
}
