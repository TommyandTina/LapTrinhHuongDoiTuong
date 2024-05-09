using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTHDT_2023_12_WEB.Pages.Pages_HoaDonBanHang
{
    public class MH_Them_HoaDonBanHangModel : PageModel
    {
        [BindProperty]
        public int maHoaDon { get; set; }
        [BindProperty]
        public string TenNguoiMua { get; set; }
        [BindProperty]
        public SanPham sanPham { get; set; }
        [BindProperty]
        public string tenSanPham { get; set; }
        [BindProperty]
        public int SoLuongMua { get; set; }
        [BindProperty]
        public int ThanhTien { get; set; }

        public string Chuoi { get; set; } = string.Empty;
        private IXuLyHoaDonBanHang _xuLyLoaiSanPham = new XuLyHoaDonBanHang();
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
                var hdbh = new HoaDonBanHang(sanPham.MaSanPham,sanPham.TenSanPham,sanPham.Gia,TenNguoiMua,SoLuongMua,ThanhTien);//put any num here to distinc LoaiSanPham constructor
                _xuLyLoaiSanPham.ThemHoaDon(hdbh);
                Response.Redirect("MH_DanhSach_HoaDonBanHang");
            }
            catch (Exception ex)
            {
                DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
                Chuoi = ex.Message;
            }
        }
    }
}
