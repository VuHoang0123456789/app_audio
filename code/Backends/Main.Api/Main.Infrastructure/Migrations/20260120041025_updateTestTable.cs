using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "main");

            migrationBuilder.RenameTable(
                name: "test_table",
                newName: "test_table",
                newSchema: "main");

            migrationBuilder.AlterColumn<string>(
                name: "nguoi_tao",
                schema: "main",
                table: "test_table",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                comment: "Thông tin tài khoản người tạo bản khi, được ghi nhận khi thêm mới",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nguoi_chinh_sua",
                schema: "main",
                table: "test_table",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                comment: "Thông tin tài khoản người chỉnh sửa bản ghi, được ghi nhận khi thêm mới hoặc mỗi lần cập nhật",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngay_tao",
                schema: "main",
                table: "test_table",
                type: "datetime2",
                nullable: true,
                comment: "Thời gian tạo bản khi, được ghi nhận khi thêm mới",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngay_chinh_sua",
                schema: "main",
                table: "test_table",
                type: "datetime2",
                nullable: true,
                comment: "Thời gian chỉnh sửa bản khi, được ghi nhận khi thêm mới hoặc mỗi lần cập nhật",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                schema: "main",
                table: "test_table",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newid()",
                comment: "Khóa chính của bảng, tự động tạo khi thêm mới",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "test_table",
                schema: "main",
                newName: "test_table");

            migrationBuilder.AlterColumn<string>(
                name: "nguoi_tao",
                table: "test_table",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldComment: "Thông tin tài khoản người tạo bản khi, được ghi nhận khi thêm mới");

            migrationBuilder.AlterColumn<string>(
                name: "nguoi_chinh_sua",
                table: "test_table",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldComment: "Thông tin tài khoản người chỉnh sửa bản ghi, được ghi nhận khi thêm mới hoặc mỗi lần cập nhật");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngay_tao",
                table: "test_table",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Thời gian tạo bản khi, được ghi nhận khi thêm mới");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngay_chinh_sua",
                table: "test_table",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Thời gian chỉnh sửa bản khi, được ghi nhận khi thêm mới hoặc mỗi lần cập nhật");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "test_table",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newid()",
                oldComment: "Khóa chính của bảng, tự động tạo khi thêm mới");
        }
    }
}
