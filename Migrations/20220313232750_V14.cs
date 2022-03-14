using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjekat.Migrations
{
    public partial class V14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutobusBusID",
                table: "Putnici",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NazivPrevoznika",
                table: "Autobusi",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Destinacija",
                table: "Autobusi",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateIndex(
                name: "IX_Putnici_AutobusBusID",
                table: "Putnici",
                column: "AutobusBusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Putnici_Autobusi_AutobusBusID",
                table: "Putnici",
                column: "AutobusBusID",
                principalTable: "Autobusi",
                principalColumn: "BusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Putnici_Autobusi_AutobusBusID",
                table: "Putnici");

            migrationBuilder.DropIndex(
                name: "IX_Putnici_AutobusBusID",
                table: "Putnici");

            migrationBuilder.DropColumn(
                name: "AutobusBusID",
                table: "Putnici");

            migrationBuilder.AlterColumn<string>(
                name: "NazivPrevoznika",
                table: "Autobusi",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Destinacija",
                table: "Autobusi",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
