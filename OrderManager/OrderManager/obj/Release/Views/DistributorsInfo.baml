   M S B A M L   `   `   `  ���� G  COrderManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:OrderManager.ViewsOrderManager.Views  )    #OrderManager.Views.DistributorsInfo   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:OrderManager.Views       � Title$  DistributorsInfo��$	��500��$	��600��.���  � RowDefinitions �� $	��15* ��� $	��85* �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $��UPC: ��$��Center=�$��14(�$
��Bold"��� $��Center=�$��14(�$
��Bold"����� *UPC+�� $��1��
���   �$��1q�._��� -   $��lbDistributorsInfo��$��Stretch=�$��Visible=����� *ListDistributors+���� .R�]� ��. .+�� $	��Top=�$��30�� � ColumnDefinitions �� $	��350 ��� $	��350 ��� $	��100 ��� $	��100 �.+��� $��0��$
��Bold"�$��14(�.��Distributor�� $��1��$
��Bold"�$��14(�.��Description�� $��2��$
��Bold"�$��14(�.��UOM�� $��3��$
��Bold"�$��14(�.��
Dimentions�� ���� .R�� $	��0,2q� �� $	��350 ��� $	��350 ��� $	��100 ��� $	��100 �.+�� $��0�� �� �� �� .+��� $��0������ *ProductInfo+�� $��1��$
��Wrap=����� *Vendor+�� $��2������ *ProdID+� $��1�� �� �� .+��� $��0��$
��Wrap=����� *Title+�� $��1��$
��Wrap=����� *Description+� $��2�� �� �� .+��� $��0������ *	UOMDesc+�� $��1������ *
SizeDesc+�� $��3������ *
WeightDesc+