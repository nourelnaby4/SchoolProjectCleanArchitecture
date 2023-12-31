﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addlocalizer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "departments");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "subjects",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "subjects",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "departments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "departments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "students");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "students");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "departments");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "subjects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
