using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class intial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Record",
                table: "Record");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Record");

            migrationBuilder.AddColumn<string>(
                name: "_id",
                table: "Record",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Record",
                table: "Record",
                column: "_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Record",
                table: "Record");

            migrationBuilder.DropColumn(
                name: "_id",
                table: "Record");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Record",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Record",
                table: "Record",
                column: "Id");
        }
    }
}
