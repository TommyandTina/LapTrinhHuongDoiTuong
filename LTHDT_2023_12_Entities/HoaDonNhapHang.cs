using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHDT_2023_12_Entities
{
    public class HoaDonNhapHang
    {
        public int MaHoaDon { get; set; }
        public SanPham sanPham { get; set; }
        public string TenCongTyBan { get; set; }
        public int SoLuongNhap { get; set; }
        public int ThanhTien { get; set; }

        public HoaDonNhapHang(string s)
        {
            string[] m = s.Split(',');
            MaHoaDon = int.Parse(m[0]);
            sanPham = new SanPham();
            sanPham.MaSanPham = int.Parse(m[1]);
            sanPham.TenSanPham = m[2];
            sanPham.Gia = int.Parse(m[3]);
            TenCongTyBan = m[4];
            SoLuongNhap = int.Parse(m[5]);
            ThanhTien = int.Parse(m[6]);
        }

        public HoaDonNhapHang(int maSanPham, string tenSanPham, int gia, string tenCongTyBan, int soLuongNhap, int thanhTien)
        {
            //them hoa don
            if (maSanPham < 0)
            {
                throw new Exception("Ma san pham khong hop le");
            }
            if (string.IsNullOrEmpty(tenSanPham))
            {
                throw new Exception("Ten khong hop le");
            }
            if (gia <= 0)
            {
                throw new Exception("Gia khong hop le");
            }
            if (string.IsNullOrEmpty(tenCongTyBan))
            {
                throw new Exception("tenCongTyBan khong hop le");
            }
            if (soLuongNhap <= 0)
            {
                throw new Exception("soLuongMua khong hop le");
            }
            if (thanhTien < 0)
            {
                throw new Exception("thanhTien khong hop le");
            }
            sanPham = new SanPham();
            sanPham.MaSanPham = maSanPham;
            sanPham.TenSanPham = tenSanPham;
            sanPham.Gia = gia;
            TenCongTyBan = tenCongTyBan;
            SoLuongNhap = soLuongNhap;
            ThanhTien = thanhTien;
        }

        public HoaDonNhapHang(int maHoaDon, int maSanPham, string tenSanPham, int gia, string tenCongTyBan, int soLuongNhap, int thanhTien)
        {
            //sua hoa don
            if (maHoaDon < 0)
            {
                throw new Exception("Ma hoa don khong hop le");
            }
            if (maSanPham < 0)
            {
                throw new Exception("Ma san pham khong hop le");
            }
            if (string.IsNullOrEmpty(tenSanPham))
            {
                throw new Exception("Ten khong hop le");
            }
            if (gia <= 0)
            {
                throw new Exception("Gia khong hop le");
            }
            if (string.IsNullOrEmpty(tenCongTyBan))
            {
                throw new Exception("tenCongTyBan khong hop le");
            }
            if (soLuongNhap <= 0)
            {
                throw new Exception("soLuongNhap khong hop le");
            }
            if (thanhTien < 0)
            {
                throw new Exception("thanhTien khong hop le");
            }
            sanPham = new SanPham();
            MaHoaDon = maHoaDon;
            sanPham.MaSanPham = maSanPham;
            sanPham.TenSanPham = tenSanPham;
            sanPham.Gia = gia;
            TenCongTyBan = tenCongTyBan;
            SoLuongNhap = soLuongNhap;
            ThanhTien = thanhTien;
        }

        public void CopyFrom(HoaDonNhapHang other)
        {
            MaHoaDon = other.MaHoaDon;
            sanPham = new SanPham()
            {
                MaSanPham = other.sanPham.MaSanPham,
                TenSanPham = other.sanPham.TenSanPham,
                Gia = other.sanPham.Gia,
                HanSuDung = other.sanPham.HanSuDung,
                CongTySanXuat = other.sanPham.CongTySanXuat,
                NamSanXuat = other.sanPham.NamSanXuat,
                LoaiSanPham = other.sanPham.LoaiSanPham,
                SoLuong = other.sanPham.SoLuong
            };
            TenCongTyBan = other.TenCongTyBan;
            SoLuongNhap = other.SoLuongNhap;
            ThanhTien = other.ThanhTien;
        }
    }
}

