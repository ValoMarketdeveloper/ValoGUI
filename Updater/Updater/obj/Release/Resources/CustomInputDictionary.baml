   M S B A M L   `   `   `  ���� F  BCommonTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CommonTools;assembly=CommonToolsCommonTools  C ?GUITools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:GUITools;assembly=GUIToolsGUITools R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089a ]DevExpress.Xpf.Core.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?   9DevExpress.Xpf.Core.BooleanToVisibilityConverterExtension   	boolToVis     Invert  invertBoolToVis  textInputField � ColumnDefinitions �� 
TargetType �� Triggers �� Binding �� RelativeSource �� AncestorType  GUITools.CustomTextEdit �� Value �� Property	 �� Value
 �� Mode � RowDefinitions � DataContext%  DevExpress.Xpf.Editors.TextEdit  Name%  DevExpress.Xpf.Editors.BaseEdit   
IsReadOnly)  #DevExpress.Xpf.Editors.TextEditBase   Text �� UpdateSourceTrigger � ToolTip  validatedTextInputField �� Orientation-  'System.Windows.Input.KeyboardNavigation   	IsTabStop �� Path �� 	Converter $  validatedEnhancedComboInputField  GUITools.CustomComboEdit#  GUITools.EnhancedComboBoxEdit  Name   AllowUpdateOnPopupClosed+  %DevExpress.Xpf.Editors.LookUpEditBase   ItemsSource   	EditValue'	  !DevExpress.Xpf.Editors.ButtonEdit 	  IsTextEditable   DisplayMember ! validatedDoubleTextInputField#
  GUITools.CustomDoubleTextEdit  passwordInputField,  &DevExpress.Xpf.Editors.PasswordBoxEdit  Name  validatedPasswordInputField  numberTextInputField   MaskType   MaskShowPlaceHolders   MaskAutoComplete    Mask#  GUITools.CustomNumberTextEdit !	 validatedNumberTextInputField 
 doubleTextInputField  comboInputField)  #DevExpress.Xpf.Editors.ComboBoxEdit!  Name"   SelectedItem - )enhancedComboCustomItemTemplateInputField#   ItemTemplate  enhancedComboInputField * &validatedcomboWithCheckboxesInputField$ �� Mode
% � Tag& 	  ShowEditorButtons'   StyleSettings3  -GUITools.EnhancedCheckedComboBoxStyleSettings2  ,DevExpress.Mvvm.UI.Interactivity.Interaction(   Triggers'  !DevExpress.Mvvm.UI.EventToCommand)   PassEventArgsToCommand�  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]*   	EventName+  %DevExpress.Mvvm.UI.EventToCommandBase+   Command ! comboWithCheckboxesInputField  dateTimeInputField  GUITools.CustomInput,   MaskUseAsDisplayFormat  GUITools.CustomDateEdit-   NullText " dateTimeWithCalendarInputField%  DevExpress.Xpf.Editors.DateEdit.  Name&   DevExpress.Xpf.Core.ThemeManager/   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter ) %dateTimeWithCalendarAndTimeInputField  GUITools.DateTimeEdit0  Name1   IsShowTimePanel  checkboxInputField&   DevExpress.Xpf.Editors.CheckEdit2   	IsChecked  GUITools.CustomCheckEdit�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5ct.clr-namespace:CommonTools;assembly=CommonTools  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  /gt(clr-namespace:GUITools;assembly=GUITools  :dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  ?dxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  %2`  &	        &	      &	      &	 "    7   &	 �    7   &	 =    7   &	 �    &	     7   &	 �    &		 �'    7   &	
 Y1    &	 �4    &	 �6    &	 �8    &	 FA    7   &	 �I    7   7  &	 �N    &	 DQ    7   7  &	 �X    &	 �Z    7   7        .       . �� .R�� $��Stretch=� �� ���� " �� ��  �� *HorizontalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *HorizontalLabel+ �� "   True.a���  � ��	 �� *
