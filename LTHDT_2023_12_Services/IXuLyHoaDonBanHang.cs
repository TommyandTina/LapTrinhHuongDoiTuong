using LTHDT_2023_12_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHDT_2023_12_Services
{
    public interface IXuLyHoaDonBanHang
    {
        List<HoaDonBanHang> DocDanhSachHoaDon(int maHoaDon = -1);
        void ThemHoaDon(HoaDonBanHang hoaDonBanHang);
        int XoaHoaDon(int maHoaDon);
        void SuaHoaDon(HoaDonBanHang hoaDonBanHang);
    }
}
