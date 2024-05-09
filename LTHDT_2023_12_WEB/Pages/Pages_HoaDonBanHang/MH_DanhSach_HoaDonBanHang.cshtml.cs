using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;

namespace LTHDT_2023_12_WEB.Pages.Pages_HoaDonBanHang
{
    public class MH_DanhSach_HoaDonBanHangModel : PageModel
    {
        private IXuLyHoaDonBanHang _xuLyHoaDonBanHang = new XuLyHoaDonBanHang();
        public List<HoaDonBanHang> DanhSachHoaDonBanHang;
        public string Chuoi { get; set; } = string.Empty;
        [BindProperty]
        public int maHoaDon { get; set; }
        public void OnGet()
        {
            DanhSachHoaDonBanHang = _xuLyHoaDonBanHang.DocDanhSachHoaDon();
        }

        public void OnPost()
        {

            if (maHoaDon <= 0)
            {
                Chuoi = "Vui long nhap lai Tu Khoa";
                DanhSachHoaDonBanHang = _xuLyHoaDonBanHang.DocDanhSachHoaDon();
                return;
            }
            //Due to having BindProperty so TuKhoa is automatically added into here
            DanhSachHoaDonBanHang = _xuLyHoaDonBanHang.DocDanhSachHoaDon(maHoaDon);
        }
    }
}
