   M S B A M L   `   `   `  ����C  ?GUITools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:GUITools;assembly=GUIToolsGUITools  5   	   B >Updater, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UpdaterUpdater 5   	      Updater.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7gt(clr-namespace:GUITools;assembly=GUITools     5   	   'localclr-namespace:Updater     5   	     � Title$  
MainWindow��5	   	   $	��550��6   $
��1375��6)    � 	Resources 5
         
customBlue �� A �� R �� G �� B  customBlueBrush �� Color  customBlueBrushOpacity �� Opacity  noStyleToListboxItem �� 
TargetType	 �� Property
 �� Value �� 
TargetType��%1  &	        &	 H     7   &	 `     &	 �     �� 5   
   $	 255��6$   $ 54��6.   $ 95��65   $	 177��6<   �� 5   
   8   6X   �� 5   
   $ 	LightGray��69   $
 0.11Q�6K   6\   �� 5   
   " ��6-   .�5      �� 	 �@J�SnapsToDevicePixels
 . 64   �� 5      	 �@�OverridesDefaultStyle
 . 66   �� 5      	 �@�FocusVisualStyle
 61   Z� �� 5      	 � ��$
 Stretch=�64   �� 5      	 � ��
 5      �� 5      " ��6&   .R�5      �� ._�5      �� 61   5      5      5      5      5      .��5      �  � RowDefinitions 5    
   �� 5!      $��7* �6   �� 5"      $	��93* �6   .+�5%   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5&         GUITools.CustomTextEdit    textInputField#��[ 6    ��.  $��3q�5'          GUITools.CustomInput   LabelHeight$ 15Q�6t      
LabelWidth$ 45Q�6�      ContentWidth$	 165Q�5(          ContentHeight$ 15Q�63      HorizontalLabel .    VerticalLabel .     Text 5'   +   ��  �� Path$ Search� �� Mode$ TwoWay=�   Label 6U   �� *SearchOption+5(   ]      GUITools.CustomComboEdit  5)        comboInputField#��[ 6!   ��.  $��3q�5*   !   $ Search Options��6,   $ 15Q�6C   $ 90Q�6T   $ 60Q�5+   T      ItemsSource 5*   d   �� *SearchOptions+   SelectedItem 5+   !   �� *SearchOption+$ TwoWay=�6T   �� 5,      $	��...��6   $��Center=�6A   $��Stretch=�6\   $��Center=�5-      $	��Top=�69   $
��Bold"�6Y   ��5,   #   �� *	CmdSearch+5-   Y   �� 5.      $
��Save��6   $��5,0,0,0q�6$   $
��Bold"�6Q   $��60��5/      $��Stretch=�6#   ��5.   5   �� *	CmdSave+5/   #   �� 50      $��Bulk Update��6   $��5,0,0,0q�6+   $
��Bold"�6^   $��80��51      $��Stretch=�6#   ��50   <   �� *CmdBulkUpdate+51   #   52      �� 53   
   $��1��6   $ Vertical=�6"   $��Stretch=�69   .+�54      �� -   5         ��Name$ DistributorsListBox��55      $	��500��54      #��[ 6S   #��[ 55   4   ��54   '   �� *DistributorDataList+��56      �� 57      .R�58      �  � ColumnDefinitions 59      �� 5:   "   $	��10* �63   �� 5;   "   $	��40* �63   �� 5<   "   $	��40* �63   .+�5>      �� $��0,0,0,1q�6%   
���   �$��0��6S   ._�5?   "   �  5@   &   �� 5A   *   $��5* �68   �� 5B   *   $	��95* �68   .+�5D   &   �� #��[ 60   $	��UPC��6^   $��0��6i   
�������$��Stretch=�5E   C    �� TextAlignment$ Center=�6a   �� 5F   &   $��0��60   $��Center=�6U   $��Center=�5G   0   $��1��6K   ��5F   @   �� *UPC+5G   K   5H   #   5I      �� 5J      $��1,1,1,1q�6%   $��1��6?   ._�5K   "   �  5L   &   �� 5M   *   $��5* �68   �� 5N   *   $	��95* �68   .+�5P   &   �� #��[ 60   $��Distributor Data��6^   $��0��6v   
�������$��Stretch=�5Q   C   $ Center=�6a   &   System.Windows.Controls.DataGrid  5R   &   $��distributorData��6/   $��1��6F   $��12(�5S   u   $��1��5T   /      AutoGenerateColumns .     CanUserAddRows .  ��5S   /   �� *
DistData+ �� UpdateSourceTrigger$ PropertyChanged=�    GUITools.DataGridExtension    Columns  5T   <   �� *DistributorDataColumns+5U   K   5V   #   5W      �� 5X      $��1,1,1,1q�6%   $��2��6?   ._�5Y   "   �  5Z   &   �� 5[   *   $��5* �68   �� 5\   *   $	��95* �68   .+�5^   &   �� #��[ 60   $��Marketplace Data��6^   $��0��6v   
�������$��Stretch=�5_   C   $ Center=�6a     5`   &   $��
marketData��6/   $��1��6A   $��12(�5a   |   $��1��5b   /    .   .  ��5a   /   �� *MarketplaceData+$ PropertyChanged=�  5b   <   �� *MarketplaceDataColumns+5c   K   5d   #   5e      5g      5h      5j      5k      5l      5m      