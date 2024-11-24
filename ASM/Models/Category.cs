using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.Models
{
    [Table("Category", Schema = "Category")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên loại món ăn.")]
        [StringLength(150, ErrorMessage = "Tên loại món ăn không được vượt quá 150 ký tự.")]
        [Display(Name = "Tên loại món ăn")]
        public string CategoryName { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }

}
