using System;
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
                    cliNom = table.Column<string>(nullable: true),
                    cliPrenom = table.Column<string>(nullable: true),
                    cliPassword = table.Column<string>(nullable: true),
                    cliMail = table.Column<string>(nullable: true),
                    cliPhone = table.Column<string>(nullable: true),
                    cliDateNaissance = table.Column<DateTime>(nullable: true),
                    cliLieuNaissance = table.Column<string>(nullable: true),
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
                    empLogin = table.Column<string>(nullable: true),
                    empPassword = table.Column<string>(nullable: true),
                    empAuthKey = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Paiement",
                columns: table => new
                {
                    uuid = table.Column<string>(nullable: true),
                    cid = table.Column<string>(nullable: false),
                    cardNumber = table.Column<string>(nullable: true),
                    cardMonth = table.Column<string>(nullable: true),
                    cardYear = table.Column<string>(nullable: true),
                    amount = table.Column<decimal>(nullable: false),
                    transaction = table.Column<string>(nullable: true),
                    paiFKAbo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiement", x => x.cid);
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

            migrationBuilder.DropTable(
                name: "Paiement");
        }
    }
}
