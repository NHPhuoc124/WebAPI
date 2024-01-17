namespace MyWebAPI.Data
{
    public class ChiTietDonHangEntity
    {
        public Guid MaDonHang {  get; set; }
        public Guid MaHangHoa { get; set; }
        public int Soluong { get; set; }
        public double DonGia { get; set; }
        public int GiamGia { get; set; }

        public DonHangEntity DonHang { get; set; }
        public HangHoaEntity HangHoa { get; set; }
    }
}
