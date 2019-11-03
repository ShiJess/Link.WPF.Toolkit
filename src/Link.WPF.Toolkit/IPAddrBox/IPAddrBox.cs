using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Link.WPF.Toolkit
{
    /// <summary>
    /// IP Address Control
    /// </summary>
    [TemplatePart(Name = PART_IPTextA, Type = typeof(TextBox))]
    [TemplatePart(Name = PART_IPTextB, Type = typeof(TextBox))]
    [TemplatePart(Name = PART_IPTextC, Type = typeof(TextBox))]
    [TemplatePart(Name = PART_IPTextD, Type = typeof(TextBox))]
    public class IPAddrBox : TextBox
    {
        private const string PART_IPTextA = "PART_IPTextA";
        private const string PART_IPTextB = "PART_IPTextB";
        private const string PART_IPTextC = "PART_IPTextC";
        private const string PART_IPTextD = "PART_IPTextD";

        static IPAddrBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IPAddrBox), new FrameworkPropertyMetadata(typeof(IPAddrBox)));
            TextProperty.AddOwner(typeof(IPAddrBox));
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        public override void OnApplyTemplate()
        {
            InputMethod.SetIsInputMethodEnabled(this, false);

            base.OnApplyTemplate();

            IPTextA = GetTemplateChild(PART_IPTextA) as TextBox;
            IPTextB = GetTemplateChild(PART_IPTextB) as TextBox;
            IPTextC = GetTemplateChild(PART_IPTextC) as TextBox;
            IPTextD = GetTemplateChild(PART_IPTextD) as TextBox;

            RefreshIPSegText(this);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            RefreshIPSegText(this);

            base.OnTextChanged(e);
        }

        protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnGotKeyboardFocus(e);

            //if (!IPTextA.IsFocused && !IPTextB.IsFocused && !IPTextC.IsFocused && !IPTextD.IsFocused)
            if (!IPTextA.IsKeyboardFocused && !IPTextB.IsKeyboardFocused && !IPTextC.IsKeyboardFocused && !IPTextD.IsKeyboardFocused)
            {
                if (!string.IsNullOrWhiteSpace(IPTextD.Text) || !string.IsNullOrWhiteSpace(Text))
                {
                    IPTextD.Focus();
                }
                //else if ((e.OriginalSource is IPAddrBox) && !string.IsNullOrWhiteSpace((e.OriginalSource as IPAddrBox).Text))
                //{
                //    IPTextD.Focus();
                //}
                //else if ((e.NewFocus is IPAddrBox) && !string.IsNullOrWhiteSpace((e.NewFocus as IPAddrBox).Text))
                //{
                //    IPTextD.Focus();
                //}
                else
                {
                    IPTextA.Focus();
                }
                //e.Handled = true;
            }
        }

        private static void RefreshIPSegText(IPAddrBox iPAddrBox)
        {
            if (!string.IsNullOrWhiteSpace(iPAddrBox.Text))
            {
                string[] strIpArray = iPAddrBox.Text.Split('.');
                if (strIpArray.Count() > 0 && iPAddrBox.IPTextA != null && iPAddrBox.IPTextA.Text != strIpArray[0])
                {
                    iPAddrBox.IPTextA.Text = strIpArray[0];
                    iPAddrBox.IPTextA.CaretIndex = iPAddrBox.IPTextA.Text.Length;
                }
                if (strIpArray.Count() > 1 && iPAddrBox.IPTextB != null && iPAddrBox.IPTextB.Text != strIpArray[1])
                {
                    iPAddrBox.IPTextB.Text = strIpArray[1];
                    iPAddrBox.IPTextB.CaretIndex = iPAddrBox.IPTextB.Text.Length;
                }
                if (strIpArray.Count() > 2 && iPAddrBox.IPTextC != null && iPAddrBox.IPTextC.Text != strIpArray[2])
                {
                    iPAddrBox.IPTextC.Text = strIpArray[2];
                    iPAddrBox.IPTextC.CaretIndex = iPAddrBox.IPTextC.Text.Length;
                }
                if (strIpArray.Count() > 3 && iPAddrBox.IPTextD != null && iPAddrBox.IPTextD.Text != strIpArray[3])
                {
                    iPAddrBox.IPTextD.Text = strIpArray[3];
                    iPAddrBox.IPTextD.CaretIndex = iPAddrBox.IPTextD.Text.Length;
                }
            }
        }


        private TextBox ipTextA;

        private TextBox IPTextA
        {
            get { return ipTextA; }
            set
            {
                if (value != null)
                {
                    InputMethod.SetIsInputMethodEnabled(value, false);
                    value.PreviewKeyDown -= IPSeg_PreviewKeyDown;
                    value.PreviewKeyDown += IPSeg_PreviewKeyDown;
                    value.PreviewKeyUp -= Value_PreviewKeyUp;
                    value.PreviewKeyUp += Value_PreviewKeyUp;
                    value.PreviewTextInput -= IPSeg_PreviewTextInput;
                    value.PreviewTextInput += IPSeg_PreviewTextInput;
                    value.TextChanged -= IPSeg_TextChanged;
                    value.TextChanged += IPSeg_TextChanged;
                }
                ipTextA = value;
            }
        }

        private TextBox ipTextB;

        private TextBox IPTextB
        {
            get { return ipTextB; }
            set
            {
                if (value != null)
                {
                    InputMethod.SetIsInputMethodEnabled(value, false);
                    value.PreviewKeyDown -= IPSeg_PreviewKeyDown;
                    value.PreviewKeyDown += IPSeg_PreviewKeyDown;
                    value.PreviewKeyUp -= Value_PreviewKeyUp;
                    value.PreviewKeyUp += Value_PreviewKeyUp;
                    value.PreviewTextInput -= IPSeg_PreviewTextInput;
                    value.PreviewTextInput += IPSeg_PreviewTextInput;
                    value.TextChanged -= IPSeg_TextChanged;
                    value.TextChanged += IPSeg_TextChanged;
                }
                ipTextB = value;
            }
        }

        private TextBox ipTextC;

        private TextBox IPTextC
        {
            get { return ipTextC; }
            set
            {
                if (value != null)
                {
                    InputMethod.SetIsInputMethodEnabled(value, false);
                    value.PreviewKeyDown -= IPSeg_PreviewKeyDown;
                    value.PreviewKeyDown += IPSeg_PreviewKeyDown;
                    value.PreviewKeyUp -= Value_PreviewKeyUp;
                    value.PreviewKeyUp += Value_PreviewKeyUp;
                    value.PreviewTextInput -= IPSeg_PreviewTextInput;
                    value.PreviewTextInput += IPSeg_PreviewTextInput;
                    value.TextChanged -= IPSeg_TextChanged;
                    value.TextChanged += IPSeg_TextChanged;
                }
                ipTextC = value;
            }
        }

        private TextBox ipTextD;

        private TextBox IPTextD
        {
            get { return ipTextD; }
            set
            {
                if (value != null)
                {
                    InputMethod.SetIsInputMethodEnabled(value, false);
                    value.PreviewKeyDown -= IPSeg_PreviewKeyDown;
                    value.PreviewKeyDown += IPSeg_PreviewKeyDown;
                    value.PreviewKeyUp -= Value_PreviewKeyUp;
                    value.PreviewKeyUp += Value_PreviewKeyUp;
                    value.PreviewTextInput -= IPSeg_PreviewTextInput;
                    value.PreviewTextInput += IPSeg_PreviewTextInput;
                    value.TextChanged -= IPSeg_TextChanged;
                    value.TextChanged += IPSeg_TextChanged;
                }
                ipTextD = value;
            }
        }


        /// <summary>
        /// limit input：0-255
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IPSeg_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int iptext = 0;
            if (Int32.TryParse(e.Text, out iptext))
            {
                TextBox textBox = ((System.Windows.Controls.TextBox)e.OriginalSource);
                int insertindex = textBox.CaretIndex;
                string text = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength);
                string tempip = text.Insert(insertindex, e.Text);
                if (Int32.TryParse(tempip, out iptext))
                {
                    if (iptext > 255)
                    {
                        if (textBox != IPTextD && textBox.SelectionLength <= 0)
                            textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        else
                            e.Handled = true;
                    }
                    else if (iptext < 0)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// transfer every ipseg item to total Text property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IPSeg_TextChanged(object sender, TextChangedEventArgs e)
        {
            int iptext = 0;
            TextBox textBox = sender as TextBox;
            string tempip = textBox.Text;
            if (Int32.TryParse(tempip, out iptext))
            {
                if (iptext > 255 || iptext < 0)
                {
                    textBox.Text = textBox.Text.Remove(textBox.CaretIndex - 1, 1);
                }
            }

            if (string.IsNullOrWhiteSpace(IPTextA.Text)
               || string.IsNullOrWhiteSpace(IPTextB.Text)
               || string.IsNullOrWhiteSpace(IPTextC.Text)
               || string.IsNullOrWhiteSpace(IPTextD.Text))
            {
                this.Text = string.Empty;
            }
            else
            {
                string ipaddr = "{0}.{1}.{2}.{3}";
                this.Text = string.Format(ipaddr, IPTextA.Text, IPTextB.Text, IPTextC.Text, IPTextD.Text);
            }
        }

        /// <summary>
        /// limit key input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IPSeg_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                #region input content
                //limit number
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                    break;
                case Key.OemPeriod:
                case Key.Decimal:
                    {
                        TextBox textBox = sender as TextBox;
                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {

                        }
                        else
                        {
                            if (textBox != IPTextD)
                                textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        }
                        e.Handled = true;
                    }
                    break;
                case Key.Enter:
                    break;
                #endregion

                #region move focus
                case Key.Back:
                    {
                        TextBox textBox = sender as TextBox;
                        if (textBox.CaretIndex == 0 && string.IsNullOrWhiteSpace(textBox.SelectedText))
                        {
                            if (textBox != IPTextA)
                            {
                                textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));

                                if (IPTextA.IsKeyboardFocused)
                                {
                                    IPTextA.CaretIndex = IPTextA.Text.Length;
                                }
                                else if (IPTextB.IsKeyboardFocused)
                                {
                                    IPTextB.CaretIndex = IPTextB.Text.Length;
                                }
                                else if (IPTextC.IsKeyboardFocused)
                                {
                                    IPTextC.CaretIndex = IPTextC.Text.Length;
                                }
                                else if (IPTextD.IsKeyboardFocused)
                                {
                                    IPTextD.CaretIndex = IPTextD.Text.Length;
                                }
                            }
                            e.Handled = true;
                        }
                    }
                    break;
                case Key.Tab:
                    {

                    }
                    break;
                case Key.Left:
                    {
                        TextBox textBox = sender as TextBox;
                        if (textBox.CaretIndex == 0)
                        {
                            if (textBox != IPTextA)
                            {
                                textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));

                                if (IPTextA.IsKeyboardFocused)
                                {
                                    IPTextA.CaretIndex = IPTextA.Text.Length;
                                }
                                else if (IPTextB.IsKeyboardFocused)
                                {
                                    IPTextB.CaretIndex = IPTextB.Text.Length;
                                }
                                else if (IPTextC.IsKeyboardFocused)
                                {
                                    IPTextC.CaretIndex = IPTextC.Text.Length;
                                }
                                else if (IPTextD.IsKeyboardFocused)
                                {
                                    IPTextD.CaretIndex = IPTextD.Text.Length;
                                }
                            }
                            e.Handled = true;
                        }
                    }
                    break;
                case Key.Right:
                    {
                        TextBox textBox = sender as TextBox;
                        if (textBox.CaretIndex == textBox.Text.Length)
                        {
                            if (textBox != IPTextD)
                            {
                                textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

                                if (IPTextA.IsKeyboardFocused)
                                {
                                    IPTextA.CaretIndex = 0;
                                }
                                else if (IPTextB.IsKeyboardFocused)
                                {
                                    IPTextB.CaretIndex = 0;
                                }
                                else if (IPTextC.IsKeyboardFocused)
                                {
                                    IPTextC.CaretIndex = 0;
                                }
                                else if (IPTextD.IsKeyboardFocused)
                                {
                                    IPTextD.CaretIndex = 0;
                                }
                            }
                            e.Handled = true;
                        }
                    }
                    break;
                case Key.Up:
                    {
                        TextBox textBox = sender as TextBox;
                        if (textBox != IPTextA)
                            textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                    }
                    break;
                case Key.Down:
                    {
                        TextBox textBox = sender as TextBox;
                        if (textBox != IPTextD)
                            textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    }
                    break;
                #endregion

                #region shortcuts
                case Key.LeftCtrl:
                case Key.RightCtrl:
                    break;
                case Key.C:
                    if (e.KeyboardDevice.Modifiers != ModifierKeys.Control)
                    {
                        e.Handled = true;
                    }
                    break;
                case Key.V:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
                    {
                        int iptext = 0;
                        if (!Int32.TryParse(Clipboard.GetText(), out iptext) || iptext > 255 || iptext < 0)
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            TextBox textBox = sender as TextBox;
                            textBox.Text = string.Empty;
                        }
                    }
                    else
                    {
                        e.Handled = true;
                    }
                    break;
                #endregion

                case Key.Delete:
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

        private void Value_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
        }

    }
}
