using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIGraduation.Migrations.Spark
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

           

            

            

            

            

            

            migrationBuilder.CreateIndex(
                name: "IX_user_boot_purchases_boot_id",
                table: "user_boot_purchases",
                column: "boot_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_boot_purchases_user_id",
                table: "user_boot_purchases",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_oxford_purchases_oxford_id",
                table: "user_oxford_purchases",
                column: "oxford_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_oxford_purchases_user_id",
                table: "user_oxford_purchases",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_sport_purchases_sport_id",
                table: "user_sport_purchases",
                column: "sport_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_sport_purchases_user_id",
                table: "user_sport_purchases",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "Prouduct");

            migrationBuilder.DropTable(
                name: "Trending_selling");

            migrationBuilder.DropTable(
                name: "user_boot_purchases");

            migrationBuilder.DropTable(
                name: "user_oxford_purchases");

            migrationBuilder.DropTable(
                name: "user_sport_purchases");

            migrationBuilder.DropTable(
                name: "boots");

            migrationBuilder.DropTable(
                name: "oxford");

            migrationBuilder.DropTable(
                name: "sport");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
