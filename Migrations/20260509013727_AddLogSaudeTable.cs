using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClyvoCare.API.Migrations
{
    /// <inheritdoc />
    public partial class AddLogSaudeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CC_LOG_SAUDE",
                columns: table => new
                {
                    ID_LOG = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PESO = table.Column<decimal>(type: "NUMBER(10,2)", nullable: false),
                    TEMPERATURA = table.Column<decimal>(type: "NUMBER(10,2)", nullable: false),
                    BATIMENTOS_CARDIACOS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATA_HORA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    OBSERVACOES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    ID_PET = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CC_LOG_SAUDE", x => x.ID_LOG);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CC_LOG_SAUDE");
        }
    }
}