LabelWidth+ �� $
 FindAncestor=�"  �� ���� " �� ��  �� *HorizontalLabel+ �� "   True.a���  � ��	 �� *ContentWidth+ �� $
 FindAncestor=�"   �� ���� " �� ��  �� *VerticalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *LabelHeight+ �� $
 FindAncestor=�"  �� ���� " �� ��  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *ContentHeight+ �� $
 FindAncestor=�"  .+��� $��0��$��1����.  $��23������ *Label+ �� $
 FindAncestor=�"  ���� *
LabelWidth+ �� $
 FindAncestor=�"  �� $��1��$��0����.  ���� *Label+ �� $
 FindAncestor=�"  ���� *
LabelWidth+ �� $
 FindAncestor=�"  ���� *LabelHeight+ �� $
 FindAncestor=�"  �� $��1��$��1��$
��Left=���.   ��  �� $
 FindAncestor=�"  ���� " �� ��  �� *IsRequiredField+ �� "  	 False.a���  � ��	 �� .R�  $ 	textInput��$��1��$
��Left=���. ���� *ContentWidth+ �� $
 FindAncestor=�"   �� *
IsReadOnly+ �� $
 FindAncestor=�"   �� *Text+$ PropertyChanged=� �� $
 FindAncestor=�"   �� *	ErrorText+ �� "  ��  �� *IsRequiredField+ �� "   True.a���  � ��	 �� .R��� 
���  ��$��2q�._�  $ 	textInput��$��1��$
��Left=���. ���� *ContentWidth+ �� $
 FindAncestor=�"  ���� *ContentHeight+ �� $
 FindAncestor=�"   �� *
IsReadOnly+ �� $
 FindAncestor=�"   �� *Text+$ PropertyChanged=� �� $
 FindAncestor=�"   �� *	ErrorText+ �� "  �� .R�� $��Stretch=� �� ���� " �� ��  �� *HorizontalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *HorizontalLabel+ �� "   True.a���  � ��	 �� *
LabelWidth+ �� $
 FindAncestor=�"  �� $��* � �� ���� " �� ��  �� *VerticalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *LabelHeight+ �� $
 FindAncestor=�"  �� ���� " �� ��  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *ContentHeight+ �� $
 FindAncestor=�"  .+��� $��0��$��1��$��23����.  ���� *Label+ �� $
 FindAncestor=�"  �� $��1��$��0����.  ���� *Label+ �� $
 FindAncestor=�"  �� $ 
Horizontal=�$��1��$��1�� .  .+�  $ 	textInput��$
��Left=���. ���� *ContentWidth+ �� $
 FindAncestor=�"   �� *
