   M S B A M L   `   `   `  ���� C  ?GUITools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:GUITools;assembly=GUIToolsGUITools  G COrderManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:OrderManager.ViewsOrderManager.Views $   OrderManager.Views.CCInventory   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7gt(clr-namespace:GUITools;assembly=GUITools     a ]DevExpress.Xpf.Core.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  Bsi9http://schemas.microsoft.com/expression/2010/interactions  Bei9http://schemas.microsoft.com/expression/2010/interactions  ,local clr-namespace:OrderManager.Views    � Title$  CCInventory��$	��500��$	��900�� � 	Resources    numberHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value��%I   &	        �� "  .���  � ��$ Stretch=���  � ��$	 100��.���  � RowDefinitions �� $��7* ��� $	��93* �.+�� $��	20,0,20,0q�$��0�� � ColumnDefinitions �� $	��15* ��� $	��10* ��� $	��40* ��� $	��10* ��� $��7* ��� $��8* ��� $	��10* �.+��� -   $	��UPC��$	��5,0q�$��0������ *UPC+ �� UpdateSourceTrigger$ PropertyChanged=�.��2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   Triggers '  !DevExpress.Mvvm.UI.EventToCommand  	   PassEventArgsToCommand$
	 TrueX��  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]
   	EventName$
 KeyDown��+  %DevExpress.Mvvm.UI.EventToCommandBase   Command �� *	CmdSearch+.���� $��1��$��Search������ *	CmdSearch+�� $��2��$	��5,0q�$	��200��$
��Wrap=�$��12(�$
��Bold"����� *Title+�� -   $��Price��$��3��$	��5,0q����� *Price+�� -   $	��Qty��$��4��$	��5,0q����� *Qty+�� -   $	��UOM��$��5��$	��5,0q����� *UOM+�� $��6��$	��Add������ *CmdAdd+����  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" �� $��1��$��0,10,0,0q�.+�&   System.Windows.Controls.DataGrid  -   $��	Inventory��$��1��   AutoGenerateColumns .  $	��800������ *CCInventoryList+$ PropertyChanged=�   ColumnHeaderStyle �� "  .���  � ��$
 Bold"���  � ��$ Stretch=���  � ��$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Title��   
IsReadOnly .    MaxWidth$	 250Q�1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Title+ 	  ElementStyle �� .���  � ��$
 Wrap=���  �@��TextAlignment$ Center=���  � ��$ 12(�4
  .System.Windows.Controls.DataGridTemplateColumn
  $ Image��   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells  .  
  CellTemplate �� .R��� $	��200��$	��100������ *URL+
  $	 UPC��   HeaderStyle# [   �� .R��� $��txtUPC��$��Center=� �� 
IsReadOnly . ���� *UPC+.��   $
	 TrueX�$
 KeyDown�� �� *CmdUPC+.��
  $ Price��# [   �� .R��� $��txtPrc��$��Center=����� *Price+.��   $
	 TrueX�$
 KeyDown�� �� *
CmdPrice+.��
  $	 Qty��# [   �� .R��� $��txtQty��$��Center=����� *Qty+.��   $
	 TrueX�$
 KeyDown�� �� *CmdQty+.��
   �� "  .���  � ��$ Stretch=���  � ��$	 100�� �� .R��� $��Stretch=�$��50��$��Center=����� *	CmdDelete+.��Delete