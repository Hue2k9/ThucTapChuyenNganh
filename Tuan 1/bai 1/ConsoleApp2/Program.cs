namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap ho ten: ");
            string hoTen = Console.ReadLine();

            Console.Write("Nhap diem: ");
            double diem = double.Parse(Console.ReadLine());

            string xepLoai = "";
            if (diem >= 8)
            {
                xepLoai = "GIOI";
            }
            else if (diem >= 6.5)
            {
                xepLoai = "KHA";
            }
            else if (diem >= 5)
            {
                xepLoai = "TRUNG BINH";
            }
            else
            {
                xepLoai = "YEU";
            }

            Console.WriteLine("Ho ten: " + hoTen.ToUpper());
            Console.WriteLine("Xep loai: " + xepLoai);
        }
    }
}