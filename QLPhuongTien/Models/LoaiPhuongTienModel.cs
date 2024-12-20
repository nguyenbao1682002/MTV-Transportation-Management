using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLPhuongTien.Models
{
    public class LoaiPhuongTienModel
    {
        
        [Display(Name = "Mã loại phương tiện")]
        [Required(ErrorMessage = "Mã loại phương tiện không được để trống")]
        public string ma_loai_ptien { get; set; }

        [Required(ErrorMessage = "Tên loại phương tiện không được để trống")]
        [Display(Name = "Tên loại phương tiện")]
        public string ten_loai_ptien { get; set; }

        [Display(Name = "STT")]
        public int stt { get; set; }

        [Display(Name = "Người nhập")]
        public string nguoi_nhap { get; set; }

        [Display(Name = "Ngày nhập")]
        public DateTime ngay_nhap { get; set; }
    }
}