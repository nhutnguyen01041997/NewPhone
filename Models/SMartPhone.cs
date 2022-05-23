using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace NewPhone.Models
{
    public class SMartPhone
    {
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string Title { get; set; }
        [Display(Name = "Ngày sản xuất")] // sử dụng Display để đặt tên trường theo ý muốn
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Hãng điện thoại")]
        public string Genre { get; set; }
        [Display(Name = "Giá bán")]
        [Column(TypeName = "decimal(18, 2)")]  // ta có chiều dài tối đa là 18 số và phần số lẻ là 2        
        public decimal Price { get; set; }
        public string ProfilePicture { get; set; }

    }
}
