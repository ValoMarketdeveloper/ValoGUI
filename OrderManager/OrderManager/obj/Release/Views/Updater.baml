   M S B A M L   `   `   `  ���� C  ?GUITools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:GUITools;assembly=GUIToolsGUITools  G COrderManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:OrderManager.ViewsOrderManager.Views     OrderManager.Views.Updater   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7gt(clr-namespace:GUITools;assembly=GUITools     2local clr-namespace:OrderManager.Views       � Title$  Updater��$	��550��$
��1375�� � 	Resources    
customBlue �� A �� R �� G �� B  customBlueBrush �� Color  customBlueBrushOpacity �� Opacity �� 
TargetType	 �� Triggers
 P� Property P� Value �� Property �� Value  noStyleToListboxItem �� 
TargetType��%�  &	        &	 +     7   &	 5     '�� U     &	 �     �� $	 255��$ 54��$ 95��$	 177���� 8   �� $ 	LightGray��$
 0.11Q��� " ��	 P� 
 � {� . . ���  � ��
 ��ح��� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�FocusVisualStyle Z� ��  � ��$ Stretch=���  � ��$ 14(���  � ��$ 20����  � �� �� " ��.R��� ._��� .���  � RowDefinitions �� $��7* ��� $	��93* �.+��� $��0�� �� Orientation$ 
Horizontal=�.+�   GUITools.CustomTextEdit    textInputField#��[ ��.  $��3q�   GUITools.CustomInput   LabelHeight$ 15Q�   
LabelWidth$ 45Q�   ContentWidth$	 165Q�   ContentHeight$ 15Q�   HorizontalLabel .    VerticalLabel .     Text ��  �� Path$ Search� �� Mode$ TwoWay=�   Label �� *SearchOption+ J� InputBindings �� 
 �� Key$ Return�� �� Command �� *	CmdSearch+�� $��Search��$��Stretch=�$��5,0,0,0q�$
��Bold"����� *	CmdSearch+   GUITools.CustomComboEdit    comboInputField#��[ ��.  $��3q�$ Search Options��$ 15Q�$ 90Q�$ 60Q�   ItemsSource �� *SearchOptions+   SelectedItem �� *SearchOption+$ TwoWay=��� $��Bulk Update��$��5,0,0,0q�$
��Bold"�$��80��$��Stretch=����� *CmdBulkUpdate+� $��Right=�$	��380��.+��� $
��Save��$��5,0,0,0q�$
��Bold"�$��60��$��Right=����� *	CmdSave+�� $��1��$ Vertical=�$��Stretch=�.+��� -     ��Name$  DistributorsListBox��$	��500��#��[ #��[ ���� *DistributorDataList+���� .R�� ! � ColumnDefinitions! �� $	��10* ��� $	��40* ��� $	��40* �.+��� $��0,0,0,1q�
���   �$��0��._��  �� $��5* ��� $	��95* �.+��� #��[ $	��UPC��$��0��
�������$��Stretch=�" �� TextAlignment$" Center=��� $��0��$��Center=�$��Center=�$��1������ *UPC+�� $��1,1,1,1q�$��1��._��  �� $��5* ��� $	��95* �.+��� #��[ $��Marketplace Data��$��0��
�������$��Stretch=�$" Center=�&   System.Windows.Controls.DataGrid  $��
marketData��$��1��$��14(�$��1��#   AutoGenerateColumns# .  $   CanUserAddRows$ .  ���� *MarketplaceData+% �� UpdateSourceTrigger$% PropertyChanged=�    GUITools.DataGridExtension&   Columns& �� *MarketplaceDataColumns+�� $��1,1,1,1q�$��2��._��  �� $��5* ��� $	��95* �.+��� #��[ $��Distributor Data��$��0��
�������$��Stretch=�$" Center=�  $��distributorData��$��1��$��14(�$��1��# .  $ .  ���� *
DistData+$% PropertyChanged=�& �� *DistributorDataColumns+