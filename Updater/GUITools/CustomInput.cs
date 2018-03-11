using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CommonTools;

namespace GUITools
{
    public class CustomInput : ContentControl
    {
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(CustomInput), new UIPropertyMetadata(String.Empty));

        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(double), typeof(CustomInput), new PropertyMetadata(Double.NaN));

        public static readonly DependencyProperty LabelHeightProperty =
            DependencyProperty.Register("LabelHeight", typeof(double), typeof(CustomInput));

        public static readonly DependencyProperty ContentWidthProperty =
            DependencyProperty.Register("ContentWidth", typeof(double), typeof(CustomInput), new PropertyMetadata(Double.NaN));

        public static readonly DependencyProperty ContentHeightProperty =
            DependencyProperty.Register("ContentHeight", typeof(double), typeof(CustomInput), new PropertyMetadata(Double.NaN));

        public static readonly DependencyProperty ErrorTextProperty =
            DependencyProperty.Register("ErrorText", typeof(string), typeof(CustomInput), new UIPropertyMetadata(String.Empty));

        public static readonly DependencyProperty IsRequiredFieldProperty =
           DependencyProperty.Register("IsRequiredField", typeof(bool), typeof(CustomInput), new UIPropertyMetadata(false));

        public static readonly DependencyProperty BorderWidthProperty =
            DependencyProperty.Register("BorderWidth", typeof(double), typeof(CustomInput), new PropertyMetadata(Double.NaN));

        public static readonly DependencyProperty VerticalLabelProperty = DependencyProperty.Register("VerticalLabel", typeof(bool), typeof(CustomInput),
                                                new UIPropertyMetadata(false));

        public static readonly DependencyProperty HorizontalLabelProperty = DependencyProperty.Register("HorizontalLabel", typeof(bool), typeof(CustomInput),
                                                new UIPropertyMetadata(true));

        public static readonly DependencyProperty IsValidationVisibleProperty =
            DependencyProperty.Register("IsValidationVisible", typeof(bool), typeof(CustomInput), new UIPropertyMetadata(false));

        public static readonly DependencyProperty IsValidProperty =
            DependencyProperty.Register("IsValid", typeof(FieldValidationState), typeof(CustomInput), new UIPropertyMetadata(FieldValidationState.RequiredAndEmpty));



        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public double LabelWidth
        {
            get { return (double)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        public double LabelHeight
        {
            get { return (double)GetValue(LabelHeightProperty); }
            set { SetValue(LabelHeightProperty, value); }
        }

        public double ContentWidth
        {
            get { return (double)GetValue(ContentWidthProperty); }
            set { SetValue(ContentWidthProperty, value); }
        }

        public double ContentHeight
        {
            get { return (double)GetValue(ContentHeightProperty); }
            set { SetValue(ContentHeightProperty, value); }
        }

        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }

        public bool IsRequiredField
        {
            get { return (bool)GetValue(IsRequiredFieldProperty); }
            set { SetValue(IsRequiredFieldProperty, value); }
        }

        public double BorderWidth
        {
            get { return (double)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public bool VerticalLabel
        {
            get { return (bool)GetValue(VerticalLabelProperty); }
            set { SetValue(VerticalLabelProperty, value); }
        }

        public bool HorizontalLabel
        {
            get { return (bool)GetValue(HorizontalLabelProperty); }
            set { SetValue(HorizontalLabelProperty, value); }
        }

        public bool IsValidationVisible
        {
            get { return (bool)GetValue(IsValidationVisibleProperty); }
            set { SetValue(IsValidationVisibleProperty, value); }
        }

        public FieldValidationState IsValid
        {
            get { return (FieldValidationState)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

    }

    public enum FieldValidationState
    {
        RequiredAndEmpty,
        Valid,
        Invalid
    }

    public class CustomTextEdit : CustomInput
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CustomTextEdit), new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(CustomTextEdit), new UIPropertyMetadata(false));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

    }


    public class CustomNumberTextEdit : CustomTextEdit
    {
        public static readonly DependencyProperty NumberMaskProperty =
            DependencyProperty.Register("NumberMask", typeof(string), typeof(CustomNumberTextEdit), new UIPropertyMetadata("N0"));

        public string NumberMask
        {
            get { return (string)GetValue(NumberMaskProperty); }
            set { SetValue(NumberMaskProperty, value); }
        }
    }

    public class CustomDoubleTextEdit : CustomTextEdit
    {
        public static readonly DependencyProperty Text2Property =
            DependencyProperty.Register("Text2", typeof(string), typeof(CustomTextEdit), new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty ContentWidth2Property =
            DependencyProperty.Register("ContentWidth2", typeof(double), typeof(CustomInput));

        public string Text2
        {
            get { return (string)GetValue(Text2Property); }
            set { SetValue(Text2Property, value); }
        }

        public double ContentWidth2
        {
            get { return (double)GetValue(ContentWidth2Property); }
            set { SetValue(ContentWidth2Property, value); }
        }
    }

    public class CustomDateEdit : CustomInput
    {
        public static readonly DependencyProperty DateMaskProperty =
            DependencyProperty.Register("DateMask", typeof(string), typeof(CustomDateEdit), new UIPropertyMetadata("MM/dd/yy HH:mm:ss"));

        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(DateTime?), typeof(CustomDateEdit), new UIPropertyMetadata(null));

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(CustomDateEdit), new UIPropertyMetadata(false));

        public string DateMask
        {
            get { return (string)GetValue(DateMaskProperty); }
            set { SetValue(DateMaskProperty, value); }
        }

        public DateTime? Date
        {
            get { return (DateTime?)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
    }

    public class CustomComboEdit : CustomInput
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(object), typeof(CustomComboEdit));

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(CustomComboEdit));

        public static readonly DependencyProperty DisplayMemberProperty =
            DependencyProperty.Register("DisplayMember", typeof(string), typeof(CustomComboEdit));

        public static readonly DependencyProperty ComboBoxEditTagProperty =
            DependencyProperty.Register("ComboBoxEditTag", typeof(object), typeof(CustomComboEdit));

        public static readonly DependencyProperty PopupOpeningCommandProperty =
            DependencyProperty.Register("PopupOpeningCommand", typeof(RelayCommand<object>), typeof(CustomComboEdit));

        public static readonly DependencyProperty PopupClosingCommandProperty =
            DependencyProperty.Register("PopupClosingCommand", typeof(RelayCommand<object>), typeof(CustomComboEdit));

        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(CustomComboEdit));

        public static readonly DependencyProperty IsTextEditableProperty =
            DependencyProperty.Register("IsTextEditable", typeof(bool), typeof(CustomComboEdit), new PropertyMetadata(true));

        public static readonly DependencyProperty ComboForegroundProperty =
            DependencyProperty.Register("ComboForeground", typeof(Brush), typeof(CustomComboEdit), new PropertyMetadata(Brushes.Black));

        public new static readonly DependencyProperty FontWeightProperty =
            DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(CustomComboEdit), new PropertyMetadata(FontWeights.Bold));

        public static readonly DependencyProperty IsEditorShownProperty =
            DependencyProperty.Register("IsEditorShown", typeof(bool), typeof(CustomComboEdit), new PropertyMetadata(true));



        public object ItemsSource
        {
            get { return (object)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public object ComboBoxEditTag
        {
            get { return (object)GetValue(ComboBoxEditTagProperty); }
            set { SetValue(ComboBoxEditTagProperty, value); }
        }

        public string DisplayMember
        {
            get { return (string)GetValue(DisplayMemberProperty); }
            set { SetValue(DisplayMemberProperty, value); }
        }

        public RelayCommand<object> PopupOpeningCommand
        {
            get { return (RelayCommand<object>)GetValue(PopupOpeningCommandProperty); }
            set { SetValue(PopupOpeningCommandProperty, value); }
        }

        public RelayCommand<object> PopupClosingCommand
        {
            get { return (RelayCommand<object>)GetValue(PopupClosingCommandProperty); }
            set { SetValue(PopupClosingCommandProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public bool IsTextEditable
        {
            get { return (bool)GetValue(IsTextEditableProperty); }
            set { SetValue(IsTextEditableProperty, value); }
        }

        public Brush ComboForeground
        {
            get { return (Brush)GetValue(ComboForegroundProperty); }
            set { SetValue(ComboForegroundProperty, value); }
        }

        public new FontWeight FontWeight
        {
            get { return (FontWeight)GetValue(FontWeightProperty); }
            set { SetValue(FontWeightProperty, value); }
        }

        public bool IsEditorShown
        {
            get { return (bool)GetValue(IsEditorShownProperty); }
            set { SetValue(IsEditorShownProperty, value); }
        }

    }

    public class CustomCheckEdit : CustomInput
    {
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(CustomCheckEdit), new UIPropertyMetadata(false));

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(CustomCheckEdit), new UIPropertyMetadata(false));

        public static readonly DependencyProperty ContentHorizontalAlignmentProperty =
           DependencyProperty.Register("ContentHorizontalAlignment", typeof(HorizontalAlignment), typeof(CustomCheckEdit));

        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(CustomCheckEdit));

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public HorizontalAlignment ContentHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(ContentHorizontalAlignmentProperty); }
            set { SetValue(ContentHorizontalAlignmentProperty, value); }
        }

        public Thickness ContentMargin
        {
            get { return (Thickness)GetValue(ContentMarginProperty); }
            set { SetValue(ContentMarginProperty, value); }
        }
    }

}
