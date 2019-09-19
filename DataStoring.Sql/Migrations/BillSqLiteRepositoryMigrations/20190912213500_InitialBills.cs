using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.SqLite.Migrations.BillSqLiteRepositoryMigrations
{
    public partial class InitialBills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SumPaid = table.Column<decimal>(nullable: false),
                    BuyDate = table.Column<DateTime>(nullable: false),
                    BoughtAtSourceId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");
        }
    }
}
