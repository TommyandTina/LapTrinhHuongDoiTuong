namespace LTHDT_2023_12_Entities
{
    public class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int Gia { get; set; }
        public SanPham(string s)
        {
            string[] m = s.Split(',');
            MaSanPham = int.Parse(m[0]);
            TenSanPham = m[1];
            Gia = int.Parse(m[2]);
        }

        public SanPham(string tenSanPham, int gia)
        {
            if(string.IsNullOrEmpty(tenSanPham))
            {
                throw new Exception("Ten khong hop le");
            }
            if(gia <= 0)
            {
                throw new Exception("Gia khong hop le");
            }
            TenSanPham = tenSanPham;
            Gia = gia;
        }
    }
}