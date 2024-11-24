using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASM.Models
{
    public enum StatusFood
    {
        [Display(Name = "Còn Món")]
        ConMon = 0,
        [Display(Name = "Đã Hết Món")]
        HetMon = 1,
    }

       
    [Table("Food", Schema = "Food")]
    public class Food
    {
        [Key]
        public int FoodID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên món ăn.")]
        [StringLength(150, ErrorMessage = "Tên món ăn không được vượt quá 150 ký tự.")]
        [Display(Name = "Tên món ăn")]
        public string FoodName { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập giá món ăn.")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0.")]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Bạn cần chọn loại món ăn.")]
        [Display(Name = "Loại món ăn")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập trạng thái món ăn.")]
        [Display(Name = "Trạng thái")]
        public StatusFood Status { get; set; }

        [StringLength(150, ErrorMessage = "Chủ đề không được vượt quá 150 ký tự.")]
        [Display(Name = "Chủ đề")]
        public string Themes { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual ICollection<ComboDetail> ComboDetails { get; set; }
    }

}
