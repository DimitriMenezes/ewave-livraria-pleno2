using Microsoft.EntityFrameworkCore.Migrations;

namespace EwaveLivraria.Domain.Migrations
{
    public partial class AddIsbnBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Isbn",
                table: "Book",
                type: "varchar(13)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Administrator",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Cpf",
                table: "User",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Institution_Cnpj",
                table: "Institution",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_Isbn",
                table: "Book",
                column: "Isbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_Cpf",
                table: "Administrator",
                column: "Cpf",
                unique: true,
                filter: "[Cpf] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Cpf",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Institution_Cnpj",
                table: "Institution");

            migrationBuilder.DropIndex(
                name: "IX_Book_Isbn",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Administrator_Cpf",
                table: "Administrator");

            migrationBuilder.DropColumn(
                name: "Isbn",
                table: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Administrator",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
