using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Repo;

namespace LTHDT_2023_12_Services
{
    public class XuLyHoaDonBanHang : IXuLyHoaDonBanHang
    {
        private ILuuTruHoaDonBanHang _luuTruHoaDonBanHang = new LuuTruHoaDonBanHang();

        public List<HoaDonBanHang> DocDanhSachHoaDon(int maHoaDon = -1)
        {
            List<HoaDonBanHang> kq = new List<HoaDonBanHang>();
            var dsHoaDon = _luuTruHoaDonBanHang.DocDanhSachHoaDon();
            // Tìm kiếm hóa đơn trong danh sách
            foreach (var hoaDon in dsHoaDon)
            {
                if (hoaDon.MaHoaDon == maHoaDon)
                {
                    kq.Add(hoaDon);
                }
                if (maHoaDon == -1) //default value, cannot input negative number
                {
                    kq.Add(hoaDon);
                }
            }
            return kq;
        }

        public void ThemHoaDon(HoaDonBanHang hoaDon)
        {
            var dsHoaDon = _luuTruHoaDonBanHang.DocDanhSachHoaDon();
            int maxId = 0;
            foreach (var hd in dsHoaDon)
            {
                if (hd.MaHoaDon > maxId)
                {
                    maxId = hd.MaHoaDon;
                }
            }
            hoaDon.MaHoaDon = maxId + 1;
            _luuTruHoaDonBanHang.ThemHoaDon(hoaDon);
        }

        public int XoaHoaDon(int maHoaDon)
        {
            var dshd = _luuTruHoaDonBanHang.DocDanhSachHoaDon();
            foreach (var hd in dshd)
            {
                if (hd.MaHoaDon == maHoaDon)
                {
                    _luuTruHoaDonBanHang.XoaHoaDon(maHoaDon);
                    return 1;
                }
            }
            return -1;
        }

        public void SuaHoaDon(HoaDonBanHang hoaDon)
        {
            _luuTruHoaDonBanHang.SuaHoaDon(hoaDon);
        }
    }
}