IsReadOnly+ �� $
 FindAncestor=�"   �� *Text+$ PropertyChanged=� �� $
 FindAncestor=�"   �� $
 Text� �� *Self+�� $��10(�$��5,0,0,0q�$��Center=� .  y��� *IsValidationVisible+ �� $
 FindAncestor=�"  8   ���� " �� ��  �� *	IsValid+ �� $
 FindAncestor=�"   RequiredAndEmpty.a���  � ��$	 *����  � ��$	 12(���  �� *	IsValid+ �� $
 FindAncestor=�"  	 Valid.a���  � ��$		 ✓����  � ��$	 10(���  �� *	IsValid+ �� $
 FindAncestor=�"   Invalid.a���  � ��$		 ✗����  � ��$	 10(��� .R�� $��Stretch=� �� ���� " �� ��  �� *HorizontalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *HorizontalLabel+ �� "   True.a���  � ��	 �� *
LabelWidth+ �� $
 FindAncestor=�"  �� $��* � �� ���� " �� ��  �� *VerticalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *LabelHeight+ �� $
 FindAncestor=�"  �� ���� " �� ��  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *ContentHeight+ �� $
 FindAncestor=�"  .+��� $��0��$��1����.  $��23������ *Label+ �� $
 FindAncestor=�"  �� $��1��$��0����.  ���� *Label+ �� $
 FindAncestor=�"  �� $ 
Horizontal=�$��1��$��1�� .  .+�  $ enhancedComboInput�� . $
��Left=���. ���� *ContentWidth+ �� $
 FindAncestor=�"   �� *ItemsSource+ �� "   �� *SelectedItem+ �� "   �� *IsTextEditable+ �� "   �� *DisplayMember+ �� "   �� *	ErrorText+ �� "  �� $��10(�$��5,0,0,0q�$��Center=� .  y��� *IsValidationVisible+ �� $
 FindAncestor=�"  8   ���� " �� ��  �� *	IsValid+ �� $
 FindAncestor=�"   RequiredAndEmpty.a���  � ��$	 *����  � ��$	 12(���  �� *	IsValid+ �� $
 FindAncestor=�"  	 Valid.a���  � ��$		 ✓����  � ��$	 10(���  �� *	IsValid+ �� $
 FindAncestor=�"   Invalid.a���  � ��$		 ✗����  � ��$	 10(��� .R�� $��Stretch=� �� ���� *
LabelWidth+ �� $
 FindAncestor=�"  �� ���� *ContentWidth+ �� $
 FindAncestor=�"  �� ���� *ContentWidth2+ �� $
 FindAncestor=�" 
 �� $��* �.+��� $��0��$��23����.  ���� *Label+ �� $
 FindAncestor=�"    $ 	textInput��$��1��$
��Left=����� *ContentWidth+ �� $
 FindAncestor=�"   �� *Text+$ PropertyChanged=� �� $
 FindAncestor=�"   �� *
IsReadOnly+ �� $
 FindAncestor=�"   �� $
 Text� �� *Self+  $ 
textInput2��$��2��$
��Left=����� *ContentWidth2+ �� $
 FindAncestor=�"   �� *Text2+$ PropertyChanged=� �� $
 FindAncestor=�" 
  �� *
IsReadOnly+ �� $
 FindAncestor=�"   �� $
 Text� �� *Self+�� $��3��$��10(�$��5,0,0,0q�$��Center=�y��� *IsValidationVisible+ �� $
 FindAncestor=�"  8   ���� " �� ��  �� *	IsValid+ �� $
 FindAncestor=�"   RequiredAndEmpty.a���  � ��$	 *����  � ��$	 12(���  �� *	IsValid+ �� $
 FindAncestor=�"  	 Valid.a���  � ��$		 ✓����  � ��$	 10(���  �� *	IsValid+ �� $
 FindAncestor=�"   Invalid.a���  � ��$		 ✗����  � ��$	 10(��� .R�� $��Stretch=� �� ���� *
LabelWidth+ �� $
 FindAncestor=�"  �� $��* �.+��� $��0��$��23������ *Label+ �� $
 FindAncestor=�"    $ passwordInput��$��1��$
��Left=� .  ���� *ContentWidth+ �� $
 FindAncestor=�"   �� *Text+$ PropertyChanged=� �� $
 FindAncestor=�"   �� $
 Text� �� *Self+�� .R�� $��Stretch=� �� ���� *
LabelWidth+ �� $
 FindAncestor=�"  �� $��* �.+��� $��0��$��23������ *Label+ �� $
 FindAncestor=�"  �� $ 
Horizontal=�$��1��.+�  $ passwordInput��$
��Left=� .  ���� *ContentWidth+ �� $
 FindAncestor=�"   �� *Text+$ PropertyChanged=� �� $
 FindAncestor=�"  �� $��10(�$��5,0,0,0q�$��Center=�y��� *IsValidationVisible+ �� $
 FindAncestor=�"  8   ���� " �� ��  �� *	IsValid+ �� $
 FindAncestor=�"   RequiredAndEmpty.a���  � ��$	 *����  � ��$	 12(���  �� *	IsValid+ �� $
 FindAncestor=�"  	 Valid.a���  � ��$		 ✓����  � ��$	 10(���  �� *	IsValid+ �� $
 FindAncestor=�"   Invalid.a���  � ��$		 ✗����  � ��$	 10(��� .R�� $��Stretch=� �� ���� " �� ��  �� *HorizontalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *HorizontalLabel+ �� "   True.a���  � ��	 �� *
LabelWidth+ �� $
 FindAncestor=�"  �� ���� " �� ��  �� *HorizontalLabel+ �� "   True.a���  � ��	 �� *ContentWidth+ �� $
 FindAncestor=�"   �� ���� " �� ��  �� *VerticalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *LabelHeight+ �� $
 FindAncestor=�"  �� ���� " �� ��  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *ContentHeight+ �� $
 FindAncestor=�"  .+��� $��0��$��1����.  $��23������ *Label+ �� $
 FindAncestor=�"  �� $��1��$��0����.  ���� *Label+ �� $
 FindAncestor=�"  �� $��1��$��1��$
��Left=���.   �� $ DataContext� �� $
 FindAncestor=�"  ���� " �� ��  �� *IsRequiredField+ �� "  	 False.a���  � ��	 �� .R�  $ 	textInput��$
��Left=�$ Numeric=� . $ Strong=���. ���� *ContentWidth+ �� $
 FindAncestor=�"   �� *
IsReadOnly+ �� $
 FindAncestor=�"   �� *Text+$ PropertyChanged=� �� $
 FindAncestor=�"    �� *
NumberMask+$ PropertyChanged=� �� $
 FindAncestor=�"   �� *	ErrorText+ �� "  ��  �� *IsRequiredField+ �� "   True.a���  � ��	 �� .R��� $��2q�
���  ��._�  $ 	textInput��$
��Left=�$ Numeric=� . $ Strong=���. ���� *ContentWidth+ �� $
 FindAncestor=�"   �� *
IsReadOnly+ �� $
 FindAncestor=�"   �� *Text+$ PropertyChanged=� �� $
 FindAncestor=�"    �� *
NumberMask+$ PropertyChanged=� �� $
 FindAncestor=�"   �� *	ErrorText+ �� "  �� .R�� $��Stretch=� �� ���� " �� ��  �� *HorizontalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *HorizontalLabel+ �� "   True.a���  � ��	 �� *
LabelWidth+ �� $
 FindAncestor=�"  �� ���� " �� ��  �� *HorizontalLabel+ �� "   True.a���  � ��$	 * � �� ���� " �� ��  �� *VerticalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *LabelHeight+ �� $
 FindAncestor=�"  �� ���� " �� ��  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *ContentHeight+ �� $
 FindAncestor=�"  .+��� $��0��$��1��$��23������ *Label+ �� $
 FindAncestor=�"  �� $��1��$��0������ *Label+ �� $
 FindAncestor=�"  �� $��1��$��1��$ 
Horizontal=�.+��� $
��Left=� �� $ DataContext� �� $
 FindAncestor=�"  ���� " �� ��  �� *IsRequiredField+ �� "  	 False.a���  � ��	 �� .R�  $ 	textInput��$
��Left=�$ Numeric=� . $ Strong=���. ���� *ContentWidth+ �� $
 FindAncestor=�"   �� *
IsReadOnly+ �� $
 FindAncestor=�"   �� *Text+$ PropertyChanged=� �� $
 FindAncestor=�"    �� *
NumberMask+$ PropertyChanged=� �� $
 FindAncestor=�"   �� *	ErrorText+ �� "  ��  �� *IsRequiredField+ �� "   True.a���  � ��	 �� .R��� $��2q�
���  ��._�  $ 	textInput��$
��Left=�$ Numeric=� . $ Strong=���. ���� *ContentWidth+ �� $
 FindAncestor=�"   �� *
IsReadOnly+ �� $
 FindAncestor=�"   �� *Text+$ PropertyChanged=� �� $
 FindAncestor=�"    �� *
NumberMask+$ PropertyChanged=� �� $
 FindAncestor=�"   �� *	ErrorText+ �� "  �� $��10(�$��5,0,0,0q�$��Center=�y��� *IsValidationVisible+ �� $
 FindAncestor=�"  8   ���� " �� ��  �� *	IsValid+ �� $
 FindAncestor=�"   RequiredAndEmpty.a���  � ��$	 *����  � ��$	 12(���  �� *	IsValid+ �� $
 FindAncestor=�"  	 Valid.a���  � ��$		 ✓����  � ��$	 10(���  �� *	IsValid+ �� $
 FindAncestor=�"   Invalid.a���  � ��$		 ✗����  � ��$	 10(��� .R�� $��Stretch=� �� ���� *
LabelWidth+ �� $
 FindAncestor=�"  �� ���� *ContentWidth+ �� $
 FindAncestor=�"  �� ���� *ContentWidth2+ �� $
 FindAncestor=�" 
 .+��� $��0��$��23������ *Label+ �� $
 FindAncestor=�"    $ 	textInput��$��1��$
��Left=����� *ContentWidth+ �� $
 FindAncestor=�"   �� *Text+$ PropertyChanged=� �� $
 FindAncestor=�"   �� *
IsReadOnly+ �� $
 FindAncestor=�"   �� $
 Text� �� *Self+  $ 
textInput2��$��2��$
��Left=����� *ContentWidth2+ �� $
 FindAncestor=�"   �� *Text2+$ PropertyChanged=� �� $
 FindAncestor=�" 
  �� *
IsReadOnly+ �� $
 FindAncestor=�"   �� $
 Text� �� *Self+�� .R�� $��Stretch=� �� ���� *
LabelWidth+ �� $
 FindAncestor=�"  �� $��* �.+��� $��0����.  $��23������ *Label+ �� $
 FindAncestor=�"  ���� *
LabelWidth+ �� $
 FindAncestor=�"    $! 
comboInput��$��1��$
��Left=���. ���� *ContentWidth+ �� $
 FindAncestor=�"  ���� *ContentHeight+ �� $
 FindAncestor=�"   �� *ItemsSource+ �� "  " �� *SelectedItem+ �� "   �� *DisplayMember+ �� "   �� $ DisplayText� �� *Self+�� .R�� $��Stretch=� �� ���� *
LabelWidth+ �� $
 FindAncestor=�"  �� $��* �.+��� $��0��$��23����.  ���� *Label+ �� $
 FindAncestor=�"    $ enhancedComboInput�� . $��1��$
��Left=����� *ContentWidth+ �� $
 FindAncestor=�"  ���� *ContentHeight+ �� $
 FindAncestor=�"   �� *ItemsSource+ �� "   �� *SelectedItem+ �� "   �� *DisplayMember+ �� "  # �� *ItemTemplate+ �� "  �� .R�� $��Stretch=� �� ���� " �� ��  �� *HorizontalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *HorizontalLabel+ �� "   True.a���  � ��	 �� *
LabelWidth+ �� $
 FindAncestor=�"  �� ���� " �� ��  �� *HorizontalLabel+ �� "   True.a���  � ��	 �� *ContentWidth+ �� $
 FindAncestor=�"   �� ���� " �� ��  �� *VerticalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *LabelHeight+ �� $
 FindAncestor=�"  �� ���� " �� ��  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *ContentHeight+ �� $
 FindAncestor=�"  .+��� $��0��$��1����.  $��23������ *Label+ �� $
 FindAncestor=�"  ���� *
LabelWidth+ �� $
 FindAncestor=�"  �� $��1��$��0����.  ���� *Label+ �� $
 FindAncestor=�"  �� $��1��$��1��$
��Left=���.   �� *DataContext+ �� $
 FindAncestor=�"  ���� " �� ��  �� *IsRequiredField+ �� $
 FindAncestor=�"  	 False.a���  � ��	 �� .R�  $ enhancedComboInput�� . $
��Left=���.  �� *ItemsSource+ �� "   �� *SelectedItem+ �� "   �� *IsTextEditable+ �� "   �� *DisplayMember+ �� "  ���� *ContentWidth+ �� $
 FindAncestor=�"  ���� *ContentHeight+ �� $
 FindAncestor=�"   �� *	ErrorText+ �� "  ��  �� *IsRequiredField+ �� $
 FindAncestor=�"   True.a���  � ��	 �� .R��� 
���  ��$��2q�._�  $ enhancedComboInput�� . $
��Left=���.  �� *ItemsSource+ �� "   �� *SelectedItem+ �� "   �� *IsTextEditable+ �� "   �� *DisplayMember+ �� "  ���� *ContentWidth+ �� $
 FindAncestor=�"  ���� *ContentHeight+ �� $
 FindAncestor=�"   �� *	ErrorText+ �� "  �� .R�� $��Stretch=� �� ���� " �� ��  �� *HorizontalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *HorizontalLabel+ �� "   True.a���  � ��	 �� *
LabelWidth+ �� $
 FindAncestor=�"  �� ���� " �� ��  �� *HorizontalLabel+ �� "   True.a���  � ��	 �� *ContentWidth+ �� $
 FindAncestor=�"   �� ���� " �� ��  �� *VerticalLabel+ �� "  	 False.a���  � ��$	 0 ���  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *LabelHeight+ �� $
 FindAncestor=�"  �� ���� " �� ��  �� *VerticalLabel+ �� "   True.a���  � ��	 �� *ContentHeight+ �� $
 FindAncestor=�"  .+��� $��0��$��1����.  $��23������ *Label+ �� $
 FindAncestor=�"  �� $��1��$��0����.  ���� *Label+ �� $
 FindAncestor=�"  �� $ 
Horizontal=�$��1��$��1�� .  .+�  $! 
comboInput��$��1��$��1����. $
��Left=����� *ContentHeight+ �� $
 FindAncestor=�"  ���� *ContentWidth+ �� $
 FindAncestor=�"   �� *ItemsSource+ �� "   �� *SelectedItem+$$ TwoWay=� �� "   �� *DisplayMember+ �� "  % �� $ ComboBoxEditTag�$$ TwoWay=� �� "   �� *IsTextEditable+ �� "  ���� *ComboForeground+ �� "  ���� *
FontWeight+ �� "  & �� *IsEditorShown+ �� "  '   (   $
) TrueX�$* PopupOpened��+ �� *PopupOpeningCommand+ �� "    $
) TrueX�$* PopupClosed��+ �� *PopupClosingCommand+ �� "  �� $��10(�$��5,0,0,0q�$��Center=�y��� *IsValidationVisible+ �� $
 FindAncestor=�"  8   ���� " �� ��  �� *	IsValid+ �� $
 FindAncestor=�"   RequiredAndEmpty.a���  � ��$	 *����  � ��$	 12(���  �� *	IsValid+ �� $
 FindAncestor=�"  	 Valid.a���  � ��$		 ✓����  � ��$	 10(���  �� *	IsValid+ �� $
 FindAncestor=�"   Invalid.a���  � ��$		 ✗����  � ��$	 10(��� .R�� $��Stretch=� �� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto �.+��� $��0��$��1��$��23������ *Label+ �� $
 FindAncestor=�"  ���� *
LabelWidth+ �� $
 FindAncestor=�"  y��� *HorizontalLabel+ �� $
 FindAncestor=�"  8   �� $��1��$��0������ *Label+ �� $
 FindAncestor=�"  ���� *
LabelWidth+ �� $
 FindAncestor=�"  ���� *LabelHeight+ �� $
 FindAncestor=�"  y��� *HorizontalLabel+ �� $
 FindAncestor=�"  8    $! 
comboInput��$��1��$��1������ *ContentWidth+ �� $
 FindAncestor=�"  ���� *ContentHeight+ �� $
 FindAncestor=�"   �� *ItemsSource+ �� "   �� *SelectedItem+$ PropertyChanged=�$$ TwoWay=� �� "   �� *DisplayMember+ �� "  % �� $ ComboBoxEditTag�$$ TwoWay=� �� "   �� *IsTextEditable+ �� "  ���� *ComboForeground+ �� "  ���� *
FontWeight+ �� "  & �� *IsEditorShown+ �� "  '   (   $
) TrueX�$* PopupOpened��+ �� *PopupOpeningCommand+ �� "    $
) TrueX�$* PopupClosed��+ �� *PopupClosingCommand+ �� "  �� .R�� $��Stretch=� �� ���� *
LabelWidth+ �� $
 FindAncestor=�"  �� $��* �.+��� $��0��$��23����.  ���� *Label+ �� $
 FindAncestor=�"    $ dateTimeInput��$��1��$ Strong=� . , . $ DateTime=� �� *
