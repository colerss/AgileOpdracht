   M S B A M L   `   `   `  ����K  GAgileWinkellijst, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AgileWinkellijstAgileWinkellijst  5   	   (    "AgileWinkellijst.WinkellijstWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AgileWinkellijst     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  WinkellijstWindow��5   	   $	��600��6#   $	��800��60   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $	��57* �6   �� 5      $	��57* �6   �� 5      $
��381* �6   �� 5      $	��76* �6   .+�5   
   �� 
���   �$	��0.5��6#   $��0��69   $��2��6F   $��0,0,-0.4,56.6q�6Z   $��2��6q   6�   �� 5   
   
���   �$	��0.5��6#   $��1��69   $��2��6F   $��0,0.2,-0.4,3.6q�6Z   6t   �� 5   
   
���   �$	��0.5��6#   $��2��69   $��2��6F   $��0,0.4,-0.4,0.4q�6Z   6t   �� 5   
   -   5         ��Name$ cmbWinkellijst��5      $��2��6+   $	��300��6?    �� DisplayMemberPath$
 Naam��6K   $��35(�6d   $��Center=�6r   $��Center=�6�   $
��Bold"�6�   $��Candara Light)�6�   $��Italic$�6�   $��55��6  $��247,1,246.6,0.8q�6*  �� 5   
   
���   �$	��0.5��6#   $��3��69   $��2��6F   $��0,0.6,-0.4,0.4q�6Z   6t   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6/   $��2��6<   $��0,0.2,-0.4,3.6q�6P   .+�5      �� -   5         ��Name$ btnTerugNaarArtikellijst��5   J      MaterialDesignRaisedButton#��[  6   $��Naar Artikellijst��6l   $��10q�6�   $��18(�6�   6�   �� 5      -   5        $ btnNieuwArtikel��5   J   #��[  6   $��Nieuw Artikel��6c   $��10q�6|   $��18(�6�   6�   �� 5      -   5        $ btnNieuweWinkellijst��5   J   #��[  6   $��Nieuwe winkellijst��6�   $��10,10,10,9.8q�6�   $��18(�6�   $	��185��6�   $
��Auto��6�   5       �� 5!   
   $
��Left=�6   $ 
Horizontal=�61   $��0��6J   $��0,0.6,0,6.4q�6Z   $	��284��6o   $��3��6{   .+�5"      �� $��Center=�6   $��22(�66   $��	0,0,0,0.2q�6D   $	��117��6W   $��Totaal Prijs��6c   �� 5#      -   5         ��Name$ tbTotaal��5#      $��10,10,10,9.8q�6)   $��Center=�6?   $��20(�6a    * &MaterialDesignOutlinedTextFieldTextBox#��[ 6o   $	��127��6�   5$      �� 5)   
   $��2��6   $��5,5.4,4.6,5.4q�6$   $��2��6;   .��5*      �� -   5        $��spWinkellijst��5*      5-      5.      � 50   
   $��2��6   $��0,0,396.6,56.6q�6#   $��2��6;    51      �� 52      54      �� 55   
   -   5        $ btnVerwijderWinkellijst��55      $��Verwijder winkellijst��62   $��173.2,9.6,9.6,6.4q�6R   $
��Auto��6�   $��1��6�   $��3��6�   57      58      