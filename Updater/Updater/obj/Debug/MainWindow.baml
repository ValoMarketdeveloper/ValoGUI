   M S B A M L   `   `   `  ����C  ?GUITools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:GUITools;assembly=GUIToolsGUITools  5   	   B >Updater, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UpdaterUpdater 5   	      Updater.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7gt(clr-namespace:GUITools;assembly=GUITools     5   	   'localclr-namespace:Updater     5   	     � Title$  
MainWindow��5	   	   $	��550��6   $
��1375��6)    � 	Resources 5
         
customBlue �� A �� R �� G �� B  customBlueBrush �� Color  customBlueBrushOpacity �� Opacity �� 
TargetType	 �� Triggers
 P� Property P� Value �� Property �� Value  noStyleToListboxItem �� 
TargetType��%   &	        &	 H     7   &	 `     '�� �     &	     �� 5   
   $	 255��6$   $ 54��6.   $ 95��65   $	 177��6<   �� 5   
   8   6X   �� 5   
   $ 	LightGray��69   $
 0.11Q�6K   6\   �� 5   
   " ��6   	 5      P� 5      
 � {� . . �5      ��  � ��
 ��ح�63   5      5      �� 5   
   " ��6-   .�5      ��  �@J�SnapsToDevicePixels . 64   �� 5       �@�OverridesDefaultStyle . 66   �� 5       �@�FocusVisualStyle 61   Z� �� 5       � ��$ Stretch=�64   �� 5       � ��$ 14(�6)   �� 5       � ��$ 20��6*   �� 5       � �� 5      �� 5      " ��6&   .R�5       �� ._�5!      �� 61   5"      5#      5%      5&      5'      .��5(      �  � RowDefinitions 5)   
   �� 5*      $��7* �6   �� 5+      $	��93* �6   .+�5.   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5/         GUITools.CustomTextEdit    textInputField#��[ 6    ��.  $��3q�50          GUITools.CustomInput   LabelHeight$ 15Q�6t      
LabelWidth$ 45Q�6�      ContentWidth$	 165Q�51          ContentHeight$ 15Q�63      HorizontalLabel .    VerticalLabel .     Text 50   +   ��  �� Path$ Search� �� Mode$ TwoWay=�   Label 6U   �� *SearchOption+ J� InputBindings 52      �� 53      
 �� Key$ Return��6!    �� Command 6.   �� *	CmdSearch+55      �� 56      $��Search��6   $��Stretch=�6D   $��5,0,0,0q�57      $
��Bold"�6&   ��56   &   �� *	CmdSearch+57   &      GUITools.CustomComboEdit  58        comboInputField#��[ 6!   ��.  $��3q�59   !   $ Search Options��6,   $ 15Q�6C   $ 90Q�6T   $ 60Q�5:   T      ItemsSource 59   d   �� *SearchOptions+   SelectedItem 5:   !   �� *SearchOption+$ TwoWay=�6T   �� 5;      $��Bulk Update��6   $��5,0,0,0q�6+   $
��Bold"�6^   $��80��5<      $��Stretch=�6#   ��5;   <   �� *CmdBulkUpdate+5<   #   � 5=      $��Right=�6   $	��380��6/   .+�5>      �� $
��Save��6   $��5,0,0,0q�6(   $
��Bold"�6U   $��60��5?      $��Right=�6#   ��5>   9   �� *	CmdSave+5?   #   5@      5A      �� 5B   
   $��1��6   $ Vertical=�6"   $��Stretch=�69   .+�5C      �� -   5          ��Name$  DistributorsListBox��5D      $	��500��5C      #��[ 6S   #��[ 5D   4   ��5C   '   �� *DistributorDataList+��5E      �� 5F      .R�5G      � ! � ColumnDefinitions! 5H      �� 5I   "   $	��10* �63   �� 5J   "   $	��40* �63   �� 5K   "   $	��40* �63   .+�5M      �� $��0,0,0,1q�6%   
���   �$��0��6S   ._�5N   "   �  5O   &   �� 5P   *   $��5* �68   �� 5Q   *   $	��95* �68   .+�5S   &   �� #��[ 60   $	��UPC��6^   $��0��6i   
�������$��Stretch=�5T   C   " �� TextAlignment$" Center=�6a   �� 5U   &   $��0��60   $��Center=�6U   $��Center=�5V   0   $��1��6K   ��5U   @   �� *UPC+5V   K   5W   #   5X      �� 5Y      $��1,1,1,1q�6%   $��1��6?   ._�5Z   "   �  5[   &   �� 5\   *   $��5* �68   �� 5]   *   $	��95* �68   .+�5_   &   �� #��[ 60   $��Marketplace Data��6^   $��0��6v   
�������$��Stretch=�5`   C   $" Center=�6a   &   System.Windows.Controls.DataGrid  5a   &   $��
marketData��6/   $��1��6A   $��14(�5b   |   $��1��5c   /   #   AutoGenerateColumns# .  $   CanUserAddRows$ .  ��5b   /   �� *MarketplaceData+% �� UpdateSourceTrigger$% PropertyChanged=�    GUITools.DataGridExtension&   Columns& 5c   <   �� *MarketplaceDataColumns+5d   K   5f   #   5g      �� 5h      $��1,1,1,1q�6%   $��2��6?   ._�5i   "   �  5j   &   �� 5k   *   $��5* �68   �� 5l   *   $	��95* �68   .+�5n   &   �� #��[ 60   $��Distributor Data��6^   $��0��6v   
�������$��Stretch=�5o   C   $" Center=�6a     5p   &   $��distributorData��6/   $��1��6F   $��14(�5q   u   $��1��5r   /   # .  $ .  ��5q   /   �� *
DistData+$% PropertyChanged=�& 5r   <   �� *DistributorDataColumns+5s   K   5t   #   5u      5w      5x      5z      5{      5|      5}      