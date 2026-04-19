using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using QLL.DTO;
using QLL.BLL;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;

namespace QuanLyLop2_ASP.NETCore.Pages
{
    public class DanhSachBaiModel : PageModel
    {
        private BaiKiemTraBLL bus;

        public List<BaiKiemTraDTO> lstBai;
        public List<BaiLamDTO> dsBaiLam = new List<BaiLamDTO>();

        [BindProperty]
        public int maBai { get; set; }

        public DanhSachBaiModel()
        {
            bus = new BaiKiemTraBLL();
        }

        public void OnGet()
        {
            var data = bus.GetAll();
            lstBai = data != null ? data.ToList() : new List<BaiKiemTraDTO>();

            var user = HttpContext.Session.GetString("user_id");

            if (!string.IsNullOrEmpty(user) && user.StartsWith("hs"))
            {
                dsBaiLam = new BaiLamBLL()
                                .GetByHocSinh(user)?
                                .ToList()
                            ?? new List<BaiLamDTO>();
            }
        }

        public void OnPost()
        {
            if (maBai != 0)
            {
                lstBai = bus.GetAll().Where(x => x.MaBai == maBai).ToList();
            }
            else
            {
                lstBai = bus.GetAll()?.ToList() ?? new List<BaiKiemTraDTO>();
            }
        }
        public IActionResult OnPostAdd(string bai)
        {
            var obj = JsonSerializer.Deserialize<BaiKiemTraDTO>(bai);
            obj.NgayTao = DateTime.Now;

            var user = HttpContext.Session.GetString("user_id");
            obj.MaGv = user;

            var res = bus.Add(obj);

            if (res != null)
                return new ObjectResult(new { success = true, data = res }) { StatusCode = 200 };

            return new ObjectResult(new { success = false }) { StatusCode = 500 };
        }
        
    }
}