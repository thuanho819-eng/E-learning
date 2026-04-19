using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLL.BLL;
using QLL.DTO;
using System.Collections.Generic;
using System.Linq;

public class ChamBaiModel : PageModel
{
    private BaiLamBLL busLam = new BaiLamBLL();

    public List<BaiLamDTO> dsBaiLam = new List<BaiLamDTO>();

    [BindProperty]
    public int MaBaiLam { get; set; }

    [BindProperty]
    public double Diem { get; set; }

    public void OnGet(int maBai)
    {
        dsBaiLam = busLam.GetByBai(maBai)?.ToList() ?? new List<BaiLamDTO>();
    }
    public IActionResult OnPost()
    {
        var dto = new BaiLamDTO
        {
            MaBaiLam = MaBaiLam,
            Diem = Diem
        };

        busLam.Update(dto);

        TempData["Chấm điểm thành công! + MaiBai"] = true;
        return RedirectToPage("/DanhSachBai");
    }
}