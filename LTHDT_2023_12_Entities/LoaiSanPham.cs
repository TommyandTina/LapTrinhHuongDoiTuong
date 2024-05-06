using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHDT_2023_12_Entities
{
    public class LoaiSanPham
    {
        public int MaLoaiSanPham { get; set; }
        public string loaiSanPham { get; set; }
        public LoaiSanPham()
        {
        }
        public LoaiSanPham(string s)
        {
            string[] m = s.Split(',');
            MaLoaiSanPham = int.Parse(m[0]);
            loaiSanPham = m[1];
        }

        public LoaiSanPham(string loaiSp,int putAnyNumHere)
        {
            //su dung de them loai san pham, ko can biet ma loai san pham
            if (string.IsNullOrEmpty(loaiSp))
            {
                throw new Exception("loai san pham khong hop le");
            }
            loaiSanPham = loaiSp;
        }

        public LoaiSanPham(int maLoaiSanPham, string loaiSp)
        {
            if (maLoaiSanPham <= 0)
            {
                throw new Exception("Ma san pham khong hop le");
            }
        
            if (string.IsNullOrEmpty(loaiSp))
            {
                throw new Exception("loai san pham khong hop le");
            }
            MaLoaiSanPham = maLoaiSanPham;
            loaiSanPham = loaiSp;
        }

        public void CopyFrom(LoaiSanPham other)
        {
            MaLoaiSanPham = other.MaLoaiSanPham;
            loaiSanPham = other.loaiSanPham;
        }
    }
}
