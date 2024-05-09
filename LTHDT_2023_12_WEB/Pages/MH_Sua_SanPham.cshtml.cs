using LTHDT_2023_12_Services;
using LTHDT_2023_12_Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTHDT_2023_12_WEB.Pages
{
    public class MH_Sua_SanPhamModel : PageModel
    {
        [BindProperty]
        public int maSanPham { get; set; }
        [BindProperty]
        public string tenSanPham { get; set; }
        [BindProperty]
        public string TuKhoa2 { get; set; }
        [BindProperty]
        public int giaSanPham { get; set; }
        [BindProperty]
        public int HanSuDung { get; set; }
        [BindProperty]
        public string CongTySanXuat { get; set; }
        [BindProperty]
        public int NamSanXuat { get; set; }
        [BindProperty]
        public string LoaiSanPham { get; set; }
        [BindProperty]
        public int SoLuong { get; set; }

        public string Chuoi { get; set; } = string.Empty;
        public int found { get; set; } = 0;


        private IXuLySanPham _xuLySanPham = new XuLySanPham();
        private IXuLyLoaiSanPham _xuLyLoaiSanPham = new XuLyLoaiSanPham();
        public List<SanPham> DanhSachSanPham;
        public List<LoaiSanPham> DanhSachLoaiSanPham;

        public void OnGet(int maSanPhamInput, string TuKhoa)
        {
            maSanPham = maSanPhamInput;
            DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham(TuKhoa);
            //SanPham sanPham = DanhSachSanPham.FirstOrDefault(sp => sp.MaSanPham == maSanPham);
            tenSanPham = TuKhoa;
            giaSanPham = DanhSachSanPham[0].Gia;
            HanSuDung = DanhSachSanPham[0].HanSuDung;
            CongTySanXuat = DanhSachSanPham[0].CongTySanXuat;
            NamSanXuat = DanhSachSanPham[0].NamSanXuat;
            LoaiSanPham = DanhSachSanPham[0].LoaiSanPham;
            SoLuong = DanhSachSanPham[0].SoLuong;

            DanhSachLoaiSanPham = _xuLyLoaiSanPham.DocDanhSachLoaiSanPham();
            //if (TempData.TryGetValue("tenSanPham", out object tempTenSanPham))
            //{
            //    tenSanPham = (string)tempTenSanPham;
            //}
            //if (TempData.TryGetValue("giaSanPham", out object tempGiaSanPham))
            //{
            //    giaSanPham = (int)tempGiaSanPham;
            //}
        }

        public void OnPost()
        {
            DanhSachLoaiSanPham = _xuLyLoaiSanPham.DocDanhSachLoaiSanPham();
            try
            {
                SanPham sanPham = new SanPham(maSanPham, tenSanPham, giaSanPham, HanSuDung, CongTySanXuat, NamSanXuat, LoaiSanPham, SoLuong);
                _xuLySanPham.SuaSanPham(sanPham);
            }
            catch (Exception ex)
            {
                //TempData["tenSanPham"] = tenSanPham;
                //TempData["giaSanPham"] = giaSanPham;
                Chuoi = ex.Message;
            }
            if (string.IsNullOrEmpty(Chuoi))
            {
                Response.Redirect("/MH_DanhSach_SanPham");
            }
        }
    }
}