IsReadOnly+$$ TwoWay=� �� $
 FindAncestor=�"  ���� *ContentWidth+ �� $
 FindAncestor=�"   �� *Date+$$ TwoWay=� �� $
 FindAncestor=�"    �� *
DateMask+$$ OneWay=� �� $
 FindAncestor=�"  - �� *
DateMask+$$ OneWay=� �� $
 FindAncestor=�"  �� .R�� $��Stretch=� �� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto �.+��� $��0��$��1��$��23��$
��Left=���.  ���� *Label+ �� $
 FindAncestor=�"  ���� *
LabelWidth+ �� $
 FindAncestor=�"  y��� *HorizontalLabel+ �� $
 FindAncestor=�"  8   �� $��1��$��0��$
��Left=���.  ���� *Label+ �� $
 FindAncestor=�"  ���� *
LabelWidth+ �� $
 FindAncestor=�"  ���� *LabelHeight+ �� $
 FindAncestor=�"  y��� *HorizontalLabel+ �� $
 FindAncestor=�"  8  �� $��1��$��1��$
��Left=���.   �� *DataContext+ �� $
 FindAncestor=�"  ���� " �� ��  �� *IsRequiredField+ �� $
 FindAncestor=�"  	 False.a���  � ��	 �� .R�  $. dateTimeCalendarInput��$/ Office2013DarkGray $ Strong=� . , . ��. $ DateTime=�& . ���� *ContentWidth+ �� $
 FindAncestor=�"  ���� *ContentHeight+ �� $
 FindAncestor=�"   �� *Date+$$ TwoWay=� �� $
 FindAncestor=�"    �� *
