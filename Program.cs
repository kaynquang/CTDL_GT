using System;
using System.Text;

namespace Quang
{
    internal class Program
    {
        static ListSV danhSachSV = new ListSV();


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            int choice;
            do
            {
                Console.Clear();
                DrawMenu();

                try
                {
                    Console.Write("Chọn chức năng: ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            NhapSinhVien();
                            break;
                        case 2:
                            XuatDanhSach();
                            break;
                        case 3:
                            danhSachSV.SortByMaSo();
                            Console.WriteLine("Danh sách đã được sắp xếp.");
                            break;
                        case 4:
                            XoaSinhVien();
                            break;
                        case 5:
                            ThemSinhVien();
                            break;
                        case 6:
                            TachSinhVienTheoGioiTinh();
                            break;
                        case 0:
                            Console.WriteLine("Kết thúc chương trình.");
                            break;
                        default:
                            Console.WriteLine("Chọn sai, mời chọn lại.");
                            break;
                    }
                }
                catch (FormatException)  // Bắt lỗi nếu người dùng nhập chuỗi thay vì số
                {
                    Console.WriteLine("Vui lòng nhập một số hợp lệ!");
                    choice = -1;  // Đặt choice về giá trị không hợp lệ để không thoát chương trình
                }

                if (choice != 0)
                {
                    Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }

            } while (choice != 0);
        }

        static void DrawMenu()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("||     QUẢN LÝ SINH VIÊN HUFLIT      ||");
            Console.WriteLine("=====================================");
            Console.WriteLine("|| 1. Nhập sinh viên                 ||");
            Console.WriteLine("|| 2. Xuất danh sách sinh viên       ||");
            Console.WriteLine("|| 3. Sắp xếp danh sách theo mã số   ||");
            Console.WriteLine("|| 4. Xóa sinh viên theo mã số       ||");
            Console.WriteLine("|| 5. Thêm sinh viên vào danh sách   ||");
            Console.WriteLine("|| 6. Tách sinh viên theo giới tính  ||");
            Console.WriteLine("|| 0. Thoát                          ||");
            Console.WriteLine("=====================================");
        }

        static void NhapSinhVien()
        {
            SinhVien sv = new SinhVien();
            sv.Nhap();
            if (danhSachSV.SearchX(sv.MaSo) == null)
            {
                NodeSV newNode = new NodeSV(sv);
                danhSachSV.AddAsc(newNode);
                Console.WriteLine("Đã thêm sinh viên vào danh sách.");
            }
            else
            {
                Console.WriteLine("Mã số sinh viên đã tồn tại. Nhập lại.");
            }
        }

        static void XuatDanhSach()
        {
            if (!danhSachSV.IsEmpty())
            {
                NodeSV current = danhSachSV.First;
                while (current != null)
                {
                    current.Data.Xuat();
                    current = current.Next;
                }
            }
            else
            {
                Console.WriteLine("Danh sách sinh viên rỗng.");
            }
        }

        static void XoaSinhVien()
        {
            Console.Write("Nhập mã số sinh viên cần xóa: ");
            int maSo = int.Parse(Console.ReadLine());
            if (danhSachSV.RemoveByMaSo(maSo))
            {
                Console.WriteLine("Đã xóa sinh viên.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên với mã số này.");
            }
        }

        static void ThemSinhVien()
        {
            char tiepTucNhap;

            do
            {
                SinhVien sv = new SinhVien();
                sv.Nhap();

                if (danhSachSV.SearchX(sv.MaSo) == null)
                {
                    NodeSV newNode = new NodeSV(sv);
                    danhSachSV.AddAsc(newNode);
                    Console.WriteLine("Đã thêm sinh viên vào danh sách.");
                }
                else
                {
                    Console.WriteLine("Mã số sinh viên đã tồn tại. Nhập lại.");
                }

                Console.Write("Bạn có muốn nhập thêm sinh viên không? (y/n): ");
                tiepTucNhap = Console.ReadLine().ToLower()[0]; 

            } while (tiepTucNhap == 'y');

            Console.WriteLine("Hoàn thành thêm sinh viên.");
        }


        static void TachSinhVienTheoGioiTinh()
        {
            ListSV danhSachNam = new ListSV();
            ListSV danhSachNu = new ListSV();

            NodeSV current = danhSachSV.First;
            while (current != null)
            {
                if (current.Data.GioiTinh == "Nam")
                {
                    danhSachNam.AddAsc(new NodeSV(current.Data));
                }
                else if (current.Data.GioiTinh == "Nữ")
                {
                    danhSachNu.AddAsc(new NodeSV(current.Data));
                }
                current = current.Next;
            }

            Console.WriteLine("Danh sách sinh viên nam:");
            NodeSV currentNam = danhSachNam.First;
            while (currentNam != null)
            {
                currentNam.Data.Xuat();
                currentNam = currentNam.Next;
            }

            Console.WriteLine("Danh sách sinh viên nữ:");
            NodeSV currentNu = danhSachNu.First;
            while (currentNu != null)
            {
                currentNu.Data.Xuat();
                currentNu = currentNu.Next;
            }
        }
    }
}
