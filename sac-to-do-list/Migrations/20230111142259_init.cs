using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sactodolist.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomeUtente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUtente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CognomeUtente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailUtente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Dipendenti",
                columns: table => new
                {
                    DipendenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUtente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CognomeUtente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dipendenti", x => x.DipendenteId);
                });

            migrationBuilder.CreateTable(
                name: "Attività",
                columns: table => new
                {
                    AttivitaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stato = table.Column<bool>(type: "bit", nullable: false),
                    DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attività", x => x.AttivitaId);
                    table.ForeignKey(
                        name: "FK_Attività_Clienti_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clienti",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttivitaDipendente",
                columns: table => new
                {
                    AttivitàAttivitaId = table.Column<int>(type: "int", nullable: false),
                    IncaricatoDipendenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttivitaDipendente", x => new { x.AttivitàAttivitaId, x.IncaricatoDipendenteId });
                    table.ForeignKey(
                        name: "FK_AttivitaDipendente_Attività_AttivitàAttivitaId",
                        column: x => x.AttivitàAttivitaId,
                        principalTable: "Attività",
                        principalColumn: "AttivitaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttivitaDipendente_Dipendenti_IncaricatoDipendenteId",
                        column: x => x.IncaricatoDipendenteId,
                        principalTable: "Dipendenti",
                        principalColumn: "DipendenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attività_ClienteId",
                table: "Attività",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AttivitaDipendente_IncaricatoDipendenteId",
                table: "AttivitaDipendente",
                column: "IncaricatoDipendenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AttivitaDipendente");

            migrationBuilder.DropTable(
                name: "Attività");

            migrationBuilder.DropTable(
                name: "Dipendenti");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
