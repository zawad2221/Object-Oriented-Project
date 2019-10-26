using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescription.Migrations
{
    public partial class MedicineFormModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineForm",
                columns: table => new
                {
                    medicineFormId = table.Column<string>(nullable: false),
                    medicineFormName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineForm", x => x.medicineFormId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineForm");
        }
    }
}
