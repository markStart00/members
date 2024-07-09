using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace members.Database.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFiledsToMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Members",
                newName: "NameFullTitle");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseOfLordsId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberFrom",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MembershipEndDate",
                table: "Members",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MembershipEndReason",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MembershipStartDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "MembershipStatusIsActive",
                table: "Members",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Members_HouseOfLordsId",
                table: "Members",
                column: "HouseOfLordsId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_HouseOfLordsId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HouseOfLordsId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MemberFrom",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MembershipEndDate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MembershipEndReason",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MembershipStartDate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MembershipStatusIsActive",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "NameFullTitle",
                table: "Members",
                newName: "LastName");
        }
    }
}
