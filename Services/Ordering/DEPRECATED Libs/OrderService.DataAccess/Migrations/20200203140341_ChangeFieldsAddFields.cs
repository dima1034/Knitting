﻿﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderService.DataAccess.Migrations
{
    public partial class ChangeFieldsAddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "finished_at",
                schema: "order_schema",
                table: "order");

            migrationBuilder.DropColumn(
                name: "will_finished_at",
                schema: "order_schema",
                table: "order");

            migrationBuilder.AddColumn<bool>(
                name: "delivered",
                schema: "order_schema",
                table: "order",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "delivery_at",
                schema: "order_schema",
                table: "order",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "duration",
                schema: "order_schema",
                table: "order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "paid",
                schema: "order_schema",
                table: "order",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "delivered",
                schema: "order_schema",
                table: "order");

            migrationBuilder.DropColumn(
                name: "delivery_at",
                schema: "order_schema",
                table: "order");

            migrationBuilder.DropColumn(
                name: "duration",
                schema: "order_schema",
                table: "order");

            migrationBuilder.DropColumn(
                name: "paid",
                schema: "order_schema",
                table: "order");

            migrationBuilder.AddColumn<DateTime>(
                name: "finished_at",
                schema: "order_schema",
                table: "order",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "will_finished_at",
                schema: "order_schema",
                table: "order",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
