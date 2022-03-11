using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjekat.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Putnici_Karte_KartaFKKartaID",
                table: "Putnici");

            migrationBuilder.DropIndex(
                name: "IX_Putnici_KartaFKKartaID",
                table: "Putnici");

            migrationBuilder.DropColumn(
                name: "KartaFKKartaID",
                table: "Putnici");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KartaFKKartaID",
                table: "Putnici",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Putnici_KartaFKKartaID",
                table: "Putnici",
                column: "KartaFKKartaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Putnici_Karte_KartaFKKartaID",
                table: "Putnici",
                column: "KartaFKKartaID",
                principalTable: "Karte",
                principalColumn: "KartaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
