using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTHDT_2023_12_WEB.Pages.Pages_HoaDonBanHang
{
    public class MH_SuaHoaDonBanHangModel : PageModel
    {
        [BindProperty]
        public int maHoaDon { get; set; }
        [BindProperty]
        public string TenNguoiMua { get; set; }
        [BindProperty]
        public SanPham sanPham { get; set; }
        [BindProperty]
        public int SoLuongMua { get; set; }
        [BindProperty]
        public int ThanhTien { get; set; }

        public string Chuoi { get; set; } = string.Empty;
        public int found { get; set; } = 0;

        private IXuLyHoaDonBanHang _xuLyHoaDonBanHang = new XuLyHoaDonBanHang();
        public List<HoaDonBanHang> DanhSachHoaDonBanHang;


        public void OnGet(int maHoaDonInput)
        {
            maHoaDon = maHoaDonInput;
            sanPham = new SanPham();
            DanhSachHoaDonBanHang = _xuLyHoaDonBanHang.DocDanhSachHoaDon(maHoaDon);
            TenNguoiMua = DanhSachHoaDonBanHang[0].TenNguoiMua;
            SoLuongMua = DanhSachHoaDonBanHang[0].SoLuongMua;
            ThanhTien = DanhSachHoaDonBanHang[0].ThanhTien;
            sanPham.MaSanPham = DanhSachHoaDonBanHang[0].sanPham.MaSanPham;
            sanPham.TenSanPham = DanhSachHoaDonBanHang[0].sanPham.TenSanPham;
            sanPham.Gia = DanhSachHoaDonBanHang[0].sanPham.Gia;
        }

        public void OnPost()
        {

            try
            {
                HoaDonBanHang hoaDon = new HoaDonBanHang(maHoaDon, sanPham.MaSanPham, sanPham.TenSanPham, sanPham.Gia, TenNguoiMua, SoLuongMua,ThanhTien);
                _xuLyHoaDonBanHang.SuaHoaDon(hoaDon);
            }
            catch (Exception ex)
            {
                Chuoi = ex.Message;
            }
            if (string.IsNullOrEmpty(Chuoi))
            {
                Response.Redirect("MH_DanhSach_HoaDonBanHang");
            }
        }
    }
}
