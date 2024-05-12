using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTHDT_2023_12_WEB.Pages.Pages_LoaiSanPham
{
    public class MH_Them_LoaiSanPhamModel : PageModel
    {
        [BindProperty]
        public string loaiSanPham { get; set; }

        public string Chuoi { get; set; } = string.Empty;
        private IXuLyLoaiSanPham _xuLyLoaiSanPham = new XuLyLoaiSanPham();
        public void OnGet()
        {

        }
        public void OnPost()
        {
            try
            {
                _xuLyLoaiSanPham.KiemTraTenLoaiSanPham(loaiSanPham);
                var lsp = new LoaiSanPham(loaiSanPham,9999);//put any num here to distinc LoaiSanPham constructor
                _xuLyLoaiSanPham.ThemLoaiSanPham(lsp);
                Response.Redirect("MH_DanhSach_LoaiSanPham");
            }
            catch (Exception ex)
            {
                Chuoi = ex.Message;
            }
        }
    }
}
