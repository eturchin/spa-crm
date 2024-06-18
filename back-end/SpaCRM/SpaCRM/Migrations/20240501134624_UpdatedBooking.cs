using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaCRM.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SerivceId",
                table: "Bookings",
                newName: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Bookings",
                newName: "SerivceId");
        }
    }
}
