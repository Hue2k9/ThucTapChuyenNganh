   M S B A M L   `   `   `  ����B  >Bai 9_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Bai_9_2Bai_9_2  5   	       Bai_9_2.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Bai_9_2     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$$ Bai 9_2 Quản lý nhân viên��5   	   $	��450��6+   $	��800��68   $��25(�6D   .��5	      � $��5q�6   
����  � � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      �� 5      .+�5   
   �� $��	Họ tên��6   $��0��6!   $��0��6.   
�������$��	10,10,0,0q�6Q   �� 5   
   $��Giới tính��6   $��1��6$   $��0��61   
�������$��10,0,0,0q�6T   �� 5   
   $��
Phòng ban��6   $��2��6$   $��0��61   
�������$��10,0,0,0q�6T   �� 5   
   -   5         ��Name$ hoten��5      $��0��6!   $��1��6.   $��	10,5,10,5q�6>   �� 5   
   -   5         ��Name$ gioitinh��5      $��1��6%   $��1��65   $��	10,5,10,5q�6B    �� SelectedIndex$ 0��6U   .@�5      �� $	��Nam��6   �� 5      $
��Nữ��6   5      �� 5   
   -   5        $ phongban��5      $��1��6%   $��2��65   $��	10,5,10,5q�6B   $ 0��6U   .@�5      �� $��Phòng tài chính��6   �� 5      $��Phòng kế toán��6   �� 5       $��Phòng hành chính��6   �� 5!      $��Phòng kỹ thuật��6   5"      �� 5#   
   $��1��6   $��3��6%    �� Orientation$ 
Horizontal=�62   $��Right=�6K   .+�5$      �� -   5         ��Name$
 them��5$      $��Thêm��6#   $��50��62   $	��100��6>   $��30q�6J   6V   �� 5%      -   5        $ thoat��5%      $��Thoát��6$   $��50��64   $	��100��6@   $��	10,0,70,0q�6L   6_   5&      �� 5'   
   -   5        	 ��Name$	 hienthi��5'      $��4��6#   $��2��60   $��10q�6D   5(      5)      