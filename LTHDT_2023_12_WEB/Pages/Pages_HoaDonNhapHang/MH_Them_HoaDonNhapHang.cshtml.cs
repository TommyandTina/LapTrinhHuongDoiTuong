using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTHDT_2023_12_WEB.Pages.Pages_HoaDonNhapHang
{
    public class MH_Them_HoaDonNhapHangModel : PageModel
    {
        [BindProperty]
        public int maHoaDon { get; set; }
        [BindProperty]
        public string TenCongTyBan { get; set; }
        [BindProperty]
        public SanPham sanPham { get; set; }
        [BindProperty]
        public string tenSanPham { get; set; }
        [BindProperty]
        public int SoLuongMua { get; set; }
        [BindProperty]
        public int ThanhTien { get; set; }

        public string Chuoi { get; set; } = string.Empty;
        private IXuLyHoaDonNhapHang _xuLyLoaiSanPham = new XuLyHoaDonNhapHang();
        private IXuLySanPham _xuLySanPham = new XuLySanPham();
        public List<SanPham> DanhSachSanPham { get; set; } = new List<SanPham>();
        public void OnGet()
        {
            DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
        }
        public void OnPost()
        {
            try
            {
                sanPham = new SanPham();
                sanPham = _xuLySanPham.DocDanhSachSanPham(tenSanPham)[0];
                var hdbh = new HoaDonNhapHang(sanPham.MaSanPham,sanPham.TenSanPham,sanPham.Gia, TenCongTyBan, SoLuongMua,ThanhTien);//put any num here to distinc LoaiSanPham constructor
                _xuLySanPham.CapNhatSoLuongSanPham(sanPham.MaSanPham, SoLuongMua);
                _xuLyLoaiSanPham.ThemHoaDon(hdbh);
                Response.Redirect("MH_DanhSach_HoaDonNhapHang");
            }
            catch (Exception ex)
            {
                DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
                Chuoi = ex.Message;
            }
        }
    }
}
