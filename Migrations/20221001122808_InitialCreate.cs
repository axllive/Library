using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    UsrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aluno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.UsrID);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    LivroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBorrowed = table.Column<bool>(type: "bit", nullable: false),
                    InicioEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FimEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsrID = table.Column<int>(type: "int", nullable: false),
                    AutorID = table.Column<int>(type: "int", nullable: false),
                    AlunoUsrID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.LivroID);
                    table.ForeignKey(
                        name: "FK_Livros_Alunos_AlunoUsrID",
                        column: x => x.AlunoUsrID,
                        principalTable: "Alunos",
                        principalColumn: "UsrID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Livros_Autores_AutorID",
                        column: x => x.AutorID,
                        principalTable: "Autores",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AlunoUsrID",
                table: "Livros",
                column: "AlunoUsrID");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AutorID",
                table: "Livros",
                column: "AutorID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
