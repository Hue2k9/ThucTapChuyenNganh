   M S B A M L   `   `   `  ����L  HProject_BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_BookStoreProject_BookStore  5   	   %    Project_BookStore.QuanLySanPham   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Project_BookStore     5   	     � Title$  QuanLySanPham��5   	   $	��450��6   $	��800��6,   ���#EEEEEE.��5	      � -   5        .+�5
   
   �� $
��Left=�6   $	��129��6/   $��
46,121,0,0q�6<   
���   �$	��Top=�6_   $	��703��6w   �� 5   
   $��QUẢN LÝ SẢN PHẨM��6   $��Center=�6+   $��0,43,0,0q�6H   $	��Top=�6Z   $
��Bold"�6r   $��20(�6�   
���  ��6�   �� 5   
   $��Tên sản phẩm:��6   $
��Left=�6(   $��
74,135,0,0q�6C   $	��Top=�6W   �� 5   
   $��Số lượng còn:��6   $
��Left=�6(   $��
74,202,0,0q�6C   $	��Top=�6W   �� 5   
   $��Giới thiệu:��6   $
��Left=�6&   $��458,136,0,0q�6A   $	��Top=�6V   �� 5   
   $��Bảo quản:��6   $
��Left=�6$   $��458,169,0,0q�6?   $	��Top=�6T   �� 5   
   $��
Giá bán:��6   $
��Left=�6#   $��
74,164,0,0q�6>   $	��Top=�6R   �� 5   
   -   5        $��txtTen��5      $
��Left=�6    $��218,139,0,0q�6;   $�� ��6P    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��162��6�   �� 5   
   -   5        $��
txtSoluong��5      $
��Left=�6$   $��218,206,0,0q�6?   $�� ��6T   $
 Wrap=�6\   $	��Top=�6p   $	��162��6�   �� 5   
   -   5        $��txtGioithieu��5      $
��Left=�6&   $��562,140,0,0q�6A   $�� ��6V   $
 Wrap=�6^   $	��Top=�6r   $	��162��6�   �� 5   
   -   5        $��
txtBaoquan��5      $
��Left=�6$   $��562,173,0,0q�6?   $�� ��6T   $
 Wrap=�6\   $	��Top=�6p   $	��162��6�   �� 5   
   -   5        $��txtGia��5      $
��Left=�6    $��218,169,0,0q�6;   $�� ��6P   $
 Wrap=�6X   $	��Top=�6l   $	��162��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��tblSP��5      $��46,342,37,48q�6       AutoGenerateColumns$ False��5         AlternatingRowBackground
 �����   CanUserAddRows$ False��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã sản phẩm��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *MaSp+6S     5      $ Tên sản phẩm��6%   $ * 6U    6;   �� *TenSp+6U     5      $ Số lượng còn��6%   $ * 6Z    6;   �� *
SoLuongTon+6Z     5      $ 	Giá bán��6%   $	 100 6Q    66   �� *GiaBan+6Q     5      $ Giới thiệu��6%   $ * 6W    69   �� *	GioiThieu+6W     5       $ Bảo quản��6%   $ * 6S    67   �� *	BaoQuan+6S   5"      �� 5#   
   -   5        $��btnThem��5#      
��� � �
�������$��Thêm��6F   $
��Left=�6U   $��
92,264,0,0q�6p   $	��Top=�6�   $��75��6�   6�   �� 5$   
   -	   5        $��btnSua��5$      
��� � �
�������$��Sửa��6E   $
��Left=�6S   $��266,264,0,0q�6n   $	��Top=�6�   $��76��6�   6�   �� 5%   
   -
   5        $��btnXoa��5%      
��� � �
�������$
��Xóa��6E   $
��Left=�6S   $��448,262,0,0q�6n   $	��Top=�6�   $��74��6�   6�   �� 5&   
   -   5        $��btnTim��5&      
��� � �
�������$
��Tìm��6E   $
��Left=�6S   $��628,307,0,0q�6n   $	��Top=�6�   $��68��6�   6�   �� 5'   
   -   5        $��btnReset��5'      
��� � �
�������$��Đặt lại��6G   $
��Left=�6Y   $��628,261,0,0q�6t   $	��Top=�6�   $��66��6�   6�   �� 5(   
   -   5        $��txtTim��5(      $
��Left=�6    $��446,310,0,0q�6;   $�� ��6P   $
 Wrap=�6X   $	��Top=�6l   $	��150��6�   6�   �� 5)   
   -   5        	 ��Name$	 btnThoat��5)      $��Thoát��6$   $
��Left=�64   $��
723,10,0,0q�6O   $	��Top=�6c   $��26��6{   $��67��6�   6�   �� 5*   
   -   5        $	 btnImportExcel��5*      
��� � �
�������$��Thêm bằng Excel��6O   $
��Left=�6i   $��	46,16,0,0q�6�   $	��Top=�6�   $	��111��6�   $��20��6�   6�   5,      5-      