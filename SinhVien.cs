using System;

namespace Quang
{
    internal class SinhVien
    {
        int maSo;
        string hoTen;
        int namSinh;
        string gioiTinh;
        string chuyenNganh;
        string tenKhoa;

        public SinhVien() { }

        public SinhVien(int maSo, string hoTen, int namSinh, string gioiTinh, string chuyenNganh, string tenKhoa)
        {
            this.maSo = maSo;
            this.hoTen = hoTen;
            this.namSinh = namSinh;
            this.gioiTinh = gioiTinh;
            this.chuyenNganh = chuyenNganh;
            this.tenKhoa = tenKhoa;
        }

        public int MaSo { get => maSo; set => maSo = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public int NamSinh { get => namSinh; set => namSinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string ChuyenNganh { get => chuyenNganh; set => chuyenNganh = value; }
        public string TenKhoa { get => tenKhoa; set => tenKhoa = value; }

        public void Nhap()
        {
            Console.WriteLine("Mời nhập mã số: ");
            MaSo = int.Parse(Console.ReadLine());
            Console.WriteLine("Mời nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.WriteLine("Mời nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
            Console.WriteLine("Mời nhập giới tính: ");
            GioiTinh = Console.ReadLine();
            Console.WriteLine("Mời nhập chuyên ngành: ");
            ChuyenNganh = Console.ReadLine();
            Console.WriteLine("Mời nhập tên khoa: ");
            TenKhoa = Console.ReadLine();
        }

        public void Xuat()
        {
            Console.WriteLine($"Mã số: {MaSo}");
            Console.WriteLine($"Họ tên: {HoTen}");
            Console.WriteLine($"Năm sinh: {NamSinh}");
            Console.WriteLine($"Giới tính: {GioiTinh}");
            Console.WriteLine($"Chuyên ngành: {ChuyenNganh}");
            Console.WriteLine($"Khoa: {TenKhoa}");
        }
    }
}
