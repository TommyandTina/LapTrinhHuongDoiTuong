using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTHDT_2023_12_WEB.Pages.Pages_LoaiSanPham
{
    public class MH_Xoa_LoaiSanPhamModel : PageModel
    {
        [BindProperty]
        public int maLoaiSanPham { get; set; }

        public string Chuoi { get; set; } = string.Empty;
        public int found { get; set; } = 0;

        private IXuLyLoaiSanPham _xuLyLoaiSanPham = new XuLyLoaiSanPham();

        public List<LoaiSanPham> DanhSachLoaiSanPham;

        public void OnGet(int maLoaiSanPhamInput, string tenLoaiSanPham)
        {
            maLoaiSanPham = maLoaiSanPhamInput;
            DanhSachLoaiSanPham = _xuLyLoaiSanPham.DocDanhSachLoaiSanPham(tenLoaiSanPham);
        }

        public void OnPost()
        {
            found = _xuLyLoaiSanPham.XoaLoaiSanPham(maLoaiSanPham);
            if (found == 1)
            {
                Response.Redirect("MH_DanhSach_LoaiSanPham");
            }
            if (found == -1)
            {
                Chuoi = "Vui long nhap lai ma san pham de xoa";
            }
        }
    }
}
