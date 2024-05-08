using LTHDT_2023_12_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHDT_2023_12_Repo
{
    public interface ILuuTruHoaDonBanHang
    {
        List<HoaDonBanHang> DocDanhSachHoaDon();
        void ThemHoaDon(HoaDonBanHang hoaDon);
        void XoaHoaDon(int maHoaDon);
        void SuaHoaDon(HoaDonBanHang sanPhamInput);
    }
}
