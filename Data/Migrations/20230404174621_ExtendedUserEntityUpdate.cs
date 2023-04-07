using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RemoteHybrid",
                table: "Jobs",
                newName: "RemoteHybridOnsite");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RemoteHybridOnsite",
                table: "Jobs",
                newName: "RemoteHybrid");
        }
    }
}
