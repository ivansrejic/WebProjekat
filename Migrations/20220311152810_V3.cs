using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjekat.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PutnikFKputnikID",
                table: "Karte",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Karte_PutnikFKputnikID",
                table: "Karte",
                column: "PutnikFKputnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Karte_Putnici_PutnikFKputnikID",
                table: "Karte",
                column: "PutnikFKputnikID",
                principalTable: "Putnici",
                principalColumn: "putnikID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karte_Putnici_PutnikFKputnikID",
                table: "Karte");

            migrationBuilder.DropIndex(
                name: "IX_Karte_PutnikFKputnikID",
                table: "Karte");

            migrationBuilder.DropColumn(
                name: "PutnikFKputnikID",
                table: "Karte");
        }
    }
}
