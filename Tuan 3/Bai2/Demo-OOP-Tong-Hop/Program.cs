using System;
using System.Collections.Generic;

namespace Demo_OOP_Tong_Hop
{
    class Program
    {
       static List<KhachHang> dsKhachHang = new List<KhachHang>();
        static void Main(string[] args)
        {
            string luaChon = "";
            do
            {
                Console.WriteLine("\nMAIN MENU: ");
                Console.WriteLine("\n1. Nhap thong tin");
                Console.WriteLine("\n2. Hien thi danh sach khach hang");
                Console.WriteLine("\n3. Sua thong tin khach hang"); 
                Console.WriteLine("\n4. Xoa khach hang");
                Console.WriteLine("\n5. Tim khach hang");
                Console.WriteLine("\n6. Sap xep");
                Console.WriteLine("\n7. Thoat");
                Console.Write("\nNhap vao lua chon cua ban: ");
                luaChon = Console.ReadLine();
                switch (luaChon)
                {
                    case "1":
                        ThemKhachHangMoi();
                        break;
                    case "2":
                        HienThiDanhSach();
                        break;
                    case "3":
                        Console.WriteLine("Sua");
                        break;
                    case "4":
                        Console.WriteLine("Xoa");
                        break;
                    case "5":
                        Console.WriteLine("Tim");
                        break;
                    case "6":
                        Console.WriteLine("Sap xep");
                        break;
                    case "7":
                        break;
                    default:
                        Console.WriteLine("Nhap sai, moi nhap lai");
                        break;
                }
                //Console.ReadLine();
                //Console.Clear();
            } while (luaChon!="7");

            Console.ReadLine();            
        }

        private static void HienThiDanhSach()
        {
            Console.WriteLine("\nDanh sach da nhap: ");
            foreach (var item in dsKhachHang)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void ThemKhachHangMoi()
        {
            Console.WriteLine("\nMenu con: ");
            Console.WriteLine("\n1. Khach hang");
            Console.WriteLine("\n2. Khach hang than thiet");
            Console.WriteLine("\nChon loai khach hang: ");
            string loaiKH = Console.ReadLine();
            switch (loaiKH)
            {
                case "1":
                    Console.WriteLine("Nhap ho ten khach hang: ");
                    string hoTen = Console.ReadLine();
                    Console.WriteLine("Nhap gioi tinh: ");
                    bool gioiTinh = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap don gia: ");
                    int donGia = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap so luong mua: ");
                    int soLuong = int.Parse(Console.ReadLine());
                    KhachHang kh1 = new KhachHang(hoTen, gioiTinh, soLuong, donGia);
                    dsKhachHang.Add(kh1);
                    break;
                case "2":
                    Console.WriteLine("Nhap ho ten khach hang: ");
                    string hoTentt = Console.ReadLine();
                    Console.WriteLine("Nhap gioi tinh: ");
                    bool gioiTinhtt = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap don gia: ");
                    int donGiatt = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap so luong mua: ");
                    int soLuongtt = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap ma the thanh vien: ");
                    int mathett = int.Parse(Console.ReadLine());
                    KhachHangThanThiet khtt1 = new KhachHangThanThiet(hoTentt, gioiTinhtt,
                        soLuongtt, donGiatt, mathett);
                    dsKhachHang.Add(khtt1);
                   
                    break;
                default:
                    break;
            }

            
        }
    }
}
