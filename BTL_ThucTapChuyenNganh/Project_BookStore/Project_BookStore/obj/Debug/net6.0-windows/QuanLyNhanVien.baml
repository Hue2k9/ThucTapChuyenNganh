   M S B A M L   `   `   `  ����L  HProject_BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_BookStoreProject_BookStore  5   	   &     Project_BookStore.QuanLyNhanVien   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Project_BookStore     5   	   -   5          � Title$  QuanLyNhanVien��5   	   $	��450��6    $	��800��6-   ���#EEEEEE.��5	      � -   5         �Name$ btnThongKe1��5	      $��
0,-17,0,17q�6    .+�5
   
   �� $��Tên nhân viên:��6   $
��Left=�6)   $��
63,102,0,0q�6D   $	��Top=�6X   $	��100��6p   $��30��6|   �� 5   
   $��Giới tính:��6   $
��Left=�6%   $��
63,209,0,0q�6@   $	��Top=�6T   $	��100��6l   $��30��6x   �� 5   
   $��Địa chỉ:��6   $
��Left=�6#   $��439,107,0,0q�6>   $	��Top=�6S   $	��100��6k   $��30��6w   �� 5   
   $��Điện thoại:��6   $
��Left=�6&   $��439,157,0,0q�6A   $	��Top=�6V   $	��100��6n   $��30��6z   �� 5   
   $��Email:��6   $
��Left=�6!   $��
63,157,0,0q�6<   $	��Top=�6P   $	��100��6h   $��30��6t   �� 5   
   -   5         ��Name$ txtTen��5      $
��Left=�6"   $��168,102,0,0q�6=   $�� ��6R    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6n   $	��200��6�   $��30��6�   	� 5   
   -   5         	�Name$ radNam��5      $	��Nam��6&   $
��Left=�64   $��180,217,0,0q�6O   $	��Top=�6d   	� 5   
   -   5        $ radNu��5      $
��Nữ��6%   $
��Left=�62   $��271,217,0,0q�6M   $	��Top=�6b   �� 5   
   -   5        $ txtDienThoai��5      $
��Left=�6(   $��552,157,0,0q�6C   $�� ��6X   $
 Wrap=�6`   $	��Top=�6t   $	��200��6�   $��30��6�   �� 5   
   -   5        $ txtEmail��5      $
��Left=�6$   $��168,157,0,0q�6?   $�� ��6T   $
 Wrap=�6\   $	��Top=�6p   $	��200��6�   $��30��6�   �� 5   
   -   5        $��Thêm��5      
��� � �
�������$
��Left=�6G   $��117,279,0,0q�6b   $	��Top=�6w   $��80��6�   $��30��6�   6�   �� 5   
   -	   5         ��Name$ btnSua��5      $��Sửa��6!   
��� � �
�������$
��Left=�6V   $��249,279,0,0q�6q   $	��Top=�6�   $��80��6�   $��30��6�   6�   �� 5   
   -
   5        $
��Xóa��5      
��� � �
�������$
��Left=�6F   $��370,279,0,0q�6a   $	��Top=�6v   $��80��6�   $��30��6�   6�   �� 5   
   -   5        $ btnTim��5      $
��Tìm��6!   
��� � �
�������$
��Left=�6V   $��477,279,0,0q�6q   $	��Top=�6�   $��80��6�   $��30��6�   6�   �� 5   
   -   5        $ 
btnThongKe��5      $��Thống kê��6%   
��� � �
�������$
��Left=�6_   $��597,279,0,0q�6z   $	��Top=�6�   $��80��6�   $��30��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgvNhanVien��5      $��48,333,48,10q�6&      AutoGenerateColumns$ False��5         AlternatingRowBackground
 �����   CanUserAddRows$ False��5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Mã nhân viên��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *MaNv+6T     5      $
 Tên nhân viên��6%   $ * 6V    6<   �� *TenNv+6V     5       $
 Giới tính��6%   $ * 6U    68   �� *
GioiTinh+6U     5!      $
 Địa chỉ��6%   $ * 6Q    66   �� *DiaChi+6Q     5"      $
 Điện thoại��6%   $ * 6R    69   �� *SoDt+6R     5#      $
 Email��6%   $ * 6N    64   �� *Email+6N   5%      �� 5&   
   $��QUẢN LÝ NHÂN VIÊN��6   $
��Bold"�6,   
���  ��$��20(�6O   $
��Left=�6]   $��
271,30,0,0q�6x   $	��Top=�6�   $	��292��6�   $��45��6�   �� 5'   
   -   5        $ btnThoat��5'      $��Thoát��6#   $
��Left=�63   $��
722,30,0,0q�6N   $	��Top=�6b   $��25��6z   $��68��6�   6�   �� 5(   
   -   5        $ 	txtDiaChi��5(      $
��Left=�6%   $��552,102,0,0q�6@   $�� ��6U   $
 Wrap=�6]   $	��Top=�6q   $	��200��6�   $��30��6�   �� 5)   
   -   5        $��Đặt lại��5)      $
��Left=�6#   $��439,209,0,0q�6>   $	��Top=�6S   $��50��6k   6v   5*      5+      