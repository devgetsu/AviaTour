using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AviaTour.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TEST1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AboutUs_AboutUsModelId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AboutUs_AboutUsModelId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_AboutUs_AboutUsModelId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_AboutUsModelId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AboutUsModelId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Address_AboutUsModelId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "AboutUsModelId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "AboutUsModelId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AboutUsModelId",
                table: "Address");

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 8, 28, 0, 15, 25, 612, DateTimeKind.Unspecified).AddTicks(812), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 8, 28, 0, 15, 25, 612, DateTimeKind.Unspecified).AddTicks(822), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AboutUsModelId",
                table: "Emails",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AboutUsModelId",
                table: "Contacts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AboutUsModelId",
                table: "Address",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 8, 26, 16, 51, 4, 189, DateTimeKind.Unspecified).AddTicks(8659), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 8, 26, 16, 51, 4, 189, DateTimeKind.Unspecified).AddTicks(8672), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Emails_AboutUsModelId",
                table: "Emails",
                column: "AboutUsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AboutUsModelId",
                table: "Contacts",
                column: "AboutUsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AboutUsModelId",
                table: "Address",
                column: "AboutUsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AboutUs_AboutUsModelId",
                table: "Address",
                column: "AboutUsModelId",
                principalTable: "AboutUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AboutUs_AboutUsModelId",
                table: "Contacts",
                column: "AboutUsModelId",
                principalTable: "AboutUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_AboutUs_AboutUsModelId",
                table: "Emails",
                column: "AboutUsModelId",
                principalTable: "AboutUs",
                principalColumn: "Id");
        }
    }
}
