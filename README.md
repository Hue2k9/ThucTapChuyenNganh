## Thực tập chuyên ngành - Nhóm 8- Ngôn ngữ: C#
### Các thành viên:
- Hoàng Minh Huệ
- Nguyễn Thị Thủy
- Nguyễn Thị Huyền Trang
- Hồ Ngọc Tuấn
## Hướng dẫn cài đặt và chạy dự án

### 1. Tải mã nguồn chương trình

Mở terminal và gõ lệnh sau để tải mã nguồn từ kho lưu trữ GitHub:
~~~js
 git clone https://github.com/Hue2k9/ThucTapChuyenNganh.git
~~~

### 2. Tạo cơ sở dữ liệu

1. Truy cập vào thư mục `BTL_ThucTapChuyenNganh` sau đó truy cập vào thư mục `data`.
2. Mở Microsoft SQL Server và chạy file `SQLQuery1.sql` để tạo cơ sở dữ liệu.

### 3. Cài đặt thư viện

Dưới đây là các thư viện mà dự án phụ thuộc. Để cài đặt, làm theo các bước sau:

1. Nhấp phải chuột vào project trong cửa sổ Solution Explorer và chọn "Manage Nuget Packages".
2. Trong giao diện trình quản lý gói NuGet, chọn tab "Browse".
3. Tìm và cài đặt các gói sau:

   - Microsoft.EntityFrameworkCore.SqlServer
   - Microsoft.EntityFrameworkCore.Tools
   - EEPlus
   - MahApps.Metro
   - Ookii.Dialogs.Wpf

### 4. Kết nối cơ sở dữ liệu

1. Chọn menu "Tools" -> "NuGet Package Manager" -> "Package Manager Console".
2. Trong cửa sổ "Package Manager Console", thực hiện lệnh sau để tạo lớp đối tượng từ cơ sở dữ liệu:
Scaffold-DbContext "Data Source= DESKTOP-MTPECJO\MAYAO;Initial Catalog=ThucTapChuyenNganh;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer –OutputDir Models
~~~js
Scaffold-DbContext "Data Source= DESKTOP-MTPECJO\MAYAO;Initial Catalog=ThucTapChuyenNganh;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer –OutputDir Models
~~~
### Thanks for reading!
