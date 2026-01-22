using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace File.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_test_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "file");

            migrationBuilder.CreateTable(
                name: "test_table",
                schema: "file",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ma = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nguoi_tao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngay_chinh_sua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nguoi_chinh_sua = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_table", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "test_table",
                schema: "file");
        }
    }
}
