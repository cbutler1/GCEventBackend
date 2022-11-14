using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_ThingToDos_EventId",
                table: "Participations");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Participations",
                newName: "ThingToDoId");

            migrationBuilder.RenameIndex(
                name: "IX_Participations_EventId",
                table: "Participations",
                newName: "IX_Participations_ThingToDoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_ThingToDos_ThingToDoId",
                table: "Participations",
                column: "ThingToDoId",
                principalTable: "ThingToDos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_ThingToDos_ThingToDoId",
                table: "Participations");

            migrationBuilder.RenameColumn(
                name: "ThingToDoId",
                table: "Participations",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Participations_ThingToDoId",
                table: "Participations",
                newName: "IX_Participations_EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_ThingToDos_EventId",
                table: "Participations",
                column: "EventId",
                principalTable: "ThingToDos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
