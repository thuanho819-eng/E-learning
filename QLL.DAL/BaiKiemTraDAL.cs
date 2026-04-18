using QLL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using QLL.DTO;

namespace QLL.DAL
{
    public class BaiKiemTraDAL
    {
        private QuanLyLopContext db;

        public BaiKiemTraDAL()
        {
            db = new QuanLyLopContext();
        }

        public BaiKiemTraDTO Add(BaiKiemTraDTO dto)
        {
            BaiKiemTraDTO res = new BaiKiemTraDTO();

            var entity = new BaiKiemTra
            {
                TenBai = dto.TenBai,
                NoiDung = dto.NoiDung,
                NgayTao = dto.NgayTao,
                MaGv = dto.MaGv
            };

            try
            {
                db.BaiKiemTras.Add(entity);
                db.SaveChanges();

                res.MaBai = entity.MaBai;
                res.TenBai = entity.TenBai;
                res.NoiDung = entity.NoiDung;
                res.NgayTao = entity.NgayTao;
                res.MaGv = entity.MaGv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                res = null;
            }

            return res;
        }

        // 👉 CHUẨN ADMIN STYLE
        public IList<BaiKiemTraDTO> GetAll()
        {
            List<BaiKiemTraDTO> res = new List<BaiKiemTraDTO>();

            try
            {
                var ls = db.BaiKiemTras.ToList();

                foreach (var b in ls)
                {
                    BaiKiemTraDTO dto = new BaiKiemTraDTO();

                    dto.MaBai = b.MaBai;
                    dto.TenBai = b.TenBai;
                    dto.NoiDung = b.NoiDung;
                    dto.NgayTao = b.NgayTao;
                    dto.MaGv = b.MaGv;

                    res.Add(dto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // KHÔNG set null
            }

            return res;
        }

        public BaiKiemTraDTO GetById(int id)
        {
            BaiKiemTraDTO res = new BaiKiemTraDTO();

            var e = db.BaiKiemTras.FirstOrDefault(x => x.MaBai == id);

            if (e != null)
            {
                res.MaBai = e.MaBai;
                res.TenBai = e.TenBai;
                res.NoiDung = e.NoiDung;
                res.NgayTao = e.NgayTao;
                res.MaGv = e.MaGv;
            }

            return res;
        }
    }
}