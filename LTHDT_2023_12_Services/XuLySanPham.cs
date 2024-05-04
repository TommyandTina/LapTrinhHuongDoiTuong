using LTHDT_2023_12_Entities;
using LTHDT_2023_12_Repo;

namespace LTHDT_2023_12_Services
{
    
    public class XuLySanPham :IXuLySanPham
    {
        private ILuuTruSanPham _luuTruSanPham = new LuuTruSanPham();
        public List<SanPham> DocDanhSachSanPham(string tukhoa = "")
        {
            List<SanPham> kq = new List<SanPham>();
            var dssp  = _luuTruSanPham.DocDanhSachSanPham();
            //Search danhsachsanpham
            foreach (var sp in dssp)
            {
                if (sp.TenSanPham.Contains(tukhoa))
                {
                    kq.Add(sp);
                }
            }
            return kq;
        }

        public void ThemSanPham(SanPham sanPham)
        {
            var dssp = _luuTruSanPham.DocDanhSachSanPham();
            int maxId = 0;
            foreach (var sp in dssp)
            {
                if(sp.MaSanPham>maxId)
                {
                    maxId = sp.MaSanPham;
                }
            }
            sanPham.MaSanPham = maxId + 1;
            _luuTruSanPham.ThemSanPham(sanPham);
        }

        public int XoaSanPham(int maSanPham)
        {
            var dssp = _luuTruSanPham.DocDanhSachSanPham();
            foreach (var sp in dssp)
            {
                if(sp.MaSanPham == maSanPham)
                {
                    _luuTruSanPham.XoaSanPham(maSanPham);
                    return 1;
                }
            }
            return -1;
        }

        public void SuaSanPham(SanPham sanPham)
        {
            int maSanPham = sanPham.MaSanPham;
            _luuTruSanPham.SuaSanPham(sanPham);
        }
    }
}