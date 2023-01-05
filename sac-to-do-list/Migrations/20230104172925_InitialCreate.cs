﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sactodolist.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attività",
                columns: table => new
                {
                    AttivitaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fatto = table.Column<bool>(type: "bit", nullable: false),
                    DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Incaricato = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attività", x => x.AttivitaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attività");
        }
    }
}
