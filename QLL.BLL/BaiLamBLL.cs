using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLL.DAL;
using QLL.DTO;

namespace QLL.BLL
{
    public class BaiLamBLL
    {
        private BaiLamDAL dal;

        public BaiLamBLL()
        {
            dal = new BaiLamDAL();
        }

        public BaiLamDTO Add(BaiLamDTO dto)
        {
            return dal.Add(dto);
        }

        // 👉 (nên có) lấy bài đã làm theo MaBai
        public IList<BaiLamDTO> GetByBai(int maBai)
        {
            return dal.GetByBai(maBai);
        }

        // 👉 (nên có) lấy theo học sinh
        public IList<BaiLamDTO> GetByHocSinh(string maHs)
        {
            return dal.GetByHocSinh(maHs);
        }
    }
}