using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medics.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Doctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorDetails_Chats_ChatId",
                table: "DoctorDetails");

            migrationBuilder.DropIndex(
                name: "IX_DoctorDetails_ChatId",
                table: "DoctorDetails");

            migrationBuilder.DropColumn(
                name: "AvarageStars",
                table: "DoctorDetails");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "DoctorDetails",
                newName: "DoctorId");

            migrationBuilder.AddColumn<double>(
                name: "AverageStars",
                table: "DoctorDetails",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDetails_DoctorId",
                table: "DoctorDetails",
                column: "DoctorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorDetails_Doctors_DoctorId",
                table: "DoctorDetails",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorDetails_Doctors_DoctorId",
                table: "DoctorDetails");

            migrationBuilder.DropIndex(
                name: "IX_DoctorDetails_DoctorId",
                table: "DoctorDetails");

            migrationBuilder.DropColumn(
                name: "AverageStars",
                table: "DoctorDetails");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "DoctorDetails",
                newName: "ChatId");

            migrationBuilder.AddColumn<string>(
                name: "AvarageStars",
                table: "DoctorDetails",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDetails_ChatId",
                table: "DoctorDetails",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorDetails_Chats_ChatId",
                table: "DoctorDetails",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
