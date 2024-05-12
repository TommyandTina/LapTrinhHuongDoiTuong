namespace LTHDT_2023_12_Entities
{
    public class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int Gia { get; set; }
        public string HanSuDung { get; set; }
        public string CongTySanXuat { get; set; }
        public int NamSanXuat { get; set; }
        public string LoaiSanPham { get; set; }
        public int SoLuong { get; set; }
        public SanPham()
        {
        }
        public SanPham(string s)
        {
            string[] m = s.Split(',');
            MaSanPham = int.Parse(m[0]);
            TenSanPham = m[1];
            Gia = int.Parse(m[2]);
            HanSuDung = m[3];
            CongTySanXuat = m[4];
            NamSanXuat = int.Parse(m[5]);
            LoaiSanPham = m[6];
            SoLuong = int.Parse(m[7]);
        }

        public SanPham(string tenSanPham, int gia, string hanSuDung, string congTySanXuat, int namSanXuat, string loaiSanPham)
        {
            if (string.IsNullOrEmpty(tenSanPham))
            {
                throw new Exception("Ten khong hop le");
            }
            if (gia <= 0)
            {
                throw new Exception("Gia khong hop le");
            }
            if (string.IsNullOrEmpty(hanSuDung))
            {
                throw new Exception("Dan su dung khong hop le");
            }
            if (string.IsNullOrEmpty(congTySanXuat))
            {
                throw new Exception("Cong ty san xuat khong hop le");
            }
            if (namSanXuat <= 0)
            {
                throw new Exception("nam san xuat khong hop le");
            }
            if (string.IsNullOrEmpty(loaiSanPham))
            {
                throw new Exception("loai san pham khong hop le");
            }

            TenSanPham = tenSanPham;
            Gia = gia;
            HanSuDung = hanSuDung;
            CongTySanXuat = congTySanXuat;
            NamSanXuat = namSanXuat;
            LoaiSanPham = loaiSanPham;
        }


        public SanPham(int maSanPham,string tenSanPham, int gia, string hanSuDung, string congTySanXuat, int namSanXuat, string loaiSanPham, int soLuong)
        {
            if(maSanPham <= 0)
            {
                throw new Exception("Ma san pham khong hop le");
            }
            if (string.IsNullOrEmpty(tenSanPham))
            {
                throw new Exception("Ten khong hop le");
            }
            if (gia <= 0)
            {
                throw new Exception("Gia khong hop le");
            }
            if (string.IsNullOrEmpty(hanSuDung))
            {
                throw new Exception("Dan su dung khong hop le");
            }
            if (string.IsNullOrEmpty(congTySanXuat))
            {
                throw new Exception("Cong ty san xuat khong hop le");
            }
            if (namSanXuat <= 0)
            {
                throw new Exception("nam san xuat khong hop le");
            }
            if (string.IsNullOrEmpty(loaiSanPham))
            {
                throw new Exception("loai san pham khong hop le");
            }
            if (soLuong < 0)
            {
                throw new Exception("so luong khong hop le");
            }
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            Gia = gia;
            HanSuDung = hanSuDung;
            CongTySanXuat = congTySanXuat;
            NamSanXuat = namSanXuat;
            LoaiSanPham = loaiSanPham;
            SoLuong = soLuong;
        }

        public void CopyFrom(SanPham other)
        {
            MaSanPham = other.MaSanPham;
            TenSanPham = other.TenSanPham;
            Gia = other.Gia;
            HanSuDung = other.HanSuDung;
            CongTySanXuat = other.CongTySanXuat;
            NamSanXuat = other.NamSanXuat;
            LoaiSanPham = other.LoaiSanPham;
            SoLuong = other.SoLuong;
        }
    }
}