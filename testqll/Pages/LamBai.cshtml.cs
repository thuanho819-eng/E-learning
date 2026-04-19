using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLL.BLL;
using QLL.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyLop2_ASP.NETCore.Pages
{
    public class LamBaiModel : PageModel
    {
        private BaiKiemTraBLL busBai;
        private BaiLamBLL busLam;

        public BaiKiemTraDTO bai;

        [BindProperty]
        public string NoiDungTraLoi { get; set; }

        [BindProperty]
        public int MaBai { get; set; }

        public LamBaiModel()
        {
            busBai = new BaiKiemTraBLL();
            busLam = new BaiLamBLL();
        }

        public void OnGet(int id)
        {
            bai = busBai.GetById(id);
            MaBai = id;
        }
        public IActionResult OnPost()
        {
            var user = HttpContext.Session.GetString("user_id");

            TempData["msg"] = "USER = " + user + " | MaBai = " + MaBai;

            if (string.IsNullOrEmpty(user))
            {
                TempData["msg"] = "Lỗi: chưa đăng nhập!";
                return RedirectToPage("/Index");
            }

            BaiLamDTO dto = new BaiLamDTO
            {
                MaBai = MaBai,
                MaHs = user,
                NoiDungTraLoi = NoiDungTraLoi,
                Diem = null
            };

            var res = busLam.Add(dto);

            if (res != null)
            {
                TempData["msg"] = "Nộp bài thành công!";
                return RedirectToPage("/DanhSachBai");
            }

            bai = busBai.GetById(MaBai);
            TempData["msg"] = "Nộp bài thất bại!";
            return Page();
        }

    }
}