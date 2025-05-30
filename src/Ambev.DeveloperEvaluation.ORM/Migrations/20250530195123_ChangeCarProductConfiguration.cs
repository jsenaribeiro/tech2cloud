using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCarProductConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Carts_CartId1",
                table: "CartProduct");

            migrationBuilder.DropIndex(
                name: "IX_CartProduct_CartId1",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "CartId1",
                table: "CartProduct");

            migrationBuilder.AlterColumn<string>(
                name: "AddressGeolocationLongitude",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressGeolocationLatitude",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AddressGeolocationLongitude",
                table: "Users",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AddressGeolocationLatitude",
                table: "Users",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId1",
                table: "CartProduct",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartId1",
                table: "CartProduct",
                column: "CartId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Carts_CartId1",
                table: "CartProduct",
                column: "CartId1",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
