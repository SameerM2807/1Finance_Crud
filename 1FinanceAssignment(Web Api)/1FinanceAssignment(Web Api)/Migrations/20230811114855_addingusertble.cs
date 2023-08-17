using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1FinanceAssignment_Web_Api_.Migrations
{
    public partial class addingusertble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "0sameermansuri0@gmail.com", "Sameer", "Mansuri@00" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
