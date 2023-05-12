using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bsynchro.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class adddatetimetotransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.UtcNow);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionTime",
                table: "Transactions");
        }
    }
}
