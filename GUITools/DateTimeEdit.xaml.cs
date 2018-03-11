using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Validation.Native;
using System.Windows.Controls;
using CommonTools;

namespace GUITools
{
    public partial class DateTimeEdit : DateEdit, INotifyPropertyChanged
    {
        private bool timeChanged = false;

        public DateTimeEdit()
        {
            InitializeComponent();
            DataContext = this;
            descDateTime.AddValueChanged(this, OnDateTimeChanged);
            OnDateTimeChanged(null, null);
            ShowClearButton = false;
        }

        public bool IsShowTimePanel
        {
            get { return (bool)GetValue(IsShowTimePanelProperty); }
            set { SetValue(IsShowTimePanelProperty, value); }
        }

        private DateTime currentTime;
        public DateTime CurrentTime
        {
            get
            {
                DateTime? d = (DateTime?)EditValue;
                if (currentTime == null)
                {
                    if (d == null)
                        currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    else
                        currentTime = new DateTime(d.Value.Year, d.Value.Month, d.Value.Day);
                }

                return currentTime;
            }
            set
            {
                if (value != null)
                {
                    DateTime? d = (DateTime?)EditValue;
                    if (d == null)
                        d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    currentTime = new DateTime(d.Value.Year, d.Value.Month, d.Value.Day, value.Hour, value.Minute, value.Second, value.Millisecond);

                    this.SetCurrentValue(DateTimeEdit.EditValueProperty, currentTime);
                    timeChanged = true;

                    NotifyPropertyChanged("CurrentTime");
                }
            }
        }

        public static readonly DependencyProperty IsShowTimePanelProperty = DependencyProperty.Register("IsShowTimePanel", typeof(bool), typeof(DateTimeEdit), new PropertyMetadata(false));
        DependencyPropertyDescriptor descDateTime = DependencyPropertyDescriptor.FromProperty(DateTimeProperty, typeof(DateTimeEdit));

        void OnDateTimeChanged(object sender, EventArgs e)
        {
            DateTime d;
            if (timeChanged)
                d = new DateTime(this.DateTime.Year, this.DateTime.Month, this.DateTime.Day, CurrentTime.Hour, CurrentTime.Minute, CurrentTime.Second, CurrentTime.Millisecond);
            else
                d = DateTime;

            timeChanged = false;

            this.DateTime = d;
            if (this.Calendar != null)
                this.Calendar.DateTime = d;
            this.SetCurrentValue(DateTimeEdit.EditValueProperty, d);
            currentTime = d;
        }

        private void MakeHourUp(object sender, RoutedEventArgs e)
        {
            CurrentTime = CurrentTime.AddHours(1);
        }
        private void MakeHourDown(object sender, RoutedEventArgs e)
        {
            CurrentTime = CurrentTime.AddHours(-1);
        }
        private void MakeMinuteUp(object sender, RoutedEventArgs e)
        {
            CurrentTime = CurrentTime.AddMinutes(1);
        }
        private void MakeMinuteDown(object sender, RoutedEventArgs e)
        {
            CurrentTime = CurrentTime.AddMinutes(-1);
        }
        private void MakeSecondUp(object sender, RoutedEventArgs e)
        {
            CurrentTime = CurrentTime.AddSeconds(1);
        }
        private void MakeSecondDown(object sender, RoutedEventArgs e)
        {
            CurrentTime = CurrentTime.AddSeconds(-1);
        }
        private void MakeMillisecondUp(object sender, RoutedEventArgs e)
        {
            CurrentTime = CurrentTime.AddMilliseconds(1);
        }
        private void MakeMillisecondDown(object sender, RoutedEventArgs e)
        {
            CurrentTime = CurrentTime.AddMilliseconds(-1);
        }

        public void NowButtonClick(object sender, RoutedEventArgs e)
        {
            descDateTime.SetValue(this, DateTime.Now);
            CurrentTime = DateTime;
            OnDateTimeChanged(null, null);
            this.ClosePopup(PopupCloseMode.Normal);
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
