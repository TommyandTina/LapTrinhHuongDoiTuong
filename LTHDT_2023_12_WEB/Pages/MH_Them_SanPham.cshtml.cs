using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTHDT_2023_12_WEB.Pages
{
    public class MH_Them_SanPhamModel : PageModel
    {
        [BindProperty]
        public string TenSp { get; set; }
        [BindProperty]
        public int Gia { get; set; }
        [BindProperty]
        public int HanSuDung { get; set; }
        [BindProperty]
        public string CongTySanXuat { get; set; }
        [BindProperty]
        public int NamSanXuat { get; set; }
        [BindProperty]
        public string LoaiSanPham { get; set; }

        public string Chuoi { get; set; } = string.Empty;
        private IXuLySanPham _xuLySanPham = new XuLySanPham();
        public void OnGet()
        {

        }
        public void OnPost()
        {
            try
            {
                var sp = new SanPham(TenSp, Gia, HanSuDung,CongTySanXuat,NamSanXuat,LoaiSanPham);
                _xuLySanPham.ThemSanPham(sp);
                Response.Redirect("/MH_DanhSach_SanPham");
            }
            catch(Exception ex)
            {
                Chuoi = ex.Message;
            }
        }
    }
}
