   M S B A M L   `   `   `  ����  Chat    Chat.Contacts   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Grid.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v11.1.Core, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      -   5          N� Title$  Contacts��5       N� 
Background 5	      �� 5
   
    �� ImageSource$B </Chat;component/Images/1152x720_surface-green-background.jpg��6   .��5      � $	��500��6   $	��650��6    � ColumnDefinitions 5   
   �� 5      $
��293* �6   �� 5      $
��153* �6   �� 5      $	��16* �6   .+�5   
   �� -   5         ��Name$ 	txtSearch��5   L   $��40��6   $
��Left=�6   $��	12,12,0,0q�69   $	��Top=�6_   $	��569��6w   $��2��6�   $��20(�6�   .��6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFCAFDBB��6#    � Offset$ 0Q�65   � 5      $ 	#FFB1F99B��6#   $ 1Q�65   5      .��5   "   5      �� 5   
   -   5        $��	btnSearch��5   \   $��1��6   $��40��6!   $
��Left=�6-   $��
175,12,0,0q�6H   $	��Top=�6m   $��40                 ��6�   ��5      �� 5      $' !/Chat;component/Images/images.png��6   5!      �� 5"   
   -   5        $��listContacts��5"   M   $	��394��6   $
��Left=�6   $��	12,58,0,0q�6:   $	��Top=�6a   $	��615��6y   $��5��6�   ��5#      �� 5$      .R�5%      � $	��0,2q�6    5&      �� 5'      $	��100 �6/   �� 5(      $	��100 �6/   �� 5)      $	��100 �6/   �� 5*      $	��200 �6/   �� 5+      �� 5,      .+�5.      �� $��0��6$   $��14(�6K   ��64   �� *NameF+6K   �� 5/      $��1��6$   $��14(�6K   ��64   �� *NameI+6K   �� 50      $��2��6$   $��14(�6K   ��64   �� *NameO+6K   �� 51      $��3��6$   $��12(�6L   ��64   �� *Online+6L   �� 52      $��btnWriteMessage��6D   -   5        $��5��52   !   $��Написать��61   $��Center=�6�   	 � Cursor$
	 Hand��6�   $��14(�6�   $��90��6�   $��20��6�   

 � Tag
 6y   �� *IdUser+��53      �� 54   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��55   &   � $ 	#FFC1FDC1��63   $ 0Q�6E   � 56   &   $ 	#FEBAFFBA��63   $ 1Q�6E   57   #   59      5;      5<      ��5>      �� 5?      $ 0.5,1&�6&   $ 0.5,0&�67   .��5@      � $ 	#FFCAFDBB��6#   $ 0Q�65   � 5A      $ 	#FFB1F99B��6#   $ 1Q�65   5B      5D      5E      5F      