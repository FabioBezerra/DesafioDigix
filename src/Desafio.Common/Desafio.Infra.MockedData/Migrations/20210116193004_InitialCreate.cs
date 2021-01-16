using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Infra.MockedData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Familia",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(900)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(900)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    FamiliaId = table.Column<string>(type: "nvarchar(900)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Familia_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Renda",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(900)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    PessoaId = table.Column<string>(type: "nvarchar(900)", nullable: true),
                    FamiliaId = table.Column<string>(type: "nvarchar(900)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Renda_Familia_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Renda_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_FamiliaId",
                table: "Pessoa",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Renda_FamiliaId",
                table: "Renda",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Renda_PessoaId",
                table: "Renda",
                column: "PessoaId",
                unique: true,
                filter: "[PessoaId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Renda");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Familia");
        }
    }
}
