using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescription.Migrations
{
    public partial class MedicineTypeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineType",
                columns: table => new
                {
                    medicineTypeId = table.Column<string>(nullable: false),
                    medicineTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineType", x => x.medicineTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineType");
        }
    }
}
