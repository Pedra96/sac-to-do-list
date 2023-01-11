using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sactodolist.Migrations
{
    /// <inheritdoc />
    public partial class rimossorelazionecliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attività_Clienti_ClienteId",
                table: "Attività");

            migrationBuilder.DropForeignKey(
                name: "FK_AttivitaDipendente_Dipendenti_IncaricatoDipendenteId",
                table: "AttivitaDipendente");

            migrationBuilder.RenameColumn(
                name: "IncaricatoDipendenteId",
                table: "AttivitaDipendente",
                newName: "DipendenteId");

            migrationBuilder.RenameIndex(
                name: "IX_AttivitaDipendente_IncaricatoDipendenteId",
                table: "AttivitaDipendente",
                newName: "IX_AttivitaDipendente_DipendenteId");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Attività",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Attività_Clienti_ClienteId",
                table: "Attività",
                column: "ClienteId",
                principalTable: "Clienti",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttivitaDipendente_Dipendenti_DipendenteId",
                table: "AttivitaDipendente",
                column: "DipendenteId",
                principalTable: "Dipendenti",
                principalColumn: "DipendenteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attività_Clienti_ClienteId",
                table: "Attività");

            migrationBuilder.DropForeignKey(
                name: "FK_AttivitaDipendente_Dipendenti_DipendenteId",
                table: "AttivitaDipendente");

            migrationBuilder.RenameColumn(
                name: "DipendenteId",
                table: "AttivitaDipendente",
                newName: "IncaricatoDipendenteId");

            migrationBuilder.RenameIndex(
                name: "IX_AttivitaDipendente_DipendenteId",
                table: "AttivitaDipendente",
                newName: "IX_AttivitaDipendente_IncaricatoDipendenteId");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Attività",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attività_Clienti_ClienteId",
                table: "Attività",
                column: "ClienteId",
                principalTable: "Clienti",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttivitaDipendente_Dipendenti_IncaricatoDipendenteId",
                table: "AttivitaDipendente",
                column: "IncaricatoDipendenteId",
                principalTable: "Dipendenti",
                principalColumn: "DipendenteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
