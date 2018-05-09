using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CinemaData.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowingSeats_Showings_Showingid",
                table: "ShowingSeats");

            migrationBuilder.RenameColumn(
                name: "Showingid",
                table: "ShowingSeats",
                newName: "ShowingId");

            migrationBuilder.RenameIndex(
                name: "IX_ShowingSeats_Showingid",
                table: "ShowingSeats",
                newName: "IX_ShowingSeats_ShowingId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Showings",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "ShowingSeats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShowingSeats_SeatId",
                table: "ShowingSeats",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowingSeats_Seats_SeatId",
                table: "ShowingSeats",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowingSeats_Showings_ShowingId",
                table: "ShowingSeats",
                column: "ShowingId",
                principalTable: "Showings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowingSeats_Seats_SeatId",
                table: "ShowingSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowingSeats_Showings_ShowingId",
                table: "ShowingSeats");

            migrationBuilder.DropIndex(
                name: "IX_ShowingSeats_SeatId",
                table: "ShowingSeats");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "ShowingSeats");

            migrationBuilder.RenameColumn(
                name: "ShowingId",
                table: "ShowingSeats",
                newName: "Showingid");

            migrationBuilder.RenameIndex(
                name: "IX_ShowingSeats_ShowingId",
                table: "ShowingSeats",
                newName: "IX_ShowingSeats_Showingid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Showings",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowingSeats_Showings_Showingid",
                table: "ShowingSeats",
                column: "Showingid",
                principalTable: "Showings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
