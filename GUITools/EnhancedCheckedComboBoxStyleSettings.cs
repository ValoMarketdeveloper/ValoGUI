using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Editors;

namespace GUITools
{
    public class EnhancedCheckedComboBoxStyleSettings : CheckedComboBoxStyleSettings
    {
        protected override bool ShowCustomItemInternal(LookUpEditBase editor) { return false; }
    }
}
