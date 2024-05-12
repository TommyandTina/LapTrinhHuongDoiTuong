using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTHDT_2023_12_Entities;


namespace LTHDT_2023_12_Repo
{
    public class LuuTruHoaDonBanHang : ILuuTruHoaDonBanHang
    {
        private string _filePath = "hdbh.txt";//thêm đường dẫn vào

        public List<HoaDonBanHang> DocDanhSachHoaDon()
        {
            List<HoaDonBanHang> dsHoaDon = new List<HoaDonBanHang>();
            StreamReader file = new StreamReader(_filePath);
            //dòng đầu tiên là số lượng
            int n;
            string s = file.ReadLine();
            n = int.Parse(s);
            for (int i = 0; i < n; i++)
            {
                s = file.ReadLine();
                dsHoaDon.Add(new HoaDonBanHang(s));
            }

            file.Close();
            return dsHoaDon;
        }

        public void LuuDanhSachHoaDon(List<HoaDonBanHang> dsHoaDon)
        {
            StreamWriter file = new StreamWriter(_filePath);
            file.WriteLine(dsHoaDon.Count);
            foreach (var hoaDon in dsHoaDon)
            {
                file.WriteLine($"{hoaDon.MaHoaDon},{hoaDon.sanPham.MaSanPham},{hoaDon.sanPham.TenSanPham},{hoaDon.sanPham.Gia},{hoaDon.TenNguoiMua},{hoaDon.SoLuongMua},{hoaDon.ThanhTien}");
            }

            file.Close();
        }

        public void ThemHoaDon(HoaDonBanHang hoaDon)
        {
            var dsHoaDon = DocDanhSachHoaDon();
            dsHoaDon.Add(hoaDon);
            LuuDanhSachHoaDon(dsHoaDon);
        }

        public void XoaHoaDon(int maHoaDon)
        {
            var dsHoaDon = DocDanhSachHoaDon();
            var hoaDon = dsHoaDon.FirstOrDefault(hd => hd.MaHoaDon == maHoaDon);
            if (hoaDon != null)
            {
                dsHoaDon.Remove(hoaDon);
                LuuDanhSachHoaDon(dsHoaDon);
            }
        }

        public void SuaHoaDon(HoaDonBanHang hoaDonInput)
        {
            var dsHoaDon = DocDanhSachHoaDon();
            int maHoaDon = hoaDonInput.MaHoaDon;
            var hoaDon = dsHoaDon.FirstOrDefault(hd => hd.MaHoaDon == maHoaDon);
            if (hoaDon != null)
            {
                hoaDon.CopyFrom(hoaDonInput);
                LuuDanhSachHoaDon(dsHoaDon);
            }
        }
    }
}
