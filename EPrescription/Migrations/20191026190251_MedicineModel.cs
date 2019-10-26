using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescription.Migrations
{
    public partial class MedicineModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    medicineId = table.Column<string>(nullable: false),
                    medicineName = table.Column<string>(nullable: false),
                    medicineSingleUniteQuantity = table.Column<string>(nullable: true),
                    medicineFormId = table.Column<string>(nullable: false),
                    medicineTypeId = table.Column<string>(nullable: false),
                    companyId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.medicineId);
                    table.ForeignKey(
                        name: "FK_Medicine_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "companyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicine_MedicineForm_medicineFormId",
                        column: x => x.medicineFormId,
                        principalTable: "MedicineForm",
                        principalColumn: "medicineFormId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicine_MedicineType_medicineTypeId",
                        column: x => x.medicineTypeId,
                        principalTable: "MedicineType",
                        principalColumn: "medicineTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_companyId",
                table: "Medicine",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_medicineFormId",
                table: "Medicine",
                column: "medicineFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_medicineTypeId",
                table: "Medicine",
                column: "medicineTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicine");
        }
    }
}
