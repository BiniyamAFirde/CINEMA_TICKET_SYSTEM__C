using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureSeatRowVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f1421c5e-0e4c-406f-b686-74a6b54e8d98", "AQAAAAIAAYagAAAAEPIV7gElQzn65FCb8ZS83Evs6ZzpNBh0H/rXHFVcCza5zL14RhLdcEl5OoI/O0H1gA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "01771988-62ac-4fb1-b499-2cabb3794826", "AQAAAAIAAYagAAAAEJEsiO7LdwXIaDo/nAUfY1DmjBspaau+Us3IY98ieJ9gY+4IZwlcb3juv25EXnHlvg==" });
        }
    }
}
