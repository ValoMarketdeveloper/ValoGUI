   M S B A M L   `   `   `  ���� C  ?GUITools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:GUIToolsGUITools  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   flashMessageErrorBackground  �� 
StartPoint �� EndPoint � Color � Offset ! flashMessageSuccessBackground   flashMessageNoticeBackground �� 
TargetType  flashMessageImageButton �� Property �� Value  flashMessageButton �� BasedOn  flashMessageErrorButton �� 
TargetType	 A�Name'   !System.Windows.VisualStateManager
    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty	 �� To g� Duration  flashMessageSuccessButton  flashMessageNoticeButton   GUITools.FlashMessage ��Name �� CornerRadius � ColumnDefinitions   ContentDataTemplate   Message ��Name � Cursor � ToolTip �� Triggers P� Property P� Value �� 
TargetName �� 	Resources  Key �� DataType �� Padding  g� FillBehavior! W� From	" W� To# �� KeyTime$ �� Value% �� Triggers& N� EnterActions�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml      localclr-namespace:GUITools  %�  &	        &	 �     &	 j    &	     &	 �    &	 1    7  7  &	 �    7  7  &	 -    7  7  '  �    7   7  7  7  7  7  �� $  0.5,0&�$ 0.5,1&�.��� $ 	#FFF2C6C6��� $ 	#FFEEA2A2��$ 1Q�� $ 	#FFF0B6B6��$ 0.487Q�� $ 	#FFF1BDBD��$ 0.228Q�� $ 	#FFEFABAB��$ 0.797Q��� $  0.5,0&�$ 0.5,1&�.��� $ 	#FF71F96C��� $ 	#FF96F696��$ 1Q�� $ 	#FF7BFF7C��$ 0.487Q�� $ 	#FF6AFF6A��$ 0.228Q�� $ 	#FF89FF89��$ 0.797Q��� $  0.5,0&�$ 0.5,1&�.��� $ 	#FFFDFEAD��� $ 	#FFF0F17F��$ 1Q�� $ 	#FFF6F797��$ 0.487Q�� $ 	#FFFAFBA3��$ 0.228Q�� $ 	#FFF3F48C��$ 0.797Q��� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$B <pack://application:,,,/GUITools;component/Images/close_8.png����  � ��$
 None=��� " ��.���  � ��$ 0,0,5,0q���  � ��$ 1q���  � ��$ 22����  � ��$ 22���� " ��8   .���  � �� �#E89D9D��  � �� �� " ��.R�� .+�A� $	 imageButtonBorder��
������ #��z��#��z���� 8�� 
   
Common��.   	MouseOver��. �� .���� $ imageButtonBorder��$ 
Fill.Color�$ #E89D9DX�$ 0:00:0.3D�  
Normal��. �� .���� $ imageButtonBorder��$ 
Fill.Color�$ TransparentX�$ 0:00:0.3D��� " ��8   .���  � �� �#52ED52��  � �� �� " ��.R�� .+�A� $	 imageButtonBorder��
������ #��z��#��z���� 8�� 
   
Common��.   	MouseOver��. �� .���� $ imageButtonBorder��$ 
Fill.Color�$ #52ED52X�$ 0:00:0.3D�  
Normal��. �� .���� $ imageButtonBorder��$ 
Fill.Color�$ TransparentX�$ 0:00:0.3D��� " ��8   .���  � �� �	#FFEEEF65��  � �� �� " ��.R�� .+�A� $	 imageButtonBorder��
������ #��z��#��z���� 8�� 
   
Common��.   	MouseOver��. �� .���� $ imageButtonBorder��$ 
Fill.Color�$ 	#FFEEEF65X�$ 0:00:0.3D�  
Normal��. �� .���� $ imageButtonBorder��$ 
Fill.Color�$ TransparentX�$ 0:00:0.3D��� "  .���  � y�$ 	Collapsed=���  � ��$ 40����  � �� .  ��  � |� .  ��  � ��$ 1q���  � ��$ 0,0,0,10q���  � �� �� "  .R��� $ PART_border��$ 2��#��z��#��z��._��  �� $��* ��� $��50 �.+��� $��0��#��z #��z �� $ PART_button��$��1��$
 Hand��$ Click to hide��$��Close�� P�  �@ MessageType$ Error=�. ��� $ PART_border��8    � ���� $ PART_button��8   � ��P�  �@ MessageType$ Success=�. ��� $ PART_border��8   � ���� $ PART_button��8   � ��P�  �@ MessageType$ Notice=�. ��� $ PART_border��8   � ���� $ PART_button��8   � �� ���� flashMessageTemplate $ string��.R��� $��16(�$��Italic$�$ 2q�$��Center=�$��Center=�$
��Bold"����� �� fadeOutAnimation .��W� $
  Stop=�$ Opacity�$	! 1.0X�$	" 0.0X�$ 0:0:1.3D��� $  (local:FlashMessage.Reset)�.p�s� $# 0:0:0��$ .  s� $# 0:0:1.3��$ . % P�  � y�$ Visible=�& �� .���� .��W� $ Opacity�$	! 0.0X�$	" 1.0X�$ 0:0:1.3D