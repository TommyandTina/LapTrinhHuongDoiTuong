using LTHDT_2023_12_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHDT_2023_12_Repo
{
    public interface ILuuTruHoaDonNhapHang
    {
        List<HoaDonNhapHang> DocDanhSachHoaDon();
        void ThemHoaDon(HoaDonNhapHang hoaDon);
        void XoaHoaDon(int maHoaDon);
        void SuaHoaDon(HoaDonNhapHang sanPhamInput);
    }
}
