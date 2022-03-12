using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjekat.Migrations
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Putnici_Autobusi_AutobusBusID",
                table: "Putnici");

            migrationBuilder.RenameColumn(
                name: "AutobusBusID",
                table: "Putnici",
                newName: "PutnikAutobusBusID");

            migrationBuilder.RenameIndex(
                name: "IX_Putnici_AutobusBusID",
                table: "Putnici",
                newName: "IX_Putnici_PutnikAutobusBusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Putnici_Autobusi_PutnikAutobusBusID",
                table: "Putnici",
                column: "PutnikAutobusBusID",
                principalTable: "Autobusi",
                principalColumn: "BusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Putnici_Autobusi_PutnikAutobusBusID",
                table: "Putnici");

            migrationBuilder.RenameColumn(
                name: "PutnikAutobusBusID",
                table: "Putnici",
                newName: "AutobusBusID");

            migrationBuilder.RenameIndex(
                name: "IX_Putnici_PutnikAutobusBusID",
                table: "Putnici",
                newName: "IX_Putnici_AutobusBusID");

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
