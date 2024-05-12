using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTHDT_2023_12_WEB.Pages.Pages_ThongKe
{
    public class ThongKeSoLuongSanPhamHetHanModel : PageModel
    {
        private IXuLySanPham _xuLySanPham = new XuLySanPham();
        public List<SanPham> DanhSachSanPham;
        public List<SanPham> DanhSachSanPhamQuaHan;
        public string Chuoi { get; set; } = string.Empty;
        [BindProperty]
        public string TuKhoa { get; set; }
        public void OnGet()
        {
            DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
            DanhSachSanPhamQuaHan = new List<SanPham>();
            foreach (SanPham sp in DanhSachSanPham)
            {
                if (_xuLySanPham.SoSanh_Date_vs_Today(sp.HanSuDung))
                {
                    DanhSachSanPhamQuaHan.Add(sp);
                }
            }
        }

        public void OnPost()
        {

            if (string.IsNullOrEmpty(TuKhoa))
            {
                Chuoi = "Vui long nhap lai Tu Khoa";
                DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
                DanhSachSanPhamQuaHan = new List<SanPham>();
                foreach (SanPham sp in DanhSachSanPham)
                {
                    if (_xuLySanPham.SoSanh_Date_vs_Today(sp.HanSuDung))
                    {
                        DanhSachSanPhamQuaHan.Add(sp);
                    }
                }
                return;
            }
            //Due to having BindProperty so TuKhoa is automatically added into here
            DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham(TuKhoa);
            DanhSachSanPhamQuaHan = new List<SanPham>();
            foreach (SanPham sp in DanhSachSanPham)
            {
                if (_xuLySanPham.SoSanh_Date_vs_Today(sp.HanSuDung))
                {
                    DanhSachSanPhamQuaHan.Add(sp);
                }
            }
        }
    }
}
