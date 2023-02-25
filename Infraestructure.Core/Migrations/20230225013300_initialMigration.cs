using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Core.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoresEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    LastName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EditorialEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    Sede = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorialEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEditorial = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Sinopsis = table.Column<string>(maxLength: 500, nullable: true),
                    N_Pages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookEntity_EditorialEntity_IdEditorial",
                        column: x => x.IdEditorial,
                        principalTable: "EditorialEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutorBookEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAutor = table.Column<int>(nullable: false),
                    IdBook = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorBookEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutorBookEntity_AutoresEntity_IdAutor",
                        column: x => x.IdAutor,
                        principalTable: "AutoresEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorBookEntity_BookEntity_IdBook",
                        column: x => x.IdBook,
                        principalTable: "BookEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorBookEntity_IdAutor",
                table: "AutorBookEntity",
                column: "IdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_AutorBookEntity_IdBook",
                table: "AutorBookEntity",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_BookEntity_IdEditorial",
                table: "BookEntity",
                column: "IdEditorial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorBookEntity");

            migrationBuilder.DropTable(
                name: "AutoresEntity");

            migrationBuilder.DropTable(
                name: "BookEntity");

            migrationBuilder.DropTable(
                name: "EditorialEntity");
        }
    }
}
