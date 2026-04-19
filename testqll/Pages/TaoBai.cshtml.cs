using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLL.BLL;
using QLL.DAL.Models;
using QLL.DTO;
using System;

namespace QuanLyLop2_ASP.NETCore.Pages
{
    public class TaoBaiModel : PageModel
    {
        public BaiKiemTraBLL bus;

        [BindProperty]
        public BaiKiemTraDTO Bai { get; set; } = new BaiKiemTraDTO();
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
            Console.WriteLine("USER = " + user);

            Bai.NgayTao = DateTime.Now;
            Bai.MaGv = user.ToUpper();

            Console.WriteLine("==== DEBUG ====");
            Console.WriteLine("USER = " + user);
            Console.WriteLine("TenBai = " + Bai.TenBai);
            Console.WriteLine("NoiDung = " + Bai.NoiDung);
            Console.WriteLine("MaGv = " + Bai.MaGv);
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