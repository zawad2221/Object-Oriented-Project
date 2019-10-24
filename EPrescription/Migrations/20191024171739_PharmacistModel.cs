using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescription.Migrations
{
    public partial class PharmacistModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pharmacists",
                columns: table => new
                {
                    pharmacistId = table.Column<string>(nullable: false),
                    storeName = table.Column<string>(nullable: false),
                    drugeLicence = table.Column<string>(nullable: false),
                    pharmacistPhoneNumber = table.Column<string>(nullable: false),
                    storeAddress = table.Column<string>(nullable: false),
                    pharmacistPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacists", x => x.pharmacistId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pharmacists");
        }
    }
}
