   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   P LProjektPazigFramework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjektPazigFrameworkProjektPazigFramework 5   	   &    ProjektPazigFramework.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ProjektPazigFramework     5   	   $��330.135��5      $	��650��6+     � Title$  Przegląd grup��5	   G   (   "MahApps.Metro.Controls.MetroWindow   WindowTransitionsEnabled .   � WindowStartupLocation$ CenterScreen=�6~    � DataContext 6	   �� *Main+   Locator �� Source# [  .��5
      � $��20q�6    � ColumnDefinitions 5   
   �� 5      $
��115* �6   �� 5      $
��187* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��2��6   $��0,0,0.2,0.4q�60   � 5   
   $��0,30,-11.8,-0.2q�6   $��2��6(   $��2��69    5      �� 5      $	��255 �6#   �� 5      .+�5      �� -   5        $��
lvProducts��5      $��0��6�   $��10,10,0.2,111q�6�   $��Candara Light)�6�   ��6)   �� *	ListaGrup+ �� SelectedItem 6K   �� *Grupa+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5      $��1��6   $
��Left=�6(   $��10.8,10,0,0q�6C   $
��Wrap=�6X   $��Nazwa grupy��6l   $	��Top=�6   $��25��6�   $	��132��6�   $��Candara Light)�6�   �� 5      *   $MahApps.Metro.Controls.TextBoxHelper
   ClearTextButton
 . $��1��6D   $
��Left=�6T   $��20��6o   $��142.8,10,0,0q�6{    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��196��6  $��Candara Light)�6  ��6�   �� *Nazwa+$ TwoWay=�$	 PropertyChanged=�6  �� 5      $��1��69   $
��Left=�6I   $��10.8,41,0,0q�6d   $	��Top=�6y   $	��328��6�   $��22��6�   $��Candara Light)�6�   $
��Bold"�6�   ��6   �� *AddGroupCommand+.��6�   Dodaj grupę6�   �� 5       -   5        $��Powrót do MENU��5       $
��Left=�60   $��10.8,161,0,-0.2q�6K   $	��Top=�6d   $	��327��6|   $��1��6�   $��60��6�   $��Candara Light)�6�   6�   �� 5!      $��1��6   $
��Left=�6(   $��10.8,98,0,0q�6C   $
��Wrap=�6X   $��Imię��6l   $	��Top=�6x   $��26��6�   $	��132��6�   $��Candara Light)�6�   �� 5"      
 . $��1��6D   $
��Left=�6T   $��20��6o   $��142.8,98,0,0q�6{   $
 Wrap=�6�   $	��Top=�6�   $	��196��6  $��Candara Light)�6  ��6�   �� *Imie+$ TwoWay=�$	 PropertyChanged=�6  �� 5#      $��Dodaj osobę��6�   $��1��6�   $
��Left=�6�   $��10.8,129,0,0q�6�   $	��Top=�6�   $	��328��6�   $��Candara Light)�6�   $
��Bold"�6  ��6   �� *AddPersonCommand+��6:   ��  �� ElementName$ 
lvProducts�� �� Path$ SelectedItem�6  �� 5$      $��1��6�   $
��Left=�6�   $��10.8,68,0,0q�6�   $	��Top=�6�   $	��328��6�   $��Usuń grupę��6�   $��24��6�   $��Candara Light)�6  ��6   �� *DeleteGroupCommand+��6<   �� $ 
lvProducts��$ SelectedItem�6  �� 5%      -   5         ��Name$ lvProducts_Copy��5%      $��0��6T   $��10,139,0.2,10q�6a   $��Candara Light)�6x   ��61   �� *
PersonList+6x   �� 5&      $
��Left=�6   $��
10,119,0,0q�63   $
��Wrap=�6G   $	��Top=�6[   $��25��6s   $	��122��6   $��Candara Light)�6�   �� 6�   $�Lista ��6�   �� 6�   $�osób z danej grupy��6�   6�   5:      �� 5;   
   $
��Left=�6   $��	10,10,0,0q�6/   $
��Wrap=�6B   $��
Lista grup��6V   $	��Top=�6h   $��25��6�   $	��244��6�   $��Candara Light)�6�   ���	#FF252525
������� �� TextAlignment$ Center=�6�   $��16(�6�   $��2��6  $��2��6  5<      5=      