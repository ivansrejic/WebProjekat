using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjekat.Migrations
{
    public partial class V223 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutobusBusID",
                table: "Putnici",
                type: "int",
                nullable: true);

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
    }
}
