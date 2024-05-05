using LTHDT_2023_12_Entities;

namespace LTHDT_2023_12_Repo
{
    public class LuuTruSanPham :ILuuTruSanPham
    {
        private string _filePath = "E:\\dssp.txt";//thêm đường dẫn vào
        public List<SanPham> DocDanhSachSanPham()
        {
            List<SanPham> dsSanPham = new List<SanPham>();
            StreamReader file = new StreamReader(_filePath);
            //dòng đầu tiên là số lượng
            int n;
            //string s = file.ReadLine();
            string s = file.ReadLine();
            n = int.Parse(s);
            for (int i = 0; i < n; i++)
            {
                s = file.ReadLine();
                dsSanPham.Add(new SanPham(s));
            }

            file.Close();
            return dsSanPham;
        }

        public List<SanPham> LuuDanhSachSanPham(List<SanPham> dsSanPham)
        {
            StreamWriter file = new StreamWriter(_filePath);
            file.WriteLine(dsSanPham.Count);
            foreach (var sp in dsSanPham)
            {
                file.WriteLine($"{sp.MaSanPham},{sp.TenSanPham},{sp.Gia},{sp.HanSuDung},{sp.CongTySanXuat},{sp.NamSanXuat},{sp.LoaiSanPham}");
            }

            file.Close();
            return dsSanPham;
        }
        public void ThemSanPham(SanPham sanPham)
        {
            var dssp = DocDanhSachSanPham();
            dssp.Add(sanPham);
            LuuDanhSachSanPham(dssp);
        }

        public void XoaSanPham(int maSanPham)
        {
            var dssp = DocDanhSachSanPham();
            var sanPham = dssp.FirstOrDefault(sp => sp.MaSanPham == maSanPham);
            if (sanPham != null)
            {
                dssp.Remove(sanPham);
                LuuDanhSachSanPham(dssp);
            }
        }

        public void SuaSanPham(SanPham sanPhamInput)
        {
            var dssp = DocDanhSachSanPham();
            int maSanPham = sanPhamInput.MaSanPham;
            var sanPham = dssp.FirstOrDefault(sp => sp.MaSanPham == maSanPham);
            if (sanPham != null)
            {
                sanPham.CopyFrom(sanPhamInput);

                LuuDanhSachSanPham(dssp);
            }
        }
    }
}