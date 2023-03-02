using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentRoomOfEquipment.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddTable_Contract1 : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Contracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "Contracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Equipments_EquipmentId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Rooms_RoomId",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Equipments_EquipmentId",
                table: "Contracts",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Rooms_RoomId",
                table: "Contracts",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
