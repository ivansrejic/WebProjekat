using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjekat.Migrations
{
    public partial class VM1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autobusi",
                columns: table => new
                {
                    BusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registracija = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NazivPrevoznika = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    datumm = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Destinacija = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autobusi", x => x.BusID);
                });

            migrationBuilder.CreateTable(
                name: "Putnici",
                columns: table => new
                {
                    putnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Putnici", x => x.putnikID);
                });

            migrationBuilder.CreateTable(
                name: "Karte",
                columns: table => new
                {
                    KartaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSedista = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    AutobusFKBusID = table.Column<int>(type: "int", nullable: true),
                    PutnikFKputnikID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karte", x => x.KartaID);
                    table.ForeignKey(
                        name: "FK_Karte_Autobusi_AutobusFKBusID",
                        column: x => x.AutobusFKBusID,
                        principalTable: "Autobusi",
                        principalColumn: "BusID");
                    table.ForeignKey(
                        name: "FK_Karte_Putnici_PutnikFKputnikID",
                        column: x => x.PutnikFKputnikID,
                        principalTable: "Putnici",
                        principalColumn: "putnikID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Karte_AutobusFKBusID",
                table: "Karte",
                column: "AutobusFKBusID");

            migrationBuilder.CreateIndex(
                name: "IX_Karte_PutnikFKputnikID",
                table: "Karte",
                column: "PutnikFKputnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Karte");

            migrationBuilder.DropTable(
                name: "Autobusi");

            migrationBuilder.DropTable(
                name: "Putnici");
        }
    }
}
