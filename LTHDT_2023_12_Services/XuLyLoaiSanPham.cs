using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHDT_2023_12_Services
{
    public class XuLyLoaiSanPham : IXuLyLoaiSanPham
    {
        private ILuuTruLoaiSanPham _luuTruLoaiSanPham = new LuuTruLoaiSanPham();
        public List<LoaiSanPham> DocDanhSachLoaiSanPham(string tenLoaiSanPham = "")
        {
            List<LoaiSanPham> kq = new List<LoaiSanPham>();
            var dsslp = _luuTruLoaiSanPham.DocDanhSachLoaiSanPham();
            // Tìm kiếm danh sách loại sản phẩm
            foreach (var lsp in dsslp)
            {
                if (lsp.loaiSanPham.Contains(tenLoaiSanPham))
                {
                    kq.Add(lsp);
                }
            }
            return kq;
        }

        public void ThemLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            var dsslp = _luuTruLoaiSanPham.DocDanhSachLoaiSanPham();
            int maxId = 0;
            foreach (var lsp in dsslp)
            {
                if (lsp.MaLoaiSanPham > maxId)
                {
                    maxId = lsp.MaLoaiSanPham;
                }
            }
            loaiSanPham.MaLoaiSanPham = maxId + 1;
            _luuTruLoaiSanPham.ThemLoaiSanPham(loaiSanPham);
        }

        public int XoaLoaiSanPham(int maLoaiSanPham)
        {
            var dsslp = _luuTruLoaiSanPham.DocDanhSachLoaiSanPham();
            foreach (var lsp in dsslp)
            {
                if (lsp.MaLoaiSanPham == maLoaiSanPham)
                {
                    _luuTruLoaiSanPham.XoaLoaiSanPham(maLoaiSanPham);
                    return 1;
                }
            }
            return -1;
        }

        public void SuaLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            _luuTruLoaiSanPham.SuaLoaiSanPham(loaiSanPham);
        }

        public void KiemTraTenLoaiSanPham(string tenLoaiSanPham)
        {
            var dslsp = _luuTruLoaiSanPham.DocDanhSachLoaiSanPham();
            foreach (var lsp in dslsp)
            {
                if (lsp.loaiSanPham == tenLoaiSanPham)
                {
                    throw new Exception("Ten loai san pham da ton tai");
                }
            }
        }

        public void KiemTraTenLoaiSanPham(string tenLoaiSanPhamMoi, string tenLoaiSanPhamHienTai)
        {
            var dslsp = _luuTruLoaiSanPham.DocDanhSachLoaiSanPham();
            foreach (var lsp in dslsp)
            {
                if (lsp.loaiSanPham == tenLoaiSanPhamMoi && lsp.loaiSanPham != tenLoaiSanPhamHienTai)
                {
                    throw new Exception("Ten loai san pham da ton tai");
                }
            }
        }
    }
}
