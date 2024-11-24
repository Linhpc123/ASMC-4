using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.Models
{
    [Table("Combo", Schema = "Combo")]
    public class Combo
    {
        [Key]
        public int ComboID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên combo.")]
        [StringLength(150, ErrorMessage = "Tên combo không được vượt quá 150 ký tự.")]
        [Display(Name = "Tên combo")]
        public string ComboName { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả combo không được vượt quá 500 ký tự.")]
        [Display(Name = "Mô tả combo")]
        public string ComboDescription { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập giá combo.")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0.")]
        [Display(Name = "Giá combo")]
        public decimal Price { get; set; }

        public virtual ICollection<ComboDetail> ComboDetails { get; set; }
    }

}
