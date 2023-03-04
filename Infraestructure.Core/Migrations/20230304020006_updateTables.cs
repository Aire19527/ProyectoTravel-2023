using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Core.Migrations
{
    public partial class updateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookEntity_EditorialEntity_IdEditorial",
                table: "BookEntity");

            migrationBuilder.DropTable(
                name: "AutorBookEntity");

            migrationBuilder.DropTable(
                name: "AutoresEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EditorialEntity",
                table: "EditorialEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookEntity",
                table: "BookEntity");

            migrationBuilder.EnsureSchema(
                name: "Library");

            migrationBuilder.RenameTable(
                name: "EditorialEntity",
                newName: "Editorial",
                newSchema: "Library");

            migrationBuilder.RenameTable(
                name: "BookEntity",
                newName: "Book",
                newSchema: "Library");

            migrationBuilder.RenameIndex(
                name: "IX_BookEntity_IdEditorial",
                schema: "Library",
                table: "Book",
                newName: "IX_Book_IdEditorial");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Library",
                table: "Editorial",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAutor",
                schema: "Library",
                table: "Book",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Editorial",
                schema: "Library",
                table: "Editorial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                schema: "Library",
                table: "Book",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Autor",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    LastName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_IdAutor",
                schema: "Library",
                table: "Book",
                column: "IdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Autor_IdAutor",
                schema: "Library",
                table: "Book",
                column: "IdAutor",
                principalSchema: "Library",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Editorial_IdEditorial",
                schema: "Library",
                table: "Book",
                column: "IdEditorial",
                principalSchema: "Library",
                principalTable: "Editorial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Autor_IdAutor",
                schema: "Library",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Editorial_IdEditorial",
                schema: "Library",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Autor",
                schema: "Library");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Editorial",
                schema: "Library",
                table: "Editorial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                schema: "Library",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_IdAutor",
                schema: "Library",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "IdAutor",
                schema: "Library",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Editorial",
                schema: "Library",
                newName: "EditorialEntity");

            migrationBuilder.RenameTable(
                name: "Book",
                schema: "Library",
                newName: "BookEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Book_IdEditorial",
                table: "BookEntity",
                newName: "IX_BookEntity_IdEditorial");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EditorialEntity",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EditorialEntity",
                table: "EditorialEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookEntity",
                table: "BookEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AutoresEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutorBookEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAutor = table.Column<int>(type: "int", nullable: false),
                    IdBook = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_BookEntity_EditorialEntity_IdEditorial",
                table: "BookEntity",
                column: "IdEditorial",
                principalTable: "EditorialEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
