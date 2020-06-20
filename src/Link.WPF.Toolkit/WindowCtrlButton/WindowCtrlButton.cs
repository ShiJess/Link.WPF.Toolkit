using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

#if NET40
using Microsoft.Windows.Shell;
#else
using System.Windows.Shell;
#endif

namespace Link.WPF.Toolkit
{
    /// <summary>
    /// 窗体控制功能按钮 —— 最小化、最大化、关闭
    /// </summary>
    [TemplatePart(Name = PART_MinButton, Type = typeof(ButtonBase))]
    [TemplatePart(Name = PART_MaxButton, Type = typeof(ButtonBase))]
    [TemplatePart(Name = PART_CloseButton, Type = typeof(ButtonBase))]
    public class WindowCtrlButton : Control
    {
        private const string PART_MinButton = "PART_MinButton";
        private const string PART_MaxButton = "PART_MaxButton";
        private const string PART_CloseButton = "PART_CloseButton";

        static WindowCtrlButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowCtrlButton), new FrameworkPropertyMetadata(typeof(WindowCtrlButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            MinButton = GetTemplateChild(PART_MinButton) as ButtonBase;
            MaxButton = GetTemplateChild(PART_MaxButton) as ButtonBase;
            CloseButton = GetTemplateChild(PART_CloseButton) as ButtonBase;
            MinButton.ToolTip = "最小化";
            MaxButton.ToolTip = "最大化";
            CloseButton.ToolTip = "关闭";

            if (BelongWindow != null)
            {
                switch (BelongWindow.ResizeMode)
                {
                    case ResizeMode.NoResize:
                        MinButton.Visibility = Visibility.Collapsed;
                        MaxButton.Visibility = Visibility.Collapsed;
                        CloseButton.Visibility = Visibility.Visible;
                        break;
                    case ResizeMode.CanMinimize:
                        MaxButton.Visibility = Visibility.Collapsed;
                        MinButton.Visibility = Visibility.Visible;
                        CloseButton.Visibility = Visibility.Visible;
                        break;
                    case ResizeMode.CanResize:
                        MinButton.Visibility = Visibility.Visible;
                        MaxButton.Visibility = Visibility.Visible;
                        CloseButton.Visibility = Visibility.Visible;
                        break;
                    case ResizeMode.CanResizeWithGrip:
                        MinButton.Visibility = Visibility.Visible;
                        MaxButton.Visibility = Visibility.Visible;
                        CloseButton.Visibility = Visibility.Visible;
                        break;
                    default:
                        break;
                }
                //MaxButton.ToolTip = this.BelongWindow.WindowState == WindowState.Maximized ? "还原" : "最大化";
                BelongWindow.PreviewKeyUp += BelongWindow_PreviewKeyUp;
                BelongWindow.StateChanged -= BelongWindow_StateChanged;
                BelongWindow.StateChanged += BelongWindow_StateChanged;
                BelongWindow_StateChanged(BelongWindow, new EventArgs());
            }
        }


        #region 附加控件
        private ButtonBase btn_min;
        /// <summary>
        /// “最小化”按钮
        /// </summary>
        private ButtonBase MinButton
        {
            get { return btn_min; }
            set
            {
                if (value != null)
                {
                    value.Click -= Btn_Min_Click;
                    value.Click += Btn_Min_Click;
                }
                btn_min = value;
            }
        }

        private ButtonBase btn_Max;
        /// <summary>
        /// “最大化”按钮
        /// </summary>
        private ButtonBase MaxButton
        {
            get { return btn_Max; }
            set
            {
                if (value != null)
                {
                    value.Click -= Btn_Max_Click;
                    value.Click += Btn_Max_Click;
                }

                btn_Max = value;
            }
        }

        private ButtonBase btn_Close;
        /// <summary>
        /// “关闭”按钮
        /// </summary>
        private ButtonBase CloseButton
        {
            get { return btn_Close; }
            set
            {
                if (value != null)
                {
                    value.Click -= Btn_Close_Click;
                    value.Click += Btn_Close_Click;
                }
                btn_Close = value;
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BelongWindow != null)
                {
                    //此处不设置DialogResult，即 默认窗体返回结果为null
                    BelongWindow.Close();
                }
            }
            catch { }
        }

