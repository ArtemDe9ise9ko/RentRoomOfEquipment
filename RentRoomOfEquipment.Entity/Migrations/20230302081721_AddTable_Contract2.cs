using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentRoomOfEquipment.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddTable_Contract2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Equipments_EquipmentId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Rooms_RoomId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_EquipmentId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_RoomId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Contracts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EquipmentId",
                table: "Contracts",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RoomId",
                table: "Contracts",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Equipments_EquipmentId",
                table: "Contracts",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Rooms_RoomId",
                table: "Contracts",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
