using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Link.WPF.Toolkit
{
    /// <summary>
    /// WaitingMask.xaml 的交互逻辑
    /// </summary>
    public partial class WaitingMask : UserControl
    {
        /// <summary>
        /// Cancel Process
        /// </summary>
        public event CancelEventHandler CancelEvent;

        public WaitingMask()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                this.Visibility = Visibility.Collapsed;
            }
            this.btn_cancel.Click += Btn_Cancel_Click;
        }

        /// <summary>
        /// Cancel Wait Process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CancelEvent != null)
                {
                    CancelEventArgs eventArgs = new CancelEventArgs();
                    CancelEvent(this, eventArgs);
                    if (eventArgs.Cancel)
                    {
                        return;
                    }
                }
                this.HideMask();
            }
            catch { }

        }


        /// <summary>
        /// Reset All Controls Status
        /// </summary>
        public void Reset()
        {
            this.btn_cancel.Visibility = Visibility.Collapsed;

            this.tbl_msg.Text = string.Empty;
            this.tbl_msg.Visibility = Visibility.Collapsed;

            this.pb_progress.Maximum = 0;
            this.pb_progress.Value = 0;
            this.pb_progress.Visibility = Visibility.Collapsed;

            this.panel_wait.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Count How Many Masks are Shown
        /// </summary>
        private volatile int showcount = 0;

        #region Show Mask/Wait/Progress
        /// <summary>
        /// Just Show Mask _ Be Used For Show ChildWindow on MainWindow
        /// </summary>
        /// <param name="cancancel">whether to display cancel button</param>
        public void ShowMask(bool cancancel = true)
        {
            try
            {
                showcount++;
                if (showcount <= 0)
                {
                    return;
                }

                Reset();
                this.btn_cancel.Visibility = cancancel ? Visibility.Visible : Visibility.Collapsed;
                this.Visibility = Visibility.Visible;
            }
            catch { }
        }

        /// <summary>
        /// Show Wait Mask _ Be Used To Handle Some LongRunning Operation
        /// </summary>
        /// <param name="cancancel">whether to display cancel button</param>
        public void ShowWait(bool cancancel = true)
        {
            try
            {
                showcount++;
                if (showcount <= 0)
                {
                    return;
                }

                Reset();
                this.btn_cancel.Visibility = cancancel ? Visibility.Visible : Visibility.Collapsed;
                this.panel_wait.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Visible;
            }
            catch { }
        }

        /// <summary>
        /// Show Wait Mask With Message _ Be Used To Handle Some LongRunning Operation. At The Same Time,Tell User What Operation is Handled.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancancel"></param>
        public void ShowMessageWait(string message, bool cancancel = true)
        {
            try
            {
                showcount++;
                if (showcount <= 0)
                {
                    return;
                }

                Reset();
                this.btn_cancel.Visibility = cancancel ? Visibility.Visible : Visibility.Collapsed;
                this.tbl_msg.Visibility = Visibility.Visible;
                this.tbl_msg.Text = message;
                this.panel_wait.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Visible;
            }
            catch { }
        }

        /// <summary>
        /// Show Wait Mask With Progress _  Be Used To Handle Some LongRunning Operation. At The Same Time,Tell User About Progress.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancancel"></param>
        public void ShowProgressWait(string message, bool cancancel = true)
        {
            try
            {
                showcount++;
                if (showcount <= 0)
                {
                    return;
                }

                Reset();
                this.btn_cancel.Visibility = cancancel ? Visibility.Visible : Visibility.Collapsed;
                this.tbl_msg.Visibility = Visibility.Visible;
                this.tbl_msg.Text = message;
                this.pb_progress.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Visible;
            }
            catch { }
        }
        #endregion

        #region Set Mask Message or Progress
        /// <summary>
        /// Set Wait Message
        /// </summary>
        /// <param name="message"></param>
        public void SetWaitMessage(string message)
        {
            try
            {
                this.tbl_msg.Text = message;
            }
            catch { }
        }
        /// <summary>
        /// Set Progress Max Value
        /// </summary>
        /// <param name="maxprogress"></param>
        public void SetMaxProgress(double maxprogress)
        {
            this.pb_progress.Maximum = maxprogress;
        }
        /// <summary>
        /// Set Progress Current Value
        /// </summary>
        /// <param name="currentprogress"></param>
        public void SetCurrentProgress(double currentprogress)
        {
            this.pb_progress.Value = currentprogress;
        }
        #endregion

        #region Close/Hide Mask
        /// <summary>
        /// Hide/Close Mask
        /// </summary>
        public void HideMask()
        {
            try
            {
                showcount--;
                if (showcount > 0)
                {
                    return;
                }
                this.Visibility = Visibility.Collapsed;
            }
            catch { }
        }
        #endregion

    }
}
