using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LTHDT_2023_12_Services;
using LTHDT_2023_12_Entities;
namespace LTHDT_2023_12_WEB.Pages
{
    public class MH_DanhSach_LoaiSanPhamModel : PageModel
    {
        private IXuLyLoaiSanPham _xuLyLoaiSanPham = new XuLyLoaiSanPham();
        public List<LoaiSanPham> DanhSachLoaiSanPham;
        public string Chuoi { get; set; } = string.Empty;
        [BindProperty]
        public string TuKhoa { get; set; }
        public void OnGet()
        {
            DanhSachLoaiSanPham = _xuLyLoaiSanPham.DocDanhSachLoaiSanPham();
        }

        public void OnPost()
        {
            if (string.IsNullOrEmpty(TuKhoa))
            {
                Chuoi = "Vui long nhap lai Tu khoa";
                DanhSachLoaiSanPham = _xuLyLoaiSanPham.DocDanhSachLoaiSanPham();
                return;
            }
            DanhSachLoaiSanPham = _xuLyLoaiSanPham.DocDanhSachLoaiSanPham(TuKhoa);
        }

    }
}
