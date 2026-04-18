using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using QLL.BLL;
using QLL.DTO;
using System;

namespace QuanLyLop2_ASP.NETCore.Pages
{
    public class TaoBaiModel : PageModel
    {
        private BaiKiemTraBLL bus;

        [BindProperty]
        public BaiKiemTraDTO Bai { get; set; }

        public TaoBaiModel()
        {
            bus = new BaiKiemTraBLL();
        }

        public IActionResult OnGet()
        {
            var user = HttpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(user) || !user.StartsWith("gv"))
                return RedirectToPage("/DanhSachBai");

            return Page();
        }

        public IActionResult OnPost()
        {
            var user = HttpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(user))
            {
                TempData["msg"] = "Chưa đăng nhập";
                return RedirectToPage("/Index");
            }

            if (string.IsNullOrEmpty(Bai.TenBai) || string.IsNullOrEmpty(Bai.NoiDung))
            {
                TempData["msg"] = "Nhập thiếu thông tin";
                return Page();
            }

            Bai.NgayTao = DateTime.Now;
            Bai.MaGv = user;

            var res = bus.Add(Bai);

            if (res != null)
            {
                TempData["msg"] = "Tạo bài thành công!";
                return RedirectToPage("/DanhSachBai");
            }

            TempData["msg"] = "Tạo bài thất bại!";
            return Page();
        }
    }
}