using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lap2.Migrations
{
    /// <inheritdoc />
    public partial class lap2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Addr_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Home_addr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Office_addr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Addr_ID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MANV = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    HONV = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TENLOT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TENNV = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NGAYSINH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DCHI = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PHAI = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    LUONG = table.Column<float>(type: "real", nullable: false),
                    MA_NQL = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    PHG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MANV);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    clientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address_ID = table.Column<int>(type: "int", nullable: false),
                    phoneNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.clientName);
                    table.ForeignKey(
                        name: "FK_Clients_Addresses_Address_ID",
                        column: x => x.Address_ID,
                        principalTable: "Addresses",
                        principalColumn: "Addr_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThanNhans",
                columns: table => new
                {
                    MA_NVIEN = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    TENTN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PHAI = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NGSINH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QUANHE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanNhans", x => new { x.MA_NVIEN, x.TENTN });
                    table.ForeignKey(
                        name: "FK_ThanNhans_NhanViens_MA_NVIEN",
                        column: x => x.MA_NVIEN,
                        principalTable: "NhanViens",
                        principalColumn: "MANV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromYear = table.Column<int>(type: "int", nullable: false),
                    ToYear = table.Column<int>(type: "int", nullable: true),
                    Current = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonCompanies_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Address_ID",
                table: "Clients",
                column: "Address_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonCompanies_CompanyId",
                table: "PersonCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonCompanies_PersonId",
                table: "PersonCompanies",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "PersonCompanies");

            migrationBuilder.DropTable(
                name: "ThanNhans");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "NhanViens");
        }
    }
}
