using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class changelastlogindate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdatedDate",
                table: "Users",
                newName: "LastLoginDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastLoginDate",
                table: "Users",
                newName: "LastUpdatedDate");
        }
    }
}
