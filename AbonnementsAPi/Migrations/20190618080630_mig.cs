﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbonnementsAPi.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abonnements",
                columns: table => new
                {
                    aboId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    aboFKCli = table.Column<int>(nullable: false),
                    aboFKMag = table.Column<int>(nullable: false),
                    aboDateDebut = table.Column<DateTime>(nullable: false),
                    aboDateFin = table.Column<DateTime>(nullable: false),
                    aboStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnements", x => x.aboId);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    cliId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cliNom = table.Column<string>(nullable: false),
                    cliPrenom = table.Column<string>(nullable: false),
                    cliPassword = table.Column<string>(nullable: false),
                    cliMail = table.Column<string>(nullable: false),
                    cliPhone = table.Column<string>(nullable: false),
                    cliDateNaissance = table.Column<DateTime>(nullable: true),
                    cliLieuNaissance = table.Column<string>(nullable: true),
                    cliNumCart = table.Column<string>(nullable: true),
                    cliExpiCarte = table.Column<string>(nullable: true),
                    cliCCV = table.Column<string>(nullable: true),
                    cliAuthKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.cliId);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    empId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    empLogin = table.Column<string>(nullable: false),
                    empPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.empId);
                });

            migrationBuilder.CreateTable(
                name: "Historique",
                columns: table => new
                {
                    hisId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    hisFKCli = table.Column<int>(nullable: false),
                    hisFKEmp = table.Column<int>(nullable: false),
                    hisDate = table.Column<DateTime>(nullable: false),
                    hisMoyen = table.Column<string>(nullable: false),
                    hisMotif = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historique", x => x.hisId);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    logId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    logDescription = table.Column<string>(nullable: false),
                    logDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.logId);
                });

            migrationBuilder.CreateTable(
                name: "Magazines",
                columns: table => new
                {
                    magId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    magTitre = table.Column<string>(nullable: false),
                    magNbVolumeAnnee = table.Column<int>(nullable: false),
                    magPhotoCouverture = table.Column<string>(nullable: true),
                    magDescription = table.Column<string>(nullable: false),
                    magPrixAnnuel = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazines", x => x.magId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonnements");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "Employer");

            migrationBuilder.DropTable(
                name: "Historique");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Magazines");
        }
    }
}