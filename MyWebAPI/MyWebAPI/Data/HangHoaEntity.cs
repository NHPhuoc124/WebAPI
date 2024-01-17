using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPI.Data
{
    [Table("HangHoa")]
    public class HangHoaEntity
    {
        [Key]
        public Guid MaHangHoa {  get; set; }
        [Required]
        [StringLength(100)]
        public string TenHangHoa {  set; get; }
        public string? Mota {  set; get; }
        [Range(0, double.MaxValue)]
        public double DonGia { set; get; }
        [Range(0, 100)]
        public byte GiamGia { set; get; }

        public int? MaLoai { set; get; }
        [ForeignKey("MaLoai")]
        public LoaiEntity Loai { set; get; }
        public ICollection<ChiTietDonHangEntity> ChiTietDonHangs { get; set; }

        public HangHoaEntity()
        {
            ChiTietDonHangs = new List<ChiTietDonHangEntity>();
        }
    }
}
