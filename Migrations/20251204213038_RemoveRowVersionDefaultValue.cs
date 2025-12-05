using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRowVersionDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11609ba6-0424-45b9-aae4-d1ea25ff4888", "AQAAAAIAAYagAAAAEFepM7D2sL41DDRRlmD7WhvG1ZTcJ6Xr4fiKxDgm+v2Vx6gm5HW3RHAuWtHEH8FWig==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "feb3123d-20e2-4c58-a153-6615b7586aa1", "AQAAAAIAAYagAAAAEBZa17qBapArdpr+z9nO3J7abZHqSg+1CQBTXRCU8y3lD8cLoB6HHoPPBnio1F2arw==" });
        }
    }
}
