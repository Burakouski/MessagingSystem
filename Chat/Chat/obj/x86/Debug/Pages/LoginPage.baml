   M S B A M L   `   `   `  ����  Chat    Chat.Pages.LoginPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      e aSystem.Activities.Presentation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35NsapDhttp://schemas.microsoft.com/netfx/2009/xaml/activities/presentation  5      a ]DevExpress.Xpf.Core.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6e     N� Title$  	LoginPage��6    N� 
Background 5	      �� 5
   
    �� ImageSource$B </Chat;component/Images/1152x720_surface-green-background.jpg��6   .��5      � .+�5   
   �� -   5        $��txtLogin��5   N   $��33��6   $
��Left=�6   $��272,138,0,0q�69   $	��Top=�6^   $	��200��6v   $��25(�6�   $��
Логин��6�    �� TextAlignment$ Center=�6�   $��Bottom=�6�   $��Italic$�6�   $��	Condensed&�6�   $��Light"�6  ���	#FF175505.��6g  ��5      �� 5       �� EndPoint$ 1,0.5&�6&    �� 
StartPoint$ 0,0.5&�67   .��5      �  � Color$ 	#FF43A356��6#    � Offset$ 0Q�65   � 5      $ 	#FF93D100��6#   $ 1Q�65   5      .��5   "   ��5      �� 5      $ 1,0.5&�6&   $ 0,0.5&�67   .��5      � $ White��6#   $ 1Q�61   � 5      $ White��6#   $ 1Q�61   5      .��5   #   5      �� 5   
   -   5        $��LblLogin��5   K   $��40��6   $
��Left=�6   $��
272,92,0,0q�67   $	��Top=�6[   $	��200��6s   $��25(�6   $��Center=�6�   $��Italic$�6�   ���	#FF1755056�   �� 5   
   -   5        $��lblPassword��5   L   $��40��6   $
��Left=�6   $��272,177,0,0q�67   $	��Top=�6_   $	��200��6w   $��25(�6�   $��Center=�6�   $��Italic$�6�   ���	#FF1755056�   ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  5   
   -   5        $��passwordBoxEdit1��5   N   $
��Left=�6   $��272,223,0,0q�69   $	��Top=�6f   $	��200��6~   %  DevExpress.Xpf.Editors.BaseEdit   ShowNullText . 	   NullText$	         Пароль��6�   $��38��6�   $��25(�6�   $��	Condensed&�6�   $��Italic$�6�   $��Light"�6�   ���	#FF175505$��0q�6'  $��Center=�6;  )  #DevExpress.Xpf.Editors.TextEditBase$
   HorizontalScrollBarVisibility$
 Hidden=�6_  !   ShowCapsLockWarningToolTip .    
ShowBorder .   � UseLayoutRounding .  ��5      �� 5      $ 1,0.5&�6&   $ 0,0.5&�67   .��5       � $ 	#FF43A356��6#   $ 0Q�65   � 5!      $ 	#FF93D100��6#   $ 1Q�65   5"      ��5$      �� 5%      $ 0.5,1&�6&   $ 0.5,0&�67   .��5&      � $ White��6#   $
 0.98Q�61   � 5'      $ Black��6#   $ 1Q�61   5(      5*      �� 5+   
   -   5        $��button1��5+   ]   $��
ВОЙТИ��6   $��38��6!   $
��Left=�6-   $��272,267,0,0q�6H   $	��Top=�6l   $	��200��6�   $��0q�6�   $��20(�6�   ���	#FF175505$��Italic$�6�   $��UltraCondensed&�6�   $��SemiBold"�6�    �� 	IsDefault . ��5,      �� 5-      $ 1,0.5&�6&   $ 0,0.5&�67   .��5.      � $ 	#FF43A356��6#   $ 0Q�65   � 5/      $ 	#FF93D100��6#   $ 1Q�65   50      52      �� 53   
   -   5         ��Name$ btnRegistration��53   c   $��Регистрация��6   $��38��6'   $
��Left=�63   $��272,372,0,0q�6N   $	��Top=�6|   $	��200��6�   $��0q�6�   $��20(�6�   ���	#FF175505$��Italic$�6�   $��UltraCondensed&�6�   $��SemiBold"�6	   . ��54      �� 55      $ 1,0.5&�6&   $ 0,0.5&�67   .��56      � $ 	#FF43A356��6#   $ 0Q�65   � 57      $ 	#FF93D100��6#   $ 1Q�65   58      5:      5;      5<      