using LTHDT_2023_12_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHDT_2023_12_Repo
{
    internal interface ILuuTruLoaiSanPham
    {
        List<LoaiSanPham> DocDanhSachLoaiSanPham();
        void ThemLoaiSanPham(LoaiSanPham loaiSanPham);
        void XoaLoaiSanPham(int maLoaiSanPham);
        void SuaLoaiSanPham(LoaiSanPham loaiSanPhamInput);
    }
}
