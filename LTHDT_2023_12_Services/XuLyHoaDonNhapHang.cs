using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHDT_2023_12_Services
{
    public class XuLyHoaDonNhapHang :IXuLyHoaDonNhapHang
    {
        private ILuuTruHoaDonNhapHang _luuTruHoaDonNhapHang = new LuuTruHoaDonNhapHang();

        public List<HoaDonNhapHang> DocDanhSachHoaDon(int maHoaDon = -1)
        {
            List<HoaDonNhapHang> kq = new List<HoaDonNhapHang>();
            var dsHoaDon = _luuTruHoaDonNhapHang.DocDanhSachHoaDon();
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

        public void ThemHoaDon(HoaDonNhapHang hoaDon)
        {
            var dsHoaDon = _luuTruHoaDonNhapHang.DocDanhSachHoaDon();
            int maxId = 0;
            foreach (var hd in dsHoaDon)
            {
                if (hd.MaHoaDon > maxId)
                {
                    maxId = hd.MaHoaDon;
                }
            }
            hoaDon.MaHoaDon = maxId + 1;
            _luuTruHoaDonNhapHang.ThemHoaDon(hoaDon);
        }

        public int XoaHoaDon(int maHoaDon)
        {
            var dshd = _luuTruHoaDonNhapHang.DocDanhSachHoaDon();
            foreach (var hd in dshd)
            {
                if (hd.MaHoaDon == maHoaDon)
                {
                    _luuTruHoaDonNhapHang.XoaHoaDon(maHoaDon);
                    return 1;
                }
            }
            return -1;
        }

        public void SuaHoaDon(HoaDonNhapHang hoaDon)
        {
            _luuTruHoaDonNhapHang.SuaHoaDon(hoaDon);
        }
    }
}
