using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASM.Models
{
    public class BillDetail
    {
        [Key]
        [Column(Order = 0)]
        public int BillID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int FoodID { get; set; }

        public int? ComboID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập số lượng.")]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập thành tiền.")]
        [Range(0, double.MaxValue, ErrorMessage = "Thành tiền phải lớn hơn hoặc bằng 0.")]
        [Display(Name = "Thành tiền")]
        public decimal SubTotal { get; set; }

        [ForeignKey("BillID")]
        public virtual Bill Bill { get; set; }

        [ForeignKey("FoodID")]
        public virtual Food Food { get; set; }

        [ForeignKey("ComboID")]
        public virtual Combo Combo { get; set; }
    }

}
