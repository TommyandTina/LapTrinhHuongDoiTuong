using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTHDT_2023_12_WEB.Pages.Pages_HoaDonNhapHang
{
    public class MH_SuaHoaDonNhapHangModel : PageModel
    {
        [BindProperty]
        public int maHoaDon { get; set; }
        [BindProperty]
        public string TenCongTyBan { get; set; }
        [BindProperty]
        public SanPham sanPham { get; set; }
        [BindProperty]
        public int SoLuongNhap { get; set; }
        [BindProperty]
        public int ThanhTien { get; set; }

        public string Chuoi { get; set; } = string.Empty;
        public int found { get; set; } = 0;

        private IXuLyHoaDonNhapHang _xuLyHoaDonNhapHang = new XuLyHoaDonNhapHang();
        public List<HoaDonNhapHang> DanhSachHoaDonNhapHang;


        public void OnGet(int maHoaDonInput)
        {
            maHoaDon = maHoaDonInput;
            sanPham = new SanPham();
            DanhSachHoaDonNhapHang = _xuLyHoaDonNhapHang.DocDanhSachHoaDon(maHoaDon);
            TenCongTyBan = DanhSachHoaDonNhapHang[0].TenCongTyBan;
            SoLuongNhap = DanhSachHoaDonNhapHang[0].SoLuongNhap;
            ThanhTien = DanhSachHoaDonNhapHang[0].ThanhTien;
            sanPham.MaSanPham = DanhSachHoaDonNhapHang[0].sanPham.MaSanPham;
            sanPham.TenSanPham = DanhSachHoaDonNhapHang[0].sanPham.TenSanPham;
            sanPham.Gia = DanhSachHoaDonNhapHang[0].sanPham.Gia;
        }

        public void OnPost()
        {

            try
            {
                HoaDonNhapHang hoaDon = new HoaDonNhapHang(maHoaDon, sanPham.MaSanPham, sanPham.TenSanPham, sanPham.Gia, TenCongTyBan, SoLuongNhap,ThanhTien);
                _xuLyHoaDonNhapHang.SuaHoaDon(hoaDon);
            }
            catch (Exception ex)
            {
                Chuoi = ex.Message;
            }
            if (string.IsNullOrEmpty(Chuoi))
            {
                Response.Redirect("MH_DanhSach_HoaDonNhapHang");
            }
        }
    }
}
