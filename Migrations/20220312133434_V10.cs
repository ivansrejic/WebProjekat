using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjekat.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Putnici_Autobusi_PutnikAutobusBusID",
                table: "Putnici");

            migrationBuilder.DropIndex(
                name: "IX_Putnici_PutnikAutobusBusID",
                table: "Putnici");

            migrationBuilder.DropColumn(
                name: "PutnikAutobusBusID",
                table: "Putnici");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PutnikAutobusBusID",
                table: "Putnici",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Putnici_PutnikAutobusBusID",
                table: "Putnici",
                column: "PutnikAutobusBusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Putnici_Autobusi_PutnikAutobusBusID",
                table: "Putnici",
                column: "PutnikAutobusBusID",
                principalTable: "Autobusi",
                principalColumn: "BusID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
