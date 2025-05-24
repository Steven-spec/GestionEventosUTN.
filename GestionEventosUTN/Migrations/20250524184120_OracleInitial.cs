using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionEventosUTN_.Migrations
{
    /// <inheritdoc />
    public partial class OracleInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventoPonentes_Eventos_EventoId",
                table: "EventoPonentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Eventos_EventoId",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Sesiones_Eventos_EventoId",
                table: "Sesiones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos");

            migrationBuilder.RenameTable(
                name: "Eventos",
                newName: "EVENTOS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EVENTOS",
                table: "EVENTOS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventoPonentes_EVENTOS_EventoId",
                table: "EventoPonentes",
                column: "EventoId",
                principalTable: "EVENTOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_EVENTOS_EventoId",
                table: "Inscripciones",
                column: "EventoId",
                principalTable: "EVENTOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sesiones_EVENTOS_EventoId",
                table: "Sesiones",
                column: "EventoId",
                principalTable: "EVENTOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventoPonentes_EVENTOS_EventoId",
                table: "EventoPonentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_EVENTOS_EventoId",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Sesiones_EVENTOS_EventoId",
                table: "Sesiones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EVENTOS",
                table: "EVENTOS");

            migrationBuilder.RenameTable(
                name: "EVENTOS",
                newName: "Eventos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventoPonentes_Eventos_EventoId",
                table: "EventoPonentes",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Eventos_EventoId",
                table: "Inscripciones",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sesiones_Eventos_EventoId",
                table: "Sesiones",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
