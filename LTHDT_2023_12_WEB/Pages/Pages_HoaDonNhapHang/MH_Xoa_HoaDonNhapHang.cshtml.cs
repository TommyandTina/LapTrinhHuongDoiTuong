using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;

namespace LTHDT_2023_12_WEB.Pages.Pages_HoaDonNhapHang
{
    public class MH_Xoa_HoaDonNhapHangModel : PageModel
    {
        [BindProperty]
        public int maHoaDon { get; set; }

        public string Chuoi { get; set; } = string.Empty;
        public int found { get; set; } = 0;

        private IXuLyHoaDonNhapHang _xuLyHoaDonNhapHang = new XuLyHoaDonNhapHang();
        public List<HoaDonNhapHang> DanhSachHoaDonNhapHang;

        public void OnGet(int maHoaDonInput)
        {
            maHoaDon = maHoaDonInput;
            DanhSachHoaDonNhapHang = _xuLyHoaDonNhapHang.DocDanhSachHoaDon(maHoaDon);
        }

        public void OnPost()
        {
            found = _xuLyHoaDonNhapHang.XoaHoaDon(maHoaDon);
            if (found == 1)
            {
                Response.Redirect("MH_DanhSach_HoaDonNhapHang");
            }
            if (found == -1)
            {
                Chuoi = "Vui long nhap lai ma san pham de xoa";
            }
        }
    }
}
