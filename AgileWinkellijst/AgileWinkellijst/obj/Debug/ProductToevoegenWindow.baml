   M S B A M L   `   `   `  ����K  GAgileWinkellijst, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AgileWinkellijstAgileWinkellijst  5   	   -    'AgileWinkellijst.ProductToevoegenWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AgileWinkellijst     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   
�������  � Title$  ProductToevoegenWindow��5
   	   $	��600��6(   $	��800��65   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��7* �6   .+�5   
   �� 
���   �$	��0.5��6#   $��0��69   $��2��6F   6\   �� 5   
   
���   �$	��0.5��6#   $��1��69   $��2��6F   6\   �� 5   
   
���   �$	��0.5��6#   $��2��69   $��2��6F   6\   �� 5   
   -   5         ��Name$ lblWinkellijst��5      $��Nieuw artikel aanmaken��6(   $��2��6I   $��35(�6]   $��Center=�6k   $��Center=�6�   $
��Bold"�6�   $��Candara Light)�6�   $��Italic$�6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6/   .+�5      �� -   5         ��Name$ btnNaarArtikellijst��5   J      MaterialDesignRaisedButton#��[  6   $��Naar Artikellijst��6�   $��10q�6�   $��18(�6�   �� 5      -   5        $ btnNaarWinkellijst��5   I   #��[  6   $��Naar winkellijst��6�   $��10q�6�   $��0��6�   $��5��6�   $��18(�6�   5      � 5    
   $��2��6   $��2��6   $��10q�60   ���#89ABA4 5!      �� 5"      �� 5#       5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�5+      �� $��5q�6   .+�5,      �� $��22(�6   $
��Bold"�6&   .��68   NAAM NIEUW PRODUCT6L   �� 5-      -   5         ��Name$ txtNaam��5-      
�������$��Stretch=�6>    * &MaterialDesignOutlinedTextFieldTextBox#��[ 6`   6�   5.      �� 5/      $��5q�6   $��1��6$   .+�50      �� $��22(�6   $
��Bold"�6&   .��68   STUKGEWICHT NIEUW PRODUCT6S   �� 51      -   5        $ 
txtGewicht��51      
�������$��Stretch=�6A   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 gram��6_   #��[ 6�   6�   52      �� 53      $��1��6   $��5q�6'   .+�54      �� $��22(�6   $
��Bold"�6&   .��68   PRIJS NIEUW PRODUCT6M   �� 55      -   5        $ txtPrijs��55      
�������$��Stretch=�6?   #��[ 6a   6�   56      �� 57      $��5q�6   $��2��6$   $��2��61   .+�58      �� $��22(�6   $
��Bold"�6&   .��68   
AFDELING6B   �� 59      -   5        $��	cbLocatie��59      $��10q�6-   $��22(�69   $��Stretch=�6G   
�������6z   5:      �� 5<      -   5        $ btnProductAanmaken��5<   I   #��[  6   $��Product Aanmaken��6e   $��10q�6�   $��0��6�   $��30��6�   $��18(�6�   $��Stretch=�6�   5>      5@      5A      