using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OfficeOpenXml;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {// Đường dẫn tới template file Excel
            string templateFilePath = "template.xlsx";

            // Kiểm tra xem file template có tồn tại không
            if (File.Exists(templateFilePath))
            {
                // Hiển thị hộp thoại SaveFileDialog để người dùng chọn vị trí lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.FileName = "output.xlsx";
                bool? result = saveFileDialog.ShowDialog();

                // Nếu người dùng chọn vị trí lưu file và bấm OK
                if (result == true)
                {
                    string outputFilePath = saveFileDialog.FileName;

                    // Sao chép template file Excel vào file output
                    File.Copy(templateFilePath, outputFilePath, true);

                    // Mở file output để chỉnh sửa
                    using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(outputFilePath)))
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Sheet1"];

                        // Thực hiện chỉnh sửa dữ liệu trong worksheet
                        worksheet.Cells["A1"].Value = "Hello";
                        worksheet.Cells["B1"].Value = "World";
                        // Lưu file output
                        excelPackage.Save();
                    }

                    MessageBox.Show("File Excel đã được xuất thành công.");
                }
            }
            else
            {
                MessageBox.Show("File template không tồn tại.");
            }
        }
    }
}
