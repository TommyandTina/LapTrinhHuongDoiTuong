using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;

namespace LTHDT_2023_12_WEB.Pages.Pages_HoaDonBanHang
{
    public class MH_Xoa_HoaDonBanHangModel : PageModel
    {
        [BindProperty]
        public int maHoaDon { get; set; }

        public string Chuoi { get; set; } = string.Empty;
        public int found { get; set; } = 0;

        private IXuLyHoaDonBanHang _xuLyHoaDonBanHang = new XuLyHoaDonBanHang();
        public List<HoaDonBanHang> DanhSachHoaDonBanHang;
        private IXuLySanPham _xuLySanPham = new XuLySanPham();
        public void OnGet(int maHoaDonInput)
        {
            maHoaDon = maHoaDonInput;
            DanhSachHoaDonBanHang = _xuLyHoaDonBanHang.DocDanhSachHoaDon(maHoaDon);
        }

        public void OnPost()
        {
            try
            {
                HoaDonBanHang getHoaDonCu = _xuLyHoaDonBanHang.DocDanhSachHoaDon(maHoaDon)[0];
                _xuLySanPham.CapNhatSoLuongSanPham(getHoaDonCu.sanPham.MaSanPham, getHoaDonCu.SoLuongMua);
                found = _xuLyHoaDonBanHang.XoaHoaDon(maHoaDon);
                if (found == 1)
                {
                    Response.Redirect("MH_DanhSach_HoaDonBanHang");
                }
                if (found == -1)
                {
                    Chuoi = "Vui long nhap lai ma san pham de xoa";
                }
            }
            catch (Exception ex)
            {
                Chuoi = ex.Message;
            }
        }
    }
}
