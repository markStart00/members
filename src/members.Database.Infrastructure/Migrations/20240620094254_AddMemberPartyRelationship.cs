using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace members.Database.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMemberPartyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PartyId",
                table: "Members",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PartyId",
                table: "Members",
                column: "PartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Parties_PartyId",
                table: "Members",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "PartyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Parties_PartyId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_PartyId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "PartyId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