        /// <summary>
        /// 最大化/还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Max_Click(object sender, RoutedEventArgs e)
        {
            if (BelongWindow != null)
            {
                this.BelongWindow.WindowState = this.BelongWindow.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
                //this.MaxButton.Content = this.BelongWindow.WindowState == WindowState.Maximized ? " ❐ " : " ☐ ";
            }
        }

        /// <summary>
        /// 窗体状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BelongWindow_StateChanged(object sender, EventArgs e)
        {
            if (BelongWindow != null)
            {
                this.MaxButton.Content = this.BelongWindow.WindowState == WindowState.Maximized ? " ❐ " : " ☐ ";
                this.MaxButton.ToolTip = this.BelongWindow.WindowState == WindowState.Maximized ? "还原" : "最大化";
            }
        }

        /// <summary>
        /// 标志全屏前窗体状态
        /// </summary>
        private WindowState FullScreenWindowState = WindowState.Normal;
        private WindowStyle FullScreenWindowStyle = WindowStyle.None;
        private WindowChrome FullScreenWindowChrome = null;
        private void BelongWindow_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.Escape:
                    {
                        if (BelongWindow != null && this.FullScreen == true)
                        {
                            WindowChrome.SetWindowChrome(this.BelongWindow, FullScreenWindowChrome);
                            this.BelongWindow.WindowState = FullScreenWindowState;
                            this.BelongWindow.WindowStyle = FullScreenWindowStyle;

                            this.FullScreen = false;
                        }
                    }
                    break;
                case System.Windows.Input.Key.F11:
                    {
                        if (BelongWindow != null && this.FullScreen == false
                            && BelongWindow.ResizeMode == ResizeMode.CanResize)
                        {
                            FullScreenWindowChrome = WindowChrome.GetWindowChrome(this.BelongWindow);
                            FullScreenWindowStyle = this.BelongWindow.WindowStyle;
                            FullScreenWindowState = this.BelongWindow.WindowState;

                            //this.BelongWindow.BeginInit();
                            if (this.BelongWindow.WindowState == WindowState.Maximized)
                            {
                                this.BelongWindow.StateChanged -= BelongWindow_StateChanged;
                                this.BelongWindow.WindowState = WindowState.Normal;
                                this.BelongWindow.StateChanged += BelongWindow_StateChanged;
                                //this.BelongWindow.Visibility = Visibility.Hidden;
                            }
                            this.BelongWindow.WindowStyle = WindowStyle.None;
                            WindowChrome.SetWindowChrome(this.BelongWindow, null);
                            this.BelongWindow.WindowState = WindowState.Maximized;
                            this.BelongWindow.Visibility = Visibility.Visible;
                            this.BelongWindow.Focus();
                            //this.BelongWindow.EndInit();
                            //this.BelongWindow.Topmost = true;

                            this.FullScreen = true;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Min_Click(object sender, RoutedEventArgs e)
        {
            if (BelongWindow != null)
                this.BelongWindow.WindowState = WindowState.Minimized;
        }
        #endregion

        #region 新增依赖属性
        #region 所属窗体BelongWindow

        public static readonly DependencyProperty BelongWindowProperty = DependencyProperty.Register(
            "BelongWindow", typeof(Window), typeof(WindowCtrlButton), new PropertyMetadata(null));
        /// <summary>
        /// 所属窗体 —— 必须设置
        /// 参考：BelongWindow="{Binding ElementName=window}"
        /// </summary>
        public Window BelongWindow
        {
            get { return (Window)GetValue(BelongWindowProperty); }
            set { SetValue(BelongWindowProperty, value); }
        }

        #endregion

        public static readonly DependencyProperty FullScreenProperty = DependencyProperty.Register(
           "FullScreen", typeof(bool), typeof(WindowCtrlButton), new PropertyMetadata(false));
        /// <summary>
        /// 是否时全屏显示
        /// 全屏操作
        /// </summary>
        public bool FullScreen
        {
            get { return (bool)GetValue(FullScreenProperty); }
            set { SetValue(FullScreenProperty, value); }
        }

        /// <summary>
        /// 启用or禁用全屏功能
        /// </summary>
        public bool EnableFullScreen { get; set; } = true;

        #endregion


    }
}
