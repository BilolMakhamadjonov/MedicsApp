using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medics.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initia2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentPayments_Appointments_AppointmentId",
                table: "AppointmentPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalCabinets_Appointments_AppointmentId",
                table: "PersonalCabinets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentPayments",
                table: "AppointmentPayments");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

            migrationBuilder.RenameTable(
                name: "AppointmentPayments",
                newName: "AppointmentPayment");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserId",
                table: "Appointment",
                newName: "IX_Appointment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointment",
                newName: "IX_Appointment_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentPayments_AppointmentId",
                table: "AppointmentPayment",
                newName: "IX_AppointmentPayment_AppointmentId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "AppointmentPayment",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppointmentPayment",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentPayment",
                table: "AppointmentPayment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentPayment_DoctorId",
                table: "AppointmentPayment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentPayment_UserId",
                table: "AppointmentPayment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctors_DoctorId",
                table: "Appointment",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Users_UserId",
                table: "Appointment",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentPayment_Appointment_AppointmentId",
                table: "AppointmentPayment",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentPayment_Doctors_DoctorId",
                table: "AppointmentPayment",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentPayment_Users_UserId",
                table: "AppointmentPayment",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalCabinets_AppointmentPayment_AppointmentId",
                table: "PersonalCabinets",
                column: "AppointmentId",
                principalTable: "AppointmentPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctors_DoctorId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Users_UserId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentPayment_Appointment_AppointmentId",
                table: "AppointmentPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentPayment_Doctors_DoctorId",
                table: "AppointmentPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentPayment_Users_UserId",
                table: "AppointmentPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalCabinets_AppointmentPayment_AppointmentId",
                table: "PersonalCabinets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentPayment",
                table: "AppointmentPayment");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentPayment_DoctorId",
                table: "AppointmentPayment");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentPayment_UserId",
                table: "AppointmentPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "AppointmentPayment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppointmentPayment");

            migrationBuilder.RenameTable(
                name: "AppointmentPayment",
                newName: "AppointmentPayments");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentPayment_AppointmentId",
                table: "AppointmentPayments",
                newName: "IX_AppointmentPayments_AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_UserId",
                table: "Appointments",
                newName: "IX_Appointments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointments",
                newName: "IX_Appointments_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentPayments",
                table: "AppointmentPayments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentPayments_Appointments_AppointmentId",
                table: "AppointmentPayments",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalCabinets_Appointments_AppointmentId",
                table: "PersonalCabinets",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
