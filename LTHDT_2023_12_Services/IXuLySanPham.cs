using LTHDT_2023_12_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHDT_2023_12_Services
{
    public interface IXuLySanPham
    {
        //bắt buộc trả về list sản phẩm khi sd interface này
        List<SanPham> DocDanhSachSanPham(string tuKhoa = "");
        void ThemSanPham(SanPham sanPham);
        int XoaSanPham(int maSanPham);
        void SuaSanPham(SanPham sanPham);
    }
}
