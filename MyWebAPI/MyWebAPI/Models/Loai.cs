using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Models
{
    public class Loai
    {
        [Required]
        [MaxLength(100)]
        public string TenLoai { get; set; }
    }
}
