   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   P LProjektPazigFramework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjektPazigFrameworkProjektPazigFramework 5   	   -   'ProjektPazigFramework.Rozliczeniedlugow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ProjektPazigFramework     5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  6;   $��330.135��5   (   $	��650��69     � Title$  Rozliczenie��5	   N   (   "MahApps.Metro.Controls.MetroWindow   WindowTransitionsEnabled .   � WindowStartupLocation$ CenterScreen=�6�   ���	#FF252525 � DataContext 6	   �� *Rozliczenie+   Locator �� Source# [  .��5
      � $��20q�6    � ColumnDefinitions 5   
   �� 5      $	��72* �6   �� 5      $	��79* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��2��6   $��0,0,0.2,0.4q�60   � 5   
   $��0,30,-11.8,-0.2q�6   $��2��6(   $��2��69    5      �� 5      $��0 �6#   �� 5      $
��13.6 �6#   �� 5      $��241.247 �6#   �� 5      $��4* �6#   �� 5      .+�5+      �� -   5        $��
lvProducts��5+      $��0��6�   $��10,10,248.2,70q�6�   $��Candara Light)�6�   $��4��6�   ��6)   �� *	ListaGrup+ �� SelectedItem 6K   �� *Grupa+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5,      $��1��6@   $
��Left=�6P   $��
10,166,0,0q�6k   $	��Top=�6   $	��290��6�   $��22��6�   $��Candara Light)�6�   $
��Bold"�6�   $��3��6�   ��6   �� *ShowListDebetsCommand+.��6�   Pokaż listę długów6  �� 5-      -   5        $��Powrót do MENU��5-      $
��Left=�60   $��
10,196,0,0q�6K   $	��Top=�6_   $	��290��6w   $��1��6�   $��25��6�   $��Candara Light)�6�   $��3��6�   �� 5.      $��3��6?   $
��Left=�6O   $��48.8,196,0,0q�6j   $	��Top=�6�   $	��290��6�   $��Rozlicz wszystkie długi��6�   $��24��6�   $��Candara Light)�6�   $��2��6�   ��6   �� *DeleteDebetsCommand+6�   �� 5/      $
��Left=�6   $��
10,-26,0,0q�63   $
��Wrap=�6G   $��
Lista grup��6[   $	��Top=�6m   $��25��6�   $	��285��6�   $��Candara Light)�6�   $��4��6�   ���	#FF252525
�������
 �� TextAlignment$
 Center=�6�   $��16(�6  �� 50      $
��Left=�6   $��48.8,-26,0,0q�63   $
��Wrap=�6I   $��Lista długów��6]   $	��Top=�6q   $��25��6�   $	��290��6�   $��Candara Light)�6�   $��3��6�   $��2��6�   
����������	#FF252525$��16(�6
  $
 Center=�6  &   System.Windows.Controls.DataGrid  53      $��0��54      $��48.8,10,21.2,70q�6"   $��Candara Light)�6;   $��3��6V      AutoGenerateColumns .  $��2��55   1   ��53      �� *ListaDlugow+   Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$	 KTO��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 58      1  +System.Windows.Controls.DataGridBoundColumn   Binding 59      �� *	WhoName+  5:      $ JAKĄ KWOTĘ ZŁ��6)   $	 105 5;   )    5<   +   �� *Amount+  5>      $
 KOMU��6)   $ 90 5?   )    5@   +   �� *
ForWhoName+5B      �� 5C      -   5        $��3��5C      $
��Left=�6%   $��48.8,166,0,0q�6@   $	��Top=�6V   $	��290��6n   $��Rozlicz jeden dług��6z   $��24��6�   $��Candara Light)�6�   $��2��6�   5D      5E      5F      