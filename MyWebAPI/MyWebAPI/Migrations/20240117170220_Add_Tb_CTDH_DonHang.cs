using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add_Tb_CTDH_DonHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaDonHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayDatHang = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    NgayGiaoHang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrangDonHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiGiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaDonHang);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    MaDonHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHangHoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    GiamGia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHang", x => new { x.MaHangHoa, x.MaDonHang });
                    table.ForeignKey(
                        name: "FK_CTDH_DonHang",
                        column: x => x.MaDonHang,
                        principalTable: "DonHang",
                        principalColumn: "MaDonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTDH_HangHoa",
                        column: x => x.MaHangHoa,
                        principalTable: "HangHoa",
                        principalColumn: "MaHangHoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_MaDonHang",
                table: "ChiTietDonHang",
                column: "MaDonHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "DonHang");
        }
    }
}
