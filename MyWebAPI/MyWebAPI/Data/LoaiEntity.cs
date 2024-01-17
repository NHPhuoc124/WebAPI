using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPI.Data
{
    [Table("Loai")]
    public class LoaiEntity
    {
        [Key]
        public int MaLoai {  get; set; }
        [Required]
        [MaxLength(100)]
        public string TenLoai { get; set; }

        public virtual ICollection<HangHoaEntity> HangHoas { get; set; }
    }
}
