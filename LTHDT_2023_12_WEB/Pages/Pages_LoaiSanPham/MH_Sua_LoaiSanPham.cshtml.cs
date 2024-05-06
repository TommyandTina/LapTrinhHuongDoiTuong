using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTHDT_2023_12_WEB.Pages.Pages_LoaiSanPham
{
    public class MH_Sua_LoaiSanPhamModel : PageModel
    {
        [BindProperty]
        public int maLoaiSanPham { get; set; }

        [BindProperty]
        public string loaiSanPham { get; set; }

        public string Chuoi { get; set; } = string.Empty;
        public int found { get; set; } = 0;

        private IXuLyLoaiSanPham _xuLyLoaiSanPham = new XuLyLoaiSanPham();
        public List<LoaiSanPham> DanhSachLoaiSanPham;


        public void OnGet(int maLoaiSanPhamInput, string tenLoaiSanPham)
        {
            maLoaiSanPham = maLoaiSanPhamInput;
            DanhSachLoaiSanPham = _xuLyLoaiSanPham.DocDanhSachLoaiSanPham(tenLoaiSanPham);
            loaiSanPham = DanhSachLoaiSanPham[0].loaiSanPham;
        }

        public void OnPost()
        {

            try
            {
                LoaiSanPham loaiSp = new LoaiSanPham(maLoaiSanPham, loaiSanPham);
                _xuLyLoaiSanPham.SuaLoaiSanPham(loaiSp);
            }
            catch (Exception ex)
            {
                Chuoi = ex.Message;
            }
            if (string.IsNullOrEmpty(Chuoi))
            {
                Response.Redirect("MH_DanhSach_LoaiSanPham");
            }
        }
    }
}
