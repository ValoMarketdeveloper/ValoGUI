   M S B A M L   `   `   `  ���� C  ?GUITools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:GUITools;assembly=GUIToolsGUITools  B >Updater, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UpdaterUpdater    Updater.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7gt(clr-namespace:GUITools;assembly=GUITools     'localclr-namespace:Updater       � Title$  
MainWindow��$	��550��$
��1375�� � 	Resources    
customBlue �� A �� R �� G �� B  customBlueBrush �� Color  customBlueBrushOpacity �� Opacity  noStyleToListboxItem �� 
TargetType	 �� Property
 �� Value �� 
TargetType��%M  &	        &	 +     7   &	 5     &	 U     �� $	 255��$ 54��$ 95��$	 177���� 8   �� $ 	LightGray��$
 0.11Q��� " ��.��� 	 �@J�SnapsToDevicePixels
 . �� 	 �@�OverridesDefaultStyle
 . �� 	 �@�FocusVisualStyle
 Z� �� 	 � ��$
 Stretch=��� 	 � ��
 �� " ��.R��� ._��� .���  � RowDefinitions �� $��7* ��� $	��93* �.+��� $��0�� �� Orientation$ 
Horizontal=�.+�   GUITools.CustomTextEdit    textInputField#��[ ��.  $��3q�   GUITools.CustomInput   LabelHeight$ 15Q�   
LabelWidth$ 45Q�   ContentWidth$	 165Q�   ContentHeight$ 15Q�   HorizontalLabel .    VerticalLabel .     Text ��  �� Path$ Search� �� Mode$ TwoWay=�   Label �� *SearchOption+   GUITools.CustomComboEdit    comboInputField#��[ ��.  $��3q�$ Search Options��$ 15Q�$ 90Q�$ 60Q�   ItemsSource �� *SearchOptions+   SelectedItem �� *SearchOption+$ TwoWay=��� $	��...��$��Center=�$��Stretch=�$��Center=�$	��Top=�$
��Bold"����� *	CmdSearch+�� $
��Save��$��5,0,0,0q�$
��Bold"�$��60��$��Stretch=����� *	CmdSave+�� $��Bulk Update��$��5,0,0,0q�$
��Bold"�$��80��$��Stretch=����� *CmdBulkUpdate+�� $��1��$ Vertical=�$��Stretch=�.+��� -    ��Name$ DistributorsListBox��$	��500��#��[ #��[ ���� *DistributorDataList+���� .R��  � ColumnDefinitions �� $	��10* ��� $	��40* ��� $	��40* �.+��� $��0,0,0,1q�
���   �$��0��._��  �� $��5* ��� $	��95* �.+��� #��[ $	��UPC��$��0��
�������$��Stretch=� �� TextAlignment$ Center=��� $��0��$��Center=�$��Center=�$��1������ *UPC+�� $��1,1,1,1q�$��1��._��  �� $��5* ��� $	��95* �.+��� #��[ $��Distributor Data��$��0��
�������$��Stretch=�$ Center=�&   System.Windows.Controls.DataGrid  $��distributorData��$��1��$��12(�$��1��   AutoGenerateColumns .     CanUserAddRows .  ���� *
DistData+ �� UpdateSourceTrigger$ PropertyChanged=�    GUITools.DataGridExtension    Columns  �� *DistributorDataColumns+�� $��1,1,1,1q�$��2��._��  �� $��5* ��� $	��95* �.+��� #��[ $��Marketplace Data��$��0��
�������$��Stretch=�$ Center=�  $��
marketData��$��1��$��12(�$��1�� .   .  ���� *MarketplaceData+$ PropertyChanged=�  �� *MarketplaceDataColumns+