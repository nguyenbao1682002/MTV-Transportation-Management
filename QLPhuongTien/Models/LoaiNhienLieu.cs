using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace QLPhuongTien.Models
{
    public class LoaiNhienLieu
    {
		[Display(Name ="Mã loại nhiên liệu")]
		[Required(ErrorMessage ="Mã loại nhiên liệu không được để trống")]
        public string MA_LOAI_NLIEU { get; set; }

		[Required(ErrorMessage = "Tên loại nhiên liệu không được để trống")]
		[Display(Name = "Tên loại nhiên liệu")]
		public string TEN_LOAI_NLIEU { get; set; }

		[Display(Name = "Đơn giá")]
		[Required(ErrorMessage = "Đơn giá không được để trống")]
        public string DON_GIA { get; set; }

        [Display(Name = "Đơn vị tính")]
        [Required(ErrorMessage = "Đơn vị tính không được để trống")]
        public string DVT { get; set; }

		[Display(Name = "Số thứ tự")]		
		public int STT { get; set; }

		[Display(Name = "Người nhập")]
		public string NGUOI_NHAP { get; set; }

		[Display(Name = "Ngày nhập")]
		public DateTime NGAY_NHAP{ get; set; }


		public LoaiNhienLieu()
		{
			MA_LOAI_NLIEU = "";
			TEN_LOAI_NLIEU = "";
			DON_GIA = "";
			DVT = "";
			STT = 99;
			NGUOI_NHAP = "";
			NGAY_NHAP = DateTime.Now;
		}
	}
}