   M S B A M L   `   `   `  ����L  HProject_BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_BookStoreProject_BookStore  5   	   &     Project_BookStore.QuanLyTaiKhoan   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Project_BookStore     5   	   -   5          � Title$  QuanLyTaiKhoan��5   	   $	��450��6    $	��800��6-   ���#EEEEEE.��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   6.   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��QUẢN LÝ TÀI KHOẢN��6   $
��Left=�6,   $
��Bold"�6G   $��20(�6Y   $��
118,10,0,0q�6g   
���  ��$��0��6�   $��1��6�   $	��241��6�   �� 5   
   $��Tên Đăng Nhập ��6   $��1��6)   $��0��66   $��20(�6F   $��Center=�6T   $��	10,20,0,0q�6q   �� 5   
   -   5         ��Name$ username��5      $��1��6$   $��20(�61   $��1��6?   $��35��6O   $	��400��6[   $��
-120,0,0,0q�6g   �� 5   
   $��Mật Khẩu��6   $��2��6#   $��0��60   $��25(�6@   $��Center=�6N   $��	10,20,0,0q�6k   �� 5   
   -   5        $ password��5      $��2��6$   $��20(�61   $��1��6?   $��35��6O   $��66,10,179,9q�6[   �� 5   
   $��Phân Quyền��6   $��3��6%   $��0��62   $��25(�6B   $��Center=�6P   $��	10,20,0,0q�6m   �� 5   
   -   5        $ 	phanquyen��5      $��3��6%   $��20(�62   $��1��6@   $��35��6P   $	��400��6\   $��
-120,0,0,0q�6h   �� 5   
   $��Mã NV��6   $��4��6    $��0��6-   $��25(�6=   $��Center=�6K   $��	10,20,0,0q�6h   �� 5    
   -   5        $
 manv��5       $��4��6    $��20(�6-   $��1��6;   $��35��6K   $	��400��6W   $��
-120,0,0,0q�6c   �� 5!   
   $��5��6   $��2��6"   $��Center=�66    �� Orientation$ 
Horizontal=�6S   .+�5"      �� -   5         ��Name$ btn11��5"      $��Thêm��6$   $��35��63   $	��150��6?   
��� � �$��20(�6^   
�������$
��Bold"�6   6�   �� 5#      -   5        $ btn22��5#      $��Sửa��6$   $��35��62   $	��150��6>   
��� � �$��20(�6]   
�������$
��Bold"�6~   $��30,0,0,0q�6�   6�   �� 5$      -   5        $ btn33��5$      $
��Xóa��6$   $��35��62   $	��150��6>   
��� � �$��20(�6]   
�������$
��Bold"�6~   $��30,0,0,0q�6�   6�   5%      &   System.Windows.Controls.DataGrid  5&   
   -	   5          Name$
 data��5&         AutoGenerateColumns$ False��6!   $��0,60,0,0q�6=   $��5��6O   $��2��6\   $��3��6p      Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Tên DN��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *TenDn+  5)      $	 Mật Khẩu��6%   $
 * 67    6A   �� *	MatKhau+  5*      $	 Phân Quyền��6%   $
 * 69    6C   �� *	PhanQuyen+  5+      $	 Mã NV��6%   $
 * 64    6>   �� *MaNv+5-      �� 5.   
   -
   5        $ 	btn_thoat��5.      $��1��6$   
��� � �
�������$��Thoát��6Z   $
��Left=�6j   $��
529,19,0,0q�6�   $	��Top=�6�   $��28��6�   $��80��6�   6�   �� 5/   
   -   5        $ 	btnDatLai��5/      $��1��6$   $��Đặt lại��64   $
��Left=�6F   $��491,22,0,12q�6a   $��4��6v   6�   50      51      