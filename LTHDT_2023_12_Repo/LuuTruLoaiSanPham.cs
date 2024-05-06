using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTHDT_2023_12_Entities;

namespace LTHDT_2023_12_Repo
{
    public class LuuTruLoaiSanPham : ILuuTruLoaiSanPham
    {
        private string _filePath = "E:\\dslsp.txt";//thêm đường dẫn vào
        public List<LoaiSanPham> DocDanhSachLoaiSanPham()
        {
            List<LoaiSanPham> dsLoaiSanPham = new List<LoaiSanPham>();
            StreamReader file = new StreamReader(_filePath);
            //dòng đầu tiên là số lượng
            int n;
            //string s = file.ReadLine();
            string s = file.ReadLine();
            n = int.Parse(s);
            for (int i = 0; i < n; i++)
            {
                s = file.ReadLine();
                dsLoaiSanPham.Add(new LoaiSanPham(s));
            }

            file.Close();
            return dsLoaiSanPham;
        }

        public List<LoaiSanPham> LuuDanhSachLoaiSanPham(List<LoaiSanPham> dsLoaiSanPham)
        {
            StreamWriter file = new StreamWriter(_filePath);
            file.WriteLine(dsLoaiSanPham.Count);
            foreach (var sp in dsLoaiSanPham)
            {
                file.WriteLine($"{sp.MaLoaiSanPham},{sp.loaiSanPham}");
            }

            file.Close();
            return dsLoaiSanPham;
        }
        public void ThemLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            var dslsp = DocDanhSachLoaiSanPham();
            dslsp.Add(loaiSanPham);
            LuuDanhSachLoaiSanPham(dslsp);
        }

        public void XoaLoaiSanPham(int maLoaiSanPham)
        {
            var dslsp = DocDanhSachLoaiSanPham();
            var loaiSanPham = dslsp.FirstOrDefault(sp => sp.MaLoaiSanPham == maLoaiSanPham);
            if (loaiSanPham != null)
            {
                dslsp.Remove(loaiSanPham);
                LuuDanhSachLoaiSanPham(dslsp);
            }
        }

        public void SuaLoaiSanPham(LoaiSanPham loaiSanPhamInput)
        {
            var dslsp = DocDanhSachLoaiSanPham();
            int maLoaiSanPham = loaiSanPhamInput.MaLoaiSanPham;
            var loaiSanPham = dslsp.FirstOrDefault(sp => sp.MaLoaiSanPham == maLoaiSanPham);
            if (loaiSanPham != null)
            {
                loaiSanPham.CopyFrom(loaiSanPhamInput);

                LuuDanhSachLoaiSanPham(dslsp);
            }
        }
    }
}
