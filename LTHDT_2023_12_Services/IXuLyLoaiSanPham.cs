using LTHDT_2023_12_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHDT_2023_12_Services
{
    public interface IXuLyLoaiSanPham
    {
        List<LoaiSanPham> DocDanhSachLoaiSanPham(string tuKhoa = "");
        void ThemLoaiSanPham(LoaiSanPham loaiSanPham);
        int XoaLoaiSanPham(int maLoaiSanPham);
        void SuaLoaiSanPham(LoaiSanPham loaiSanPham);
    }
}
