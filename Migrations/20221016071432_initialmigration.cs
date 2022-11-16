using Microsoft.EntityFrameworkCore.Migrations;

namespace template.dal.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    departmentcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    departmentsize = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
