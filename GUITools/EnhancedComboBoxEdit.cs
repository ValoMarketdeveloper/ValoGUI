using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using DevExpress.Xpf.Editors;

namespace GUITools
{
    public class EnhancedComboBoxEdit : ComboBoxEdit
    {
        public static readonly DependencyProperty AllowUpdateOnPopupClosedProperty =
            DependencyProperty.Register("AllowUpdateOnPopupClosed", typeof(bool), typeof(EnhancedComboBoxEdit));

        public bool AllowUpdateOnPopupClosed
        {
            get { return (bool)GetValue(AllowUpdateOnPopupClosedProperty); }
            set { SetValue(AllowUpdateOnPopupClosedProperty, value); }
        }

        public EnhancedComboBoxEdit()
            : base()
        {
            PopupClosed += UpdateOnPopupClosed;
        }

        private void UpdateOnPopupClosed(object sender, ClosePopupEventArgs e)
        {
            if (AllowUpdateOnPopupClosed)
            {
                BindingExpression binding = this.GetBindingExpression(BaseEdit.EditValueProperty);
                if (binding != null && binding.DataItem != null && binding.ResolvedSourcePropertyName != null)
                {
                    PropertyInfo property = binding.DataItem.GetType().GetProperty(binding.ResolvedSourcePropertyName);
                    if (property != null)
                        property.SetValue(binding.DataItem, e.EditValue);
                }
            }
        }
    }
}

