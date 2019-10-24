using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescription.Migrations
{
    public partial class DoctorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    doctorId = table.Column<string>(nullable: false),
                    doctorName = table.Column<string>(nullable: false),
                    doctorPhoneNumber = table.Column<string>(nullable: false),
                    doctorDesignation = table.Column<string>(nullable: false),
                    doctorSpecializedArea = table.Column<string>(nullable: false),
                    doctorPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.doctorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
