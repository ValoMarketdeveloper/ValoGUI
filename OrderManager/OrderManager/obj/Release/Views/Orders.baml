   M S B A M L   `   `   `  ���� C  ?GUITools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:GUITools;assembly=GUIToolsGUITools  G COrderManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:OrderManager.ViewsOrderManager.Views    OrderManager.Views.Orders   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7gt(clr-namespace:GUITools;assembly=GUITools     a ]DevExpress.Xpf.Core.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  Bsi9http://schemas.microsoft.com/expression/2010/interactions  Bei9http://schemas.microsoft.com/expression/2010/interactions  ,local clr-namespace:OrderManager.Views    � Title$  Orders��$	��900��$
��1450�� � 	Resources    
customBlue �� A �� R �� G �� B  customBlueBrush �� Color  customBlueBrushOpacity �� Opacity �� 
TargetType  	baseStyle	 �� Property
 �� Value �� BasedOn �� Triggers P� Property P� Value  noStyleToListboxItem �� 
TargetType��%M  &	        &	 +     7   &	 5     &	 U     '�� x     7  '�� �     7  '�� �     7  '�� �     7  &	 �     �� $	 255��$ 54��$ 95��$	 177���� 8   �� $ 	LightGray��$
 0.11Q��� " ��.��� 	 � ��$
 12(��� " ��8   �� " ��8   �� " ��8   �� " ��8    P�  � {� . . ��� 	 � ��

 ��ح��� " ��.��� 	 �@J�SnapsToDevicePixels
 . �� 	 �@�OverridesDefaultStyle
 . �� 	 �@�FocusVisualStyle
 Z� �� 	 � ��$
 Stretch=��� 	 � ��$
 12(��� 	 � ��$
 20���� 	 � ��
 �� " ��.R��� ._��� .���  � ShowGridLines .  $��Stretch=� � RowDefinitions �� $��7* ��� $	��93* �.+��� $��0�� �� Orientation$ 
Horizontal=�.+�   GUITools.CustomComboEdit    comboInputField#��[ ��.     DisplayMember$ 	StateName��   GUITools.CustomInput   Label$ 
OrderState��   LabelHeight$ 15Q�   
LabelWidth$ 70Q�   ContentWidth$ 90Q�$��Bottom=�   ContentHeight$ 30Q�   ItemsSource �� *States+   SelectedItem �� *SelectedState+ �� Mode$ TwoWay=��  �� �� .+��� $��0��$��Show All��$��15(�$��Center=�$��Bottom=� d� 	IsChecked �� *	ShowAll+���� *
CmdShowAll+�� $��1��$ 
Horizontal=�.+��� $��<-��$��Bottom=����� *CmdPrevPage+�� $��20(�$
��Bold"�$��	10,0,10,0q�$��Bottom=����� *
OrderCount+�� $��->��$��Bottom=����� *CmdNextPage+�� $��15(�$	��250��$��Bottom=�$��30��$��5,0,5,0q�����  �� Path$ Search�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   Triggers '  !DevExpress.Mvvm.UI.EventToCommand      PassEventArgsToCommand$
  TrueX��  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]!   	EventName$! KeyDown��+  %DevExpress.Mvvm.UI.EventToCommandBase"   Command" �� *	CmdSearch+.���  �� �� .+�  $��0��#��[ ��.  $ DistributorName��$ Distributors��$ 15Q�$ 70Q�$ 30Q�$ 70Q�$��Bottom=� �� *DistributorList+ �� *SelectedDistributorShipBy+$ TwoWay=�(  "System.Windows.Controls.DatePicker  $��1��$��Center=�$��Bottom=�$��30��#   SelectedDate# �� *
DtShipBy+   $
  TrueX�$! CalendarClosed��" �� *CmdShipByMouseDn+� $��Right=�$��70��.+��� $
��Save��$��5,0,3,0q�$��30��$��60��$��Right=�$��Bottom=����� *	CmdSave+� $��Center=�$��70��.+��� $��CCInventory��$��5,0,5,0q�$��30��$��60��$��Center=�$��Bottom=����� *CmdCCInventroy+�  �� �� .+��� $��0��$��From:��$��5,0,5,0q�  $��1��$��Center=�# �� *DtFrom+�  �� �� .+��� $��0��$	��To:��$��5,0,5,0q�  $��1��$��Center=�# �� *DtTo+  #��[ ��.  $��3q�$ Market��$ 10Q�$ 55Q�$ 85Q�$ 30Q�$��Bottom=�$��10(� �� *
MarketList+ �� *SelectedMarket+$ TwoWay=��� $��Report��$��Bottom=�$��Center=�$��0,0,0,5q�$��27��$��50������ *CmdTrackingReport+� $��Right=�$	��300��$ � ColumnDefinitions$ �� �� �� .+�  $��0��#��[ ��.  $ DistributorName��$ Distributors��$ 15Q�$ 90Q�$ 30Q�$ 90Q�$��Bottom=� �� *DistributorList+ �� *SelectedDistributor+$ TwoWay=��� $��1��$��Download��$��70��y��� *ShowDistButtons+  	boolToVis% �� 	Converter#% [ ���� *CmdDownload+�� $��2��$��Archive��$��70��y��� *ShowDistButtons+#% [ ���� *
CmdArchive+{��� *
CanArchive+�� $��1��$ Vertical=�$��Stretch=�$��Stretch=�.+�   GUITools.FlashMessage  $��Center=�$
��Bold"�$��16(�&   FadesOutAutomatically& . '   Message' �� *FlashMessage+$ TwoWay=�(   MessageType( �� *SelectedMessageType+�� -   ) ��Name$) DistributorsListBox��#��[ $	��750��#��[ $��Stretch=���.  $��0,2,2,2q����� *OrderDataList+���� .R�� $ �� $	��40* ��� $	��60* � �� $	��70* ��� $	��30* �.+��� $��0,0,0,0q�
���   �$��0��$��0��$��0,5,0,5q�._�� $ �� �� .+��� $��0,0,1,0q�
���   �$��0��._�� $��0�� �� $	��15* ��� $	��10* ��� $	��10* ��� $	��55* �$ �� �� .+��� $��Center=�* �� 
IsReadOnly* . $
��Bold"�$��2��$��0��$��0������ *CustInfo.OrderID+� $��1��$ �� �� .+��� $��Ordered:��$
��Left=�$��0��$��14(�$��10,0,0,0q��� $��Center=�$��1��$��14(����� *	Ordered+� $��2��$ �� �� .+��� $��Ship By:��$
��Left=�$��0��$��14(�$��10,0,0,0q��� $��Center=�$��1��$��14(�$
��Bold"����� *ShipBy+�� $��0��$��3��$��25��$��Center=����� *MarketPlaceImage+� $��1��$��1��$��10,0,0,0q�
�������$��2��y��� *OrdInfo.ShowDistributor+#% [ $ �� $	��60* ��� $	��10* ��� $	��30* � �� �� .+��� $��Right=�$��0��$��0��$
��Bold"�$��25,0,0,0q�$��16(����� *OrdInfo.DistributorName+y��� *OrdInfo.ShowDistributor+#% [ �� $��-��$��1��$��0��$
��Bold"�$��Center=�$��16(�y��� *OrdInfo.ShowDistributor+#% [ �� $
��Left=�$��2��$��0,0,40,0q�$��0��$
��Bold"�$��16(����� *OrdInfo.ProcessingTime+y��� *OrdInfo.ShowDistributor+#% [ �� $��Center=�$��5,0,0,0q�$��0��$��1��$��3��$
��Bold"�$��16(����� *OrdInfo.DistPriceDisplay+y��� *OrdInfo.ShowDistributor+#% [ �� $��1,0,0,0q�
���   �$��1��._��  �� �� �� �� �� �� $ �� �� .+�� $��0��$��0��$��2��$ �� $	��70* ��� $	��30* � �� �� �� �� �� �� .+��� $��Center=�$
��Bold"�$��Center=�$��0��$��0������ *CustInfo.Name+���� *DataContext.CmdEditAddress++ �� RelativeSource+ �� *FindAncestor+, �� AncestorType", ����� *
CustInfo+�� $��@��$��1��$��0��$��2��$��45��$��25��$��0,0,0,10q����� *
CmdEmail+���� *CustInfo.Email+�� $��1��$��2��$��2��$��Center=�$
��Bold"�$��45��$��45��$��Center=�- �� Padding$- 15q����� *CustInfo.State+ . �� Binding/ �� Value��%�   '��       �� " �� �� . �� *CustInfo.International+/ True.a��� 	 � ��

 � ����� 	 � ��

 ������� . �� *CustInfo.International+	/ False.a��� 	 � ��

 � � ��� 	 � ��

 ������� $��2��$��0��$��RightToLeft=�$
��Left=�$��2,0,0,0q� �� *OrdInfo.IsFood+���� *	CmdIsFood+.���� $��LeftToRight=�$��Is Food��$
��Bold"�$��5,0,0,0q�0 � LayoutTransform0 �� 1 �� ScaleX$	1 1.3Q�2 �� ScaleY$	2 1.3Q�� $��3��$��0��$��0,2,0,2q�$ �� $	��20* ��� $	��80* �.+��� $��0��$	��SKU��$
��Bold"�$��2,5,0,0q��� $��1��* . 
3 � Tag$	3 SKU������ *Details.IDFontWeight+���� *Details.SKU+���� *Details.IDColor+.��   $
  TrueX�$! KeyDown��" �� *DataContext.CmdSearchByID++ �� *FindAncestor+", �.��� $��4��$��0��$��0,2,0,2q�$ �� $	��20* ��� $	��80* �.+��� $��0��$	��UPC��$
��Bold"�$��2,5,0,0q��� $��1��* . $	3 UPC������ *Details.IDFontWeight+���� *Details.UPC+���� *Details.IDColor+.��   $
  TrueX�$! KeyDown��" �� *DataContext.CmdSearchByID++ �� *FindAncestor+", �.��� $��5��$��0��$��0,2,0,2q�$ �� $	��20* ��� $	��80* �.+��� $��0��$
��ASIN��$
��Bold"�$��2,5,0,0q��� $��1��* . $
3 ASIN������ *Details.IDFontWeight+���� *Details.ASIN+���� *Details.IDColor+.��   $
  TrueX�$! KeyDown��" �� *DataContext.CmdSearchByID++ �� *FindAncestor+", �.���� $��1,0,1,0q�
���   �$��1��$��0��._��  .  $ �� $	��25* ��� $	��25* ��� $	��25* ��� $	��25* �.+��� $��0��
�������$��Stretch=����� *Details.CmdProductDetails+.��(� 4 (� Stretch$
4 None=�$	��200��$	��100��.���� $	��200��$	��100������ *Details.Picture+�� $��Title��$��Center=�$��1��5 �� TextWrapping$
5 Wrap=�$	��200��$
��Bold"�$��16(����� *OrdInfo.Title+$ PropertyChanged=�.��   $
  TrueX�$! KeyDown��" �� *DataContext.CmdTrackingNumber++ �� *FindAncestor+", �.��� $��2��$ �� �� �� .+�� $��0�� �� �� �� .+��� $��1q�
���   �$��35��$��50��$
��Left=�$	��Top=�._��� $��0��6 �� TextAlignment$6 Center=�$��50��$��35��$
��Bold"�$��18(����� *Details.Qty+���� *Details.QtyColor+�� $��1��
��� ���
�������$��Center=�$6 Center=�$��60��$��18(����� *OrdInfo.OrderItemsTitle+y��� *OrdInfo.ShowOrderItems+#% [ �� $��	MasterQty��$��2��$��18(�$
��Bold"�$
��Left=�$��35��$��50��
���   �$��Center=�$��Center=����� *OrdInfo.MasterQty+$ PropertyChanged=�.��   $
  TrueX�$! KeyDown��" �� *DataContext.CmdTrackingNumber++ �� *FindAncestor+", �.��� $��1��$��0�� .   �� �� �� .+�� $��0�� �� �� $ �� �� .+��� $��0��$��0��$	��LP:��
����  �$
��Bold"�$��5,0,0,0q�$��16(��� $��1��$��0��$��5,0,0,0q�$
��Bold"�$��16(����� *OrdInfo.Price+�� $��0��$��1��$��5,0,0,0q�$	��SP:��
����  �$
��Bold"�$��16(��� $��1��$��1��$��5,0,0,0q�$
��Bold"�$��16(����� *OrdInfo.ShipPrice+�� $��1��
���   �$��Stretch=�7 �� StrokeDashArray$	7 2 2R�	8 �� X1$8 0��$��2��$	��Top=�	9 �� X29 �� *ActualWidth++ �� *Self+�� $��1��$��2��$��Center=�$
��Bold"�$��14(����� *OrdInfo.TotalPrice+�� $��2��$��0��$��2��
��� � �$��Stretch=�$	7 2 2R�$8 0��$��2��$	��Top=�9 �� *ActualWidth++ �� *Self+�� $��2��$��0��$��2��$6 Center=�$
��Bold"�$��16(�$��0,0,0,30q����� *OrdInfo.ProfitNumber+���� " �� �� . �� *OrdInfo.Profit+/ True.a��� 	 � ��

 � � ��� . �� *OrdInfo.Profit+	/ False.a��� 	 � ��

 �  ��� $��3�� .   �� $	��15* ��� $	��85* �.+��� $��Distributors��$��0��$��45��$	��Top=����� *DataContext.CmdDistributors++ �� *FindAncestor+", ����� *	Details+�� $) distributorsListBox��$��Stretch=�: J� SnapsToDevicePixels: . #��[ $��Stretch=�$��1������ *Details.ListDistributors+; �� SelectedItem; �� *
Selected+���� .R�� $ �� �� �� �� .+��� $��14(�$��0��$��50��$��0,3,0,0q����� *Name+ �� + �� *FindAncestor+", ��$ 
IsSelected��� $��14(�$��1��$��50��$��Right=�$	��5,0q����� *Price+�� $��14(�$��2��$��50��$��Right=�$	��5,0q����� *Qty+�� $��14(�$��3��$��Right=�* . $	��5,0q����� *DistributorProductID+�� $��0,0,0,0q�$��1��$��0��$��2��$��0,3,0,3q�._�� ���� *StatusColor+$ �� �� �� .+��� $��2��
���   �$��1q�$	��600��._�� $ �� $	��15* ��� $	��60* ��� $	��10* ��� $	��15* �.+��� $��
Tracking #��$��0���� $��TrackingNumber��$��1������ *OrdInfo.TrackingNumber+$ PropertyChanged=�.��   $
  TrueX�$! KeyDown��" �� *DataContext.CmdTrackingNumber++ �� *FindAncestor+", �.���� $��Carrier��$��2���� $��3����.  < �� DisplayMemberPath$< Display������ *DataContext.CarrierList++ �� *FindAncestor+", �; �� *OrdInfo.ShippingCarrier+�� -   $��	100,0,0,0q���.  $	��190��$��1��$
��Left=����� *DataContext.StatesList++ �� *FindAncestor+", �; �� *SelectedStatus+$ TwoWay=��� $��0��
���   �$��1q�$	��600��._�� $ �� $	��20* ��� $	��80* �.+��� $��	Notes ...��$��0���� $��Notes��$��1��$��16(����� *OrdInfo.Notes+$ PropertyChanged=�.��   $
  TrueX�$! KeyDown��" �� *DataContext.CmdTrackingNumber++ �� *FindAncestor+", �.��