DateMask+$$ OneWay=� �� $
 FindAncestor=�"  - �� *
DateMask+$$ OneWay=� �� $
 FindAncestor=�"   �� *	ErrorText+ �� "  ��  �� *IsRequiredField+ �� $
 FindAncestor=�"   True.a���  � ��	 �� .R��� 
���  ��$��2q�._�  $. dateTimeCalendarInput��$/ Office2013DarkGray $ Strong=� . , . ��. $ DateTime=�& . ���� *ContentWidth+ �� $
 FindAncestor=�"  ���� *ContentHeight+ �� $
 FindAncestor=�"   �� *Date+$$ TwoWay=� �� $
 FindAncestor=�"    �� *
DateMask+$$ OneWay=� �� $
 FindAncestor=�"  - �� *
DateMask+$$ OneWay=� �� $
 FindAncestor=�"   �� *	ErrorText+ �� "  �� .R�� $��Stretch=� �� ���� *
LabelWidth+ �� $
 FindAncestor=�"  �� $��* �.+��� $��0��$��23������ *Label+ �� $
 FindAncestor=�"    $0 dateTimeCalendarInput��$/ Office2013DarkGray $��1��1 . $ Strong=� . , . $ DateTime=�& . ���� *ContentWidth+ �� $
 FindAncestor=�"   �� *Date+$$ TwoWay=� �� $
 FindAncestor=�"    �� *
