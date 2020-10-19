using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EwaveLivraria.Domain.Migrations
{
    public partial class AddColumnReturnedDateBookLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnedDate",
                table: "BookLoan",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnedDate",
                table: "BookLoan");
        }
    }
}
