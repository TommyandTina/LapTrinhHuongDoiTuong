using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTHDT_2023_12_WEB.Pages
{
    public class MH_Xoa_SanPhamModel : PageModel
    {
        [BindProperty]
        public int maSanPham { get; set; }

        public string Chuoi { get; set; } = string.Empty;
        public int found { get; set; } = 0;

        private IXuLySanPham _xuLySanPham = new XuLySanPham();
        
        public List<SanPham> DanhSachSanPham;

        public void OnGet(int maSanPhamInput, string TuKhoa)
        {
            maSanPham = maSanPhamInput;
            DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham(TuKhoa);
        }

        public void OnPost()
        {
            found = _xuLySanPham.XoaSanPham(maSanPham);
            if(found == 1)
            {
                Response.Redirect("/MH_DanhSach_SanPham");
            }
            if (found == -1)
            {
                Chuoi = "Vui long nhap lai ma san pham de xoa";
            }
        }
    }
}
