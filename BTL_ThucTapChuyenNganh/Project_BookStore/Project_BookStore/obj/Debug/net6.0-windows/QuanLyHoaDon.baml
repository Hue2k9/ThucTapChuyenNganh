   M S B A M L   `   `   `  ����L  HProject_BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_BookStoreProject_BookStore  5   	   $    Project_BookStore.QuanLyHoaDon   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Project_BookStore     5   	     � Title$  QuanLyHoaDon��5   	   $	��450��6   $	��800��6+   ���#EEEEEE.��5	      � -   5        .+�5
   
   �� $��	Họ tên��6   $
��Left=�6!   $��	37,47,0,0q�6<   $	��Top=�6O   �� 5   
   $��Số điện thoại��6   $
��Left=�6(   $��	37,89,0,0q�6C   $	��Top=�6V   �� 5   
   $��Địa chỉ��6   $
��Left=�6"   $��
37,127,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5         ��Name$ txtHoTen��5      $
��Left=�6$   $��
129,51,0,0q�6?    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��120��6   �� 5   
   -   5        $ txtSoDienThoai��5      $
��Left=�6*   $��
129,89,0,0q�6E   $
 Wrap=�6Y   $	��Top=�6m   $	��120��6�   �� 5   
   -   5        $ 	txtDiaChi��5      $
��Left=�6%   $��129,131,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��120��6�   �� 5   
   $��Tên sản phẩm��6   $
��Left=�6'   $��
321,47,0,0q�6B   $	��Top=�6V   �� 5   
   $��Số lượng��6   $
��Left=�6#   $��
324,85,0,0q�6>   $	��Top=�6R   �� 5   
   -   5        $ 
txtSoLuong��5      $
��Left=�6&   $��
415,89,0,0q�6A   $
 Wrap=�6U   $	��Top=�6i   $	��120��6�   �� 5   
   $��Nhân viên��6   $
��Left=�6$   $��322,127,0,0q�6?   $	��Top=�6T   �� 5   
   -   5        $ txtTrangThaiDon��5      $
��Left=�6+   $��129,167,0,0q�6F   $
 Wrap=�6[   $	��Top=�6o   $	��120��6�   �� 5   
   $��Trạng thái đơn��6   $
��Left=�6)   $��
37,163,0,0q�6D   $	��Top=�6X   �� 5   
   $��QUẢN LÝ HÓA ĐƠN��6   $
��Bold"�6*   
���  ��$��20(�6M   $
��Left=�6[   $��	277,0,0,0q�6v   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgvHoaDon��5      $��10,217,10,40q�6Q   $	��NaN��6g   $	��NaN��6t      AutoGenerateColumns$ False��6�      AlternatingRowBackground
 �����   CanUserAddRows$ False��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã HĐ��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6M   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *MaHd+6M     5      $ 	Họ tên��6%   $	 * 6O   
 65   �� *HoTen+6O     5      $ Số điện thoại��6%   $	 * 6\   
 6<   �� *SoDienThoai+6\     5      $ Địa chỉ��6%   $	 * 6Q   
 66   �� *DiaChi+6Q     5      $ Mã SP��6%   $	 * 6M   
 64   �� *MaSp+6M     5      $ Tên SP��6%   $	 * 6T   
 65   �� *
TenSanPham+6T     5      $ Số lượng��6%   $	 * 6S   
 67   �� *	SoLuong+6S     5       $ 	Giá bán��6%   $	 * 6Q   
 66   �� *GiaBan+6Q     5!      $ Thành tiền��6%   $	 * 6W   
 69   �� *	ThanhTien+6W     5"      $ Trạng thái��6%   $	 * 6Z   
 69   �� *TrangThaiDon+6Z     5#      $ Mã NV��6%   $	 * 6M   
 64   �� *MaNv+6M     5$      $ Thời gian mua��6%   $	 * 6\   
 6<   �� *ThoiGianMua+6\   5&      �� 5'   
   -   5         ��Name$ btnThem��5'      $��Thêm��6"   
��� � �
�������$
��Left=�6W   $��
651,56,0,0q�6r   $	��Top=�6�   $��24��6�   $��59��6�   6�   �� 5(   
   -	   5        $ btnSua��5(      $��Sửa��6!   
��� � �
�������$
��Left=�6U   $��
651,98,0,0q�6p   $	��Top=�6�   $��24��6�   $��59��6�   6�   �� 5)   
   -
   5        $ btnXoa��5)      $
��Xóa��6!   
��� � �
�������$
��Left=�6U   $��651,140,0,0q�6p   $	��Top=�6�   $��24��6�   $��59��6�   6�   �� 5*   
   -   5        $ btnXuatFile��5*      
��� � �
�������$��Xuất file��6L   $
��Left=�6`   $��
652,16,0,0q�6{   $	��Top=�6�   $��24��6�   $��58��6�   6�   �� 5+   
   -   5         ��Name$ 
cboSanPham��5+      $
��Left=�6'   $��
415,51,0,0q�6B   $	��Top=�6V   $	��120��6n   �� 5,   
   -   5        $ cboNhanVien��5,      $
��Left=�6(   $��415,129,0,0q�6C   $	��Top=�6X   $	��120��6p   �� 5-   
   -   5        $ 	btn_thoat��5-      $��Thoát��6$   $
��Left=�64   $��
736,14,0,0q�6O   $	��Top=�6c   $��26��6{   $��54��6�   6�   �� 5.   
   -   5        $��Đặt lại��5.      $
��Left=�6#   $��330,163,0,0q�6>   $	��Top=�6S   $��46��6k   6v   50      51      