   M S B A M L   `   `   `  ����C  ?GUITools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:GUITools;assembly=GUIToolsGUITools  5   	   G COrderManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:OrderManager.ViewsOrderManager.Views 5   	   $   OrderManager.Views.EditAddress   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7gt(clr-namespace:GUITools;assembly=GUITools     5   	   a ]DevExpress.Xpf.Core.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   Bsi9http://schemas.microsoft.com/expression/2010/interactions  5	   	   Bei9http://schemas.microsoft.com/expression/2010/interactions  5
   	   ,local clr-namespace:OrderManager.Views  5   	     � Title$  EditAddress��5   	   $	��700��6   $	��600��6*   .��5      �  � RowDefinitions 5   
   �� 5      $	��85* �6   �� 5      $	��15* �6   .+�5   
   � $��0��6    � ShowGridLines .   5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5#      � $��0��6    5$      �� 5%      �� 5&      .+�5(      �� $��0��6   $��Recipient Name��6%   $
��Left=�6>   $
��Bold"�6Y   �� 5)      $��1��6   $��15(�6g   $
��Left=�5*      $	��300��65   ��5)   '   ��  �� Path$
 Name� �� UpdateSourceTrigger$ PropertyChanged=�5*   5   5+      � 5-      $��1��6    5.      �� 5/      �� 50      .+�52      �� $��0��6   $��Shipping Address 1��6%   $
��Left=�6B   $
��Bold"�6]   �� 53      $��1��6   $��15(�6k   $
��Left=�54      $	��400��65   ��53   '   �� $ Address1�$ PropertyChanged=�54   5   55      � 57      $��2��6    58      �� 59      �� 5:      .+�5<      �� $��0��6   $��Shipping Address 2��6%   $
��Left=�6B   $
��Bold"�6]   �� 5=      $��1��6   $��15(�6k   $
��Left=�5>      $	��400��65   ��5=   '   �� $ Address2�$ PropertyChanged=�5>   5   5?      � 5A      $��3��6    5B      �� 5C      �� 5D      .+�5F      �� $��0��6   $��Shipping Address 3��6%   $
��Left=�6B   $
��Bold"�6]   �� 5G      $��1��6   $��15(�6k   $
��Left=�5H      $	��400��65   ��5G   '   �� $ Address3�$ PropertyChanged=�5H   5   5I      � 5K      $��4��6    5L      �� 5M      �� 5N      .+�5P      �� $��0��6   $
��City��6%   $
��Left=�64   $
��Bold"�6O   �� 5Q      $��1��6   $��15(�6g   $
��Left=�5R      $	��400��65   ��5Q   '   �� $
 City�$ PropertyChanged=�5R   5   5S      � 5U      $��5��6    5V      �� 5W      �� 5X      .+�5Z      �� $��0��6   $��State��6%   $
��Left=�65   $
��Bold"�6P   �� 5[      $��1��6   $��15(�6h   $
��Left=�5\      $	��400��65   ��5[   '   �� $ State�$ PropertyChanged=�5\   5   5]      � 5_      $��6��6    5`      �� 5a      �� 5b      .+�5d      �� $��0��6   $��Postal Code��6%   $
��Left=�6;   $
��Bold"�6V   �� 5e      $��1��6   $��15(�6j   $
��Left=�5f      $	��200��65   ��5e   '   �� $ ZipCode�$ PropertyChanged=�5f   5   5g      � 5i      $��7��6    5j      �� 5k      �� 5l      .+�5n      �� $��0��6   $��Country��6%   $
��Left=�67   $
��Bold"�6R   �� 5o      $��1��6   $��15(�6j   $
��Left=�5p      $	��300��65   ��5o   '   �� $ Country�$ PropertyChanged=�5p   5   5q      � 5s      $��8��6    5t      �� 5u      �� 5v      .+�5x      �� $��0��6   $��Phone��6%   $
��Left=�65   $
��Bold"�6P   �� 5y      $��1��6   $��15(�6h   $
��Left=�5z      $	��300��65   ��5y   '   �� $ Phone�$ PropertyChanged=�5z   5   5{      � 5}      $��9��6    5~      �� 5      �� 5�      .+�5�      �� $��0��6   $��Email��6%   $
��Left=�65   $
��Bold"�6P   �� 5�      $��1��6   $��15(�6h   $
��Left=�5�      $	��300��65   ��5�   '   �� $ Email�$ PropertyChanged=�5�   5   5�      5�      �� 5�   
   -   5        $��1��5�      $
��Save��6   $��Center=�6B   $��Center=�6_   5�      5�      