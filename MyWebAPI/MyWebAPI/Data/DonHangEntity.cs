namespace MyWebAPI.Data
{
    public class DonHangEntity
    {
        public Guid MaDonHang {  get; set; }
        public DateTime NgayDatHang { get; set; }
        public DateTime NgayGiaoHang { get; set; }
        public string TinhTrangDonHang { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiGiao {  get; set; }
        public int SDT {  get; set; }

        public ICollection<ChiTietDonHangEntity> ChiTietDonHangs { get; set; }

        public DonHangEntity()
        {
            ChiTietDonHangs = new List<ChiTietDonHangEntity>();
        }
    }

    public enum TinhTrangDonHang
    {
        New = 0,
        Payment = 1,
        Complete = 2,
        Cancel = -1
    }
}
