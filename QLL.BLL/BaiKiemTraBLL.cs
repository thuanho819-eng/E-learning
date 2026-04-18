using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLL.DAL;
using QLL.DTO;

namespace QLL.BLL
{
    public class BaiKiemTraBLL
    {
        private BaiKiemTraDAL dal;

        public BaiKiemTraBLL()
        {
            dal = new BaiKiemTraDAL();
        }

        public BaiKiemTraDTO Add(BaiKiemTraDTO dto)
        {
            return dal.Add(dto);
        }

        public BaiKiemTraDTO GetById(int id)
        {
            return dal.GetById(id);
        }

        // 👉 THÊM GIỐNG ADMIN
        public IList<BaiKiemTraDTO> GetAll()
        {
            return dal.GetAll();
        }
    }
}