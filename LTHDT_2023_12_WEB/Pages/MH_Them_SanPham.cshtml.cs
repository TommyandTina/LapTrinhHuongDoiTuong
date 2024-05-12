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
        public List<LoaiSanPham> DanhSachLoaiSanPham;
        public string Chuoi { get; set; } = string.Empty;
        private IXuLySanPham _xuLySanPham = new XuLySanPham();
        private IXuLyLoaiSanPham _xuLyLoaiSanPham = new XuLyLoaiSanPham();

        public void OnGet()
        {
            DanhSachLoaiSanPham = _xuLyLoaiSanPham.DocDanhSachLoaiSanPham();
        }
        public void OnPost()
        {
            DanhSachLoaiSanPham = _xuLyLoaiSanPham.DocDanhSachLoaiSanPham();
            try
            {
                _xuLySanPham.KiemTraTenSanPham(TenSp);
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
