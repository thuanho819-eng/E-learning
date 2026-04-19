using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QLL.DAL.Models
{
    public class BaiLam
    {
        [Key] 
        public int MaBaiLam { get; set; }

        public int MaBai { get; set; }
        public string MaHs { get; set; }
        public string NoiDungTraLoi { get; set; }
        public double? Diem { get; set; }
    }
}