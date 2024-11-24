using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASM.Models
{
    [Table("ComboDetail", Schema = "ComboDetail")]
    public class ComboDetail
    {
        public int ComboID { get; set; }

        public int FoodID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập số lượng.")]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [ForeignKey("ComboID")]
        public virtual Combo Combo { get; set; }

        [ForeignKey("FoodID")]
        public virtual Food Food { get; set; }
    }
}
