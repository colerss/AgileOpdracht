   M S B A M L   `   `   `  ����K  GAgileWinkellijst, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AgileWinkellijstAgileWinkellijst  5   	   !    AgileWinkellijst.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AgileWinkellijst     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5        
�������  � Title$  Artikellijst��5   	   $	��600��6   $	��800��6+   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��6* �6   .+�5   
   �� 
���   �$	��0.5��6#   $��0��69   $��2��6F   6\   �� 5   
   
���   �$	��0.5��6#   $��1��69   $��2��6F   6\   �� 5   
   
���   �$	��0.5��6#   $��2��69   $��2��6F   6\   �� 5   
   
���   �$	��0.5��6#   $��3��69   $��2��6F   6\   �� 5   
   -   5         ��Name$ lblAssortiment��5      $��Artikellijst��6(   $��6��6?   $��35(�6S   $��Center=�6a   $��Center=�6�   $
��Bold"�6�   $��Candara Light)�6�   $��Italic$�6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6/   .+�5      �� -   5         ��Name$ btnNieuwArtikel��5   J      MaterialDesignRaisedButton#��[  6   $��18(�6c   $��Nieuw Artikel��6r   $��10q�6�   $��6��6�   6�   �� 5      -   5        $ btnWinkellijst��5   J   #��[  6   $	��18 (�6b   $��Naar Winkellijst��6r   $��10q�6�   $��6��6�   6�   5       �� 5!   
   $ 
Horizontal=�6   $��2��6.   .+�5"      �� $��20(�6   $��Center=�6"   $
��Bold"�6D   .��6W   	Zoeken:6`   �� 5#      -   5        $��tbSearch��5#      $��10q�6&   $	��200��62    * &MaterialDesignOutlinedTextFieldTextBox#��[ 6E   6�   �� 5$      -   5        $ 	btnsearch��5$      $��Zoeken��6(   $��10,10,10,10q�69   $
��Auto��6N   6v   5%      �� 5&   
   $��2��6   $��1��6"   $ 
Horizontal=�62   $��Right=�6K   .+�5'      �� -   5        $��
cbAfdeling��5'      $��10q�6*   $��22(�66   $	��200��6D   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Selecteer afdeling��6�   6�   5(      �� 5)   
   $��1��6   $��1��6"   $ 
Horizontal=�62   $��Right=�6K   .+�5*      �� -   5        $��tbWinkellijstselecteren��5*      $��10,11,10,11.2q�68   $��22(�6O   $	��200��6]   $ Selecteer winkellijst��6l   $	��125��6�   6�   5+      �� 5-   
   $��3��6   $��10,9.8,9.6,9.6q�6$   $��2��6<   .��5.      �� -	   5         ��Name$ spArtikellijst��5.      50      51      53      54      