using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transportathon_Project_EnesCakir.Migrations
{
    /// <inheritdoc />
    public partial class usercompanyNameremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RejectedRequest");
        }
    }
}
