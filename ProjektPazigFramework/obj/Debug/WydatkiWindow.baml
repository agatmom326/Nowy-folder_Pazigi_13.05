   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   P LProjektPazigFramework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjektPazigFrameworkProjektPazigFramework 5   	   )   #ProjektPazigFramework.WydatkiWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ProjektPazigFramework     5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  6;   $��330.135��5   (   $	��650��69     � Title$  Wydatki��5	   J   (   "MahApps.Metro.Controls.MetroWindow   WindowTransitionsEnabled .   � WindowStartupLocation$ CenterScreen=�6{    � DataContext 6	   �� *	Wydatki+   Locator �� Source# [  .��5
      � $��20q�6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   � $��0��6   � 5   
   $��0,30,-11.8,-0.2q�6   $��2��6(    � ColumnDefinitions 5      �� 5      $	��255 �6#   �� 5      .+�5      �� -   5        $��
lvProducts��5      $��0��6�   $��10,10,0.2,135q�6�   $��Candara Light)�6�   ��6)   �� *
LListaGrup+ �� SelectedItem 6L   �� *Grupa+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5      $��1��6   $
��Left=�6(   $��10.8,10,0,0q�6C   $
��Wrap=�6X   $��Nazwa wydatku��6l   $	��Top=�6�   $��25��6�   $	��132��6�   $��Candara Light)�6�   �� 5      *   $MahApps.Metro.Controls.TextBoxHelper
   ClearTextButton
 . $��1��6�   $
��Left=�6�   $��20��6�   $��143.8,5,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��195��6  $��Candara Light)�6  ��6D   �� *Nazwawydatku+$ TwoWay=�$	 PropertyChanged=�6  �� 5      $��1��6�   $
��Left=�6�   $��10.8,136,0,0q�6�   $	��Top=�6�   $	��328��6�   $��22��6�   $��Candara Light)�6�   $
��Bold"�6  ��6   �� *AddExpenseCommand+��6<   ��  �� ElementName$ lista�� �� Path$ SelectedValue�.��6  Dodaj wydatek6-  �� 5      -   5        $��Powrót do MENU��5      $
��Left=�60   $��10.8,196,0,0q�6K   $	��Top=�6a   $	��328��6y   $��1��6�   $��25��6�   $��Candara Light)�6�   6�   �� 5      $��1��6   $
��Left=�6(   $��11.8,40,0,0q�6C   $
��Wrap=�6X   $��	Koszt zł��6l   $	��Top=�6|   $��26��6�   $	��132��6�   $��Candara Light)�6�   �� 5      
 . $��1��6�   $
��Left=�6�   $��20��6�   $��143.8,36,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��195��6  $��Candara Light)�6  ��6D   �� *Kwota+$ TwoWay=�$	 PropertyChanged=�6  �� 5      $��1��6�   $
��Left=�6�   $��11.8,166,0,0q�6�   $	��Top=�6�   $	��327��6�   $��Usuń wydatek��6�   $��24��6	  $��Candara Light)�6  ��6   �� *DeleteExpenseCommand+��6@   �� $ lvProducts_Copy��$ SelectedItem�6  &   System.Windows.Controls.DataGrid  5       -   5        $��lvProducts_Copy��5       $��0��5!      $��10,125,0.2,10q�6!   $��Candara Light)�68      AutoGenerateColumns .  ��5    .   �� *Listawydatkow+   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ WYDATEK��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 5%      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5&      �� *Name+  5'      $ 	KWOTA ZŁ��6)   $	 100 5(   )    5)   +   �� *Amount+5+      �� 5,      $
��Left=�6   $��
10,100,0,0q�63   $
��Wrap=�6G   $	��Top=�6[   $��25��6s   $	��122��6   $��Candara Light)�6�   �� 6�   $�Lista ��6�   �� 6�   $�wydatków grupy��6�   6�   �� 5-      $
��Left=�6�   $��143.8,67,0,0q�6�   $	��Top=�6�   $	��195��6  $��1��6  ��6   �� $ 
lvProducts��$  SelectedItem.PeopleInGroup� �� SelectedValue 6h   �� *	Platnik+$ TwoWay=�$	 PropertyChanged=�5.      �� 5/      $��1��6   $
��Left=�6(   $��11.8,71,0,0q�6C   $
��Wrap=�6X   $��Kto zapłacił?��6l   $	��Top=�6�   $��25��6�   $	��132��6�   $��Candara Light)�6�   %  Xceed.Wpf.Toolkit.CheckComboBox  50      -   5          Name$ _combo��50   !   $��143.8,100,25,0q�51      $	��Top=�66   $��1��6N   +	  %Xceed.Wpf.Toolkit.Primitives.Selector 	  ValueMemberPath$ Level��52       	  SelectedMemberPath$ Selected��55      $��24��58      ���	#FFF7F4F4��53      �� $ 
lvProducts��$  SelectedItem.PeopleInGroup�   Text 54      �� *Txt+$ TwoWay=�$	 PropertyChanged=� 	  SelectedValue 56      �� *Checkedperson+$ TwoWay=�$	 PropertyChanged=� 	  SelectedItemsOverride 57      �� *Checkedperson+$ OneWayToSource=�$	 PropertyChanged=�58   *   �� 5;      $
��Left=�6   $��11.8,100,0,0q�63   $
��Wrap=�6I   $��Komu?��6]   $	��Top=�6j   $��25��6�   $	��132��6�   $��Candara Light)�6�   $��1��6�   5<      �� 5=   
   $
��Left=�6   $��10,6,0,0q�6/   $
��Wrap=�6A   $��
Lista grup��6U   $	��Top=�6g   $��25��6   $	��242��6�   $��Candara Light)�6�   ���	#FF252525
������� �� TextAlignment$ Center=�6�   $��16(�6�   $��2��6  5>      5?      