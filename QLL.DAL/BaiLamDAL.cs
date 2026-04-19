using QLL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using QLL.DTO;
using Microsoft.Data.SqlClient;

namespace QLL.DAL
{
    public class BaiLamDAL
    {
        private QuanLyLopContext db;

        public BaiLamDAL()
        {
            db = new QuanLyLopContext();
        }

        public BaiLamDTO Add(BaiLamDTO dto)
        {
            BaiLamDTO res = new BaiLamDTO();
            try
            {
                var entity = new BaiLam
                {
                    MaBai = dto.MaBai,
                    MaHs = dto.MaHs,
                    NoiDungTraLoi = dto.NoiDungTraLoi,
                    Diem = dto.Diem
                };

                db.BaiLams.Add(entity);
                db.SaveChanges();

                dto.MaBaiLam = entity.MaBaiLam;
                return dto;
            }
            catch
            {
                return null;
            }
        }

        //  LẤY DANH SÁCH THEO BÀI
        public IList<BaiLamDTO> GetByBai(int maBai)
        {
            List<BaiLamDTO> res = new List<BaiLamDTO>();

            try
            {
                var ls = db.BaiLams.Where(x => x.MaBai == maBai).ToList();

                foreach (var b in ls)
                {
                    BaiLamDTO dto = new BaiLamDTO();

                    dto.MaBaiLam = b.MaBaiLam;
                    dto.MaBai = b.MaBai;
                    dto.MaHs = b.MaHs;
                    dto.NoiDungTraLoi = b.NoiDungTraLoi;
                    dto.Diem = b.Diem;

                    res.Add(dto);
                }
            }
            catch
            {
                res = null;
            }

            return res;
        }

        // LẤY THEO HỌC SINH
        public IList<BaiLamDTO> GetByHocSinh(string maHs)
        {
            List<BaiLamDTO> res = new List<BaiLamDTO>();

            try
            {
                var ls = db.BaiLams.Where(x => x.MaHs == maHs).ToList();

                foreach (var b in ls)
                {
                    BaiLamDTO dto = new BaiLamDTO();

                    dto.MaBaiLam = b.MaBaiLam;
                    dto.MaBai = b.MaBai;
                    dto.MaHs = b.MaHs;
                    dto.NoiDungTraLoi = b.NoiDungTraLoi;
                    dto.Diem = b.Diem;

                    res.Add(dto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("LỖI DB: " + ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("INNER: " + ex.InnerException.Message);
                }

                return null;
            }

            return res;
        }

        public void Update(BaiLamDTO dto)
        {
            var entity = db.BaiLams.FirstOrDefault(x => x.MaBaiLam == dto.MaBaiLam);

            if (entity != null)
            {
                entity.Diem = dto.Diem;
                db.SaveChanges();
            }
        }
    }
}