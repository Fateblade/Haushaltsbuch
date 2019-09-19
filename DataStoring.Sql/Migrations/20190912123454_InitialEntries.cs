using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.SqLite.Migrations
{
    public partial class InitialEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    SourceID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrys", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrys");
        }
    }
}
