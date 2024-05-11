using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;

namespace LTHDT_2023_12_WEB.Pages.Pages_HoaDonNhapHang
{
    public class MH_DanhSach_HoaDonNhapHangModel : PageModel
    {
        private IXuLyHoaDonNhapHang _xuLyHoaDonNhapHang = new XuLyHoaDonNhapHang();
        public List<HoaDonNhapHang> DanhSachHoaDonNhapHang;
        public string Chuoi { get; set; } = string.Empty;
        [BindProperty]
        public int maHoaDon { get; set; }
        public void OnGet()
        {
            DanhSachHoaDonNhapHang = _xuLyHoaDonNhapHang.DocDanhSachHoaDon();
        }

        public void OnPost()
        {

            if (maHoaDon <= 0)
            {
                Chuoi = "Vui long nhap lai Tu Khoa";
                DanhSachHoaDonNhapHang = _xuLyHoaDonNhapHang.DocDanhSachHoaDon();
                return;
            }
            //Due to having BindProperty so TuKhoa is automatically added into here
            DanhSachHoaDonNhapHang = _xuLyHoaDonNhapHang.DocDanhSachHoaDon(maHoaDon);
        }
    }
}
