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
        public string LoaiSanPham { get; set; }
        public LoaiSanPham()
        {
        }
        public LoaiSanPham(string s)
        {
            string[] m = s.Split(',');
            MaLoaiSanPham = int.Parse(m[0]);
            LoaiSanPham = m[1];
        }

        public LoaiSanPham(string loaiSanPham,int putAnyNumHere)
        {

            if (string.IsNullOrEmpty(loaiSanPham))
            {
                throw new Exception("loai san pham khong hop le");
            }
            LoaiSanPham = loaiSanPham;
        }

        public LoaiSanPham(int maLoaiSanPham, string loaiSanPham)
        {
            if (maLoaiSanPham <= 0)
            {
                throw new Exception("Ma san pham khong hop le");
            }
        
            if (string.IsNullOrEmpty(loaiSanPham))
            {
                throw new Exception("loai san pham khong hop le");
            }
            MaLoaiSanPham = maLoaiSanPham;
            LoaiSanPham = loaiSanPham;
        }

        public void CopyFrom(LoaiSanPham other)
        {
            MaLoaiSanPham = other.MaLoaiSanPham;
            LoaiSanPham = other.LoaiSanPham;
        }
    }
}
