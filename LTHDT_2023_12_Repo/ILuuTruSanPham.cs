﻿using LTHDT_2023_12_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHDT_2023_12_Repo
{
    public interface ILuuTruSanPham
    {
        List<SanPham> DocDanhSachSanPham();
        void ThemSanPham(SanPham sanPham);
        void XoaSanPham(int maSanPham);
        void SuaSanPham(SanPham sanPhamInput);
        //neu them thi so luong them vao la so duong, con giam thi la so am
        void CapNhatSoLuongSanPham(int maSanPham, int soLuongDuocThemVao);

    }
}