DateMask+$$ OneWay=� �� $
 FindAncestor=�"  - �� *
DateMask+$$ OneWay=� �� $
 FindAncestor=�"  �� .R�� $��Stretch=� �� ���� " �� ��  �� *HorizontalLabel+ �� $
 FindAncestor=�"   True.a���  � ��	 �� *
LabelWidth+ �� $
 FindAncestor=�"  ��  �� *HorizontalLabel+ �� $
 FindAncestor=�"  	 False.a���  � ��$	 0 ��� $��* � �� $
��Auto ��� $
��Auto �.+��� $��0��$��1��$��23����.  $
��Left=����� *Label+ �� $
 FindAncestor=�"  ���� *
LabelWidth+ �� $
 FindAncestor=�"  y��� *HorizontalLabel+ �� $
 FindAncestor=�"  8   �� $��1��$��0����.  $
��Left=����� *Label+ �� $
 FindAncestor=�"  ���� *
LabelWidth+ �� $
 FindAncestor=�"  y��� *VerticalLabel+ �� $
 FindAncestor=�"  8    $��1��$��1��$
��Left=���. ���� *ContentWidth+ �� $
 FindAncestor=�"  ���� *ContentHeight+ �� $
 FindAncestor=�"  2 �� *	IsChecked+ �� $
 FindAncestor=�"   �� *
IsReadOnly+ �� $
 FindAncestor=�"  {��� *	IsEnabled+ �� $
 FindAncestor=�"  