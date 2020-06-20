using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Link.WPF.Toolkit
{
    /// <summary>
    /// Time Picker - choose Hour:Minute:Second
    /// </summary>
    [TemplatePart(Name = PART_Hour, Type = typeof(TextBox))]
    [TemplatePart(Name = PART_Minute, Type = typeof(TextBox))]
    [TemplatePart(Name = PART_Second, Type = typeof(TextBox))]
    [TemplatePart(Name = PART_Add, Type = typeof(Button))]
    [TemplatePart(Name = PART_Sub, Type = typeof(Button))]
    public class TimePicker : TextBox
    {
        private const string PART_Hour = "PART_Hour";
        private const string PART_Minute = "PART_Minute";
        private const string PART_Second = "PART_Second";
        private const string PART_Add = "PART_Add";
        private const string PART_Sub = "PART_Sub";


        static TimePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimePicker), new FrameworkPropertyMetadata(typeof(TimePicker)));
            TextProperty.AddOwner(typeof(TimePicker));
        }

        public override void OnApplyTemplate()
        {
            InputMethod.SetIsInputMethodEnabled(this, false);

            base.OnApplyTemplate();

            HourText = GetTemplateChild(PART_Hour) as TextBox;
            MinuteText = GetTemplateChild(PART_Minute) as TextBox;
            SecondText = GetTemplateChild(PART_Second) as TextBox;
            AddButton = GetTemplateChild(PART_Add) as Button;
            SubButton = GetTemplateChild(PART_Sub) as Button;

            RefreshIPSegText(this);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            RefreshIPSegText(this);

            base.OnTextChanged(e);
        }


        private static void RefreshIPSegText(TimePicker iPAddrBox)
        {
            if (!string.IsNullOrWhiteSpace(iPAddrBox.Text))
            {
                string[] strIpArray = iPAddrBox.Text.Split(':');
                if (iPAddrBox.HourText != null)
                {
                    if (strIpArray.Count() > 0 && iPAddrBox.HourText.Text != strIpArray[0])
                    {
                        iPAddrBox.HourText.Text = strIpArray[0];
                        iPAddrBox.HourText.CaretIndex = iPAddrBox.HourText.Text.Length;
                    }
                    else
                    {
                        iPAddrBox.HourText.Text = "00";
                        iPAddrBox.HourText.CaretIndex = iPAddrBox.HourText.Text.Length;
                    }
                }
                if (strIpArray.Count() > 1 && iPAddrBox.MinuteText != null && iPAddrBox.MinuteText.Text != strIpArray[1])
                {
                    iPAddrBox.MinuteText.Text = strIpArray[1];
                    iPAddrBox.MinuteText.CaretIndex = iPAddrBox.MinuteText.Text.Length;
                }
                if (strIpArray.Count() > 2 && iPAddrBox.SecondText != null && iPAddrBox.SecondText.Text != strIpArray[2])
                {
                    iPAddrBox.SecondText.Text = strIpArray[2];
                    iPAddrBox.SecondText.CaretIndex = iPAddrBox.SecondText.Text.Length;
                }
            }
        }

        private TextBox hourText;

        private TextBox HourText
        {
            get { return hourText; }
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
                hourText = value;
            }
        }

        private TextBox minuteText;

        private TextBox MinuteText
        {
            get { return minuteText; }
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
                minuteText = value;
            }
        }

        private TextBox secondText;

        private TextBox SecondText
        {
            get { return secondText; }
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
                secondText = value;
            }
        }


        private Button btnAdd;
        private Button AddButton
        {
            get { return btnAdd; }
            set
            {
                if (value != null)
                {
                    value.Click -= Value_Click;
                    value.Click += Value_Click;
                }
                btnAdd = value;
            }
        }

        private void Value_Click(object sender, RoutedEventArgs e)
        {
            if (HourText.IsFocused)
            {
                string temphour = string.IsNullOrWhiteSpace(HourText.Text) ? "00" : HourText.Text;
                int iptext = 0;
                if (Int32.TryParse(temphour, out iptext) && iptext < 23)
                {
                    HourText.Text = (iptext + 1).ToString().PadLeft(2, '0');
                    HourText.CaretIndex = HourText.Text.Length;
                }
            }
            else if (MinuteText.IsFocused)
            {
                string temphour = string.IsNullOrWhiteSpace(MinuteText.Text) ? "00" : MinuteText.Text;
                int iptext = 0;
                if (Int32.TryParse(temphour, out iptext) && iptext < 59)
                {
                    MinuteText.Text = (iptext + 1).ToString().PadLeft(2, '0');
                    MinuteText.CaretIndex = MinuteText.Text.Length;
                }
            }
            else if (SecondText.IsFocused)
            {
                string temphour = string.IsNullOrWhiteSpace(SecondText.Text) ? "00" : SecondText.Text;
                int iptext = 0;
                if (Int32.TryParse(temphour, out iptext) && iptext < 59)
                {
                    SecondText.Text = (iptext + 1).ToString().PadLeft(2, '0');
                    SecondText.CaretIndex = SecondText.Text.Length;
                }
            }
        }

        private Button btnSub;
        private Button SubButton
        {
            get { return btnSub; }
            set
            {
                if (value != null)
                {
                    value.Click -= Value_Click1;
                    value.Click += Value_Click1;
                }
                btnSub = value;
            }
        }

        private void Value_Click1(object sender, RoutedEventArgs e)
        {
            if (HourText.IsFocused)
            {
                string temphour = string.IsNullOrWhiteSpace(HourText.Text) ? "00" : HourText.Text;
                int iptext = 0;
                if (Int32.TryParse(temphour, out iptext) && iptext > 0)
                {
                    HourText.Text = (iptext - 1).ToString().PadLeft(2, '0');
                    HourText.CaretIndex = HourText.Text.Length;
                }
            }
            else if (MinuteText.IsFocused)
            {
                string temphour = string.IsNullOrWhiteSpace(MinuteText.Text) ? "00" : MinuteText.Text;
                int iptext = 0;
                if (Int32.TryParse(temphour, out iptext) && iptext > 0)
                {
                    MinuteText.Text = (iptext - 1).ToString().PadLeft(2, '0');
                    MinuteText.CaretIndex = MinuteText.Text.Length;
                }
            }
            else if (SecondText.IsFocused)
            {
                string temphour = string.IsNullOrWhiteSpace(SecondText.Text) ? "00" : SecondText.Text;
                int iptext = 0;
                if (Int32.TryParse(temphour, out iptext) && iptext > 0)
                {
                    SecondText.Text = (iptext - 1).ToString().PadLeft(2, '0');
                    SecondText.CaretIndex = SecondText.Text.Length;
                }
            }
        }

        private void IPSeg_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int iptext = 0;
            if (Int32.TryParse(e.Text, out iptext))
            {
                TextBox textBox = ((System.Windows.Controls.TextBox)e.OriginalSource);
                int insertindex = textBox.CaretIndex;
                string text = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength);
                string tempip = text.Insert(insertindex, e.Text);
                if (tempip.Length > 2)
                {
                    e.Handled = true;
                }
                else if (Int32.TryParse(tempip, out iptext))
                {
                    if (textBox == HourText && iptext > 23)
                    {
                        e.Handled = true;
                    }
                    else if ((textBox == MinuteText || textBox == SecondText) && iptext > 59)
                    {
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


        private void IPSeg_TextChanged(object sender, TextChangedEventArgs e)
        {
            int iptext = 0;
            TextBox textBox = sender as TextBox;
            string tempip = textBox.Text;
            if (Int32.TryParse(tempip, out iptext))
            {
                //if (iptext > 255 || iptext < 0)
                //{
                //    textBox.Text = textBox.Text.Remove(textBox.CaretIndex - 1, 1);
                //}
            }

            if (string.IsNullOrWhiteSpace(HourText.Text)
               || string.IsNullOrWhiteSpace(MinuteText.Text)
               || string.IsNullOrWhiteSpace(SecondText.Text))
            {
                this.Text = string.Empty;
            }
            else
            {
                string time = "{0}:{1}:{2}";
                this.Text = string.Format(time, HourText.Text, MinuteText.Text, SecondText.Text);
            }
        }


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
                            if (textBox != HourText)
                            {
                                textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));

                                if (HourText.IsKeyboardFocused)
                                {
                                    HourText.CaretIndex = HourText.Text.Length;
                                }
                                else if (MinuteText.IsKeyboardFocused)
                                {
                                    MinuteText.CaretIndex = MinuteText.Text.Length;
                                }
                                else if (SecondText.IsKeyboardFocused)
                                {
                                    SecondText.CaretIndex = SecondText.Text.Length;
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
                            if (textBox != HourText)
                            {
                                textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));

                                if (HourText.IsKeyboardFocused)
                                {
                                    HourText.CaretIndex = HourText.Text.Length;
                                }
                                else if (MinuteText.IsKeyboardFocused)
                                {
                                    MinuteText.CaretIndex = MinuteText.Text.Length;
                                }
                                else if (SecondText.IsKeyboardFocused)
                                {
                                    SecondText.CaretIndex = SecondText.Text.Length;
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
                            if (textBox != SecondText)
                            {
                                textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

                                if (HourText.IsKeyboardFocused)
                                {
                                    HourText.CaretIndex = 0;
                                }
                                else if (MinuteText.IsKeyboardFocused)
                                {
                                    MinuteText.CaretIndex = 0;
                                }
                                else if (SecondText.IsKeyboardFocused)
                                {
                                    SecondText.CaretIndex = 0;
                                }

                            }
                            e.Handled = true;
                        }
                    }
                    break;
                case Key.Up:
                    {
                        TextBox textBox = sender as TextBox;
                        if (textBox != HourText)
                            textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                    }
                    break;
                case Key.Down:
                    {
                        TextBox textBox = sender as TextBox;
                        if (textBox != SecondText)
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
