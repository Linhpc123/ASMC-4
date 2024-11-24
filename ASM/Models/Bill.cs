using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASM.Models
{
    public enum StatusBill
    {
        [Display(Name = "Mới Đặt")]
        MoiDat = 0,
        [Display(Name = "Quán Đang Thực Hiện")]
        QuanDangThucHien = 1,
        [Display(Name = "Đang Giao")]
        ĐangGiao = 0,
        [Display(Name = "Đã Giao")]
        DaGiao = 1,
        [Display(Name = "Hủy Đơn")]
        HuyDon = 1,
    }
    [Table("Bill", Schema = "Bill")]
    public class Bill
    {
        [Key]
        public int BillID { get; set; }

        [Required(ErrorMessage = "Bạn cần chọn khách hàng.")]
        [Display(Name = "Mã khách hàng")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tổng tiền.")]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng tiền phải lớn hơn hoặc bằng 0.")]
        [Display(Name = "Tổng tiền")]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập ngày tạo.")]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập trạng thái đơn hàng.")]
        [StringLength(50, ErrorMessage = "Trạng thái không được vượt quá 50 ký tự.")]
        [Display(Name = "Trạng thái")]
        public StatusBill Status { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }

}
