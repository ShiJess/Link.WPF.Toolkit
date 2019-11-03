using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Link.WPF.Toolkit
{
    /// <summary>
    /// Password TextBox _ show password value is avaliable
    /// </summary>
    [TemplatePart(Name = PART_PasswordText, Type = typeof(TextBox))]
    public class PasswordTextBox : Control
    {
        private const string PART_PasswordText = "PART_PasswordText";

        static PasswordTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PasswordTextBox), new FrameworkPropertyMetadata(typeof(PasswordTextBox)));
        }

        public override void OnApplyTemplate()
        {
            InputMethod.SetIsInputMethodEnabled(this, false);

            base.OnApplyTemplate();

            PasswordText = GetTemplateChild(PART_PasswordText) as TextBox;

            PasswordText.Text = Password;
        }

        private TextBox passwordText;

        private TextBox PasswordText
        {
            get { return passwordText; }
            set
            {
                if (value != null)
                {
                    InputMethod.SetIsInputMethodEnabled(value, false);
                    value.PreviewTextInput += PasswordText_PreviewTextInput;
                    value.TextChanged += PasswordText_TextChanged;
                }
                passwordText = value;
            }
        }

        private void PasswordText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = ((System.Windows.Controls.TextBox)e.OriginalSource);
            int insertindex = textBox.CaretIndex;
            textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength);
            textBox.Text = textBox.Text.Insert(insertindex, "*".PadLeft(e.Text.Length,'*'));
            textBox.CaretIndex = insertindex + 1;
            e.Handled = true;
            //string text = password.Remove(textBox.SelectionStart, textBox.SelectionLength);
            //password = text.Insert(insertindex, e.Text);
            //textBox.Text = ShowPassword ? password : "*".PadLeft(password.Length, '*');
        }

        private void PasswordText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        #region Password Property
        /// <summary>
        /// 
        /// </summary>
        ///private bool ShowPassword = false;
        private string password = string.Empty;

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(PasswordTextBox), new UIPropertyMetadata(String.Empty, OnFormatStringChanged));
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get
            {
                return (string)GetValue(PasswordProperty);
                //return "*";
                //password = (string)GetValue(PasswordProperty);
                //return ShowPassword ? password : "*".PadLeft(password.Length, '*');
                //return password;
            }
            set
            {
                //password = value;
                //PasswordText.Text = ShowPassword ? password : "*".PadLeft(password.Length, '*');
                SetValue(PasswordProperty, value);
                //password = value;
                //SetValue(PasswordProperty, ShowPassword ? password : "*".PadLeft(password.Length, '*'));
            }
        }

        private static void OnFormatStringChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

    }



    //public class SecurePasswordBox : System.Windows.Controls.TextBox
    //{
    //    // Fake char to display in Visual Tree
    //    private char PWD_CHAR = '●';

    //    /// <summary>
    //    /// Only copy of real password
    //    /// </summary>
    //    /// <remarks>For more security use System.Security.SecureString type instead</remarks>
    //    private string _password = string.Empty;

    //    /// <summary>
    //    /// TextChanged event handler for secure storing of password into Visual Tree,
    //    /// text is replaced with PWD_CHAR chars, clean text is keept into
    //    /// Text property (CLR property not snoopable without mod)   
    //    /// </summary>
    //    protected override void OnTextChanged(TextChangedEventArgs e)
    //    {
    //        if (!this.IsEnabled)
    //        {
    //            this.BaseText = GetRealText(this);
    //            base.OnTextChanged(e);
    //            return;
    //        }
    //        if (dirtyBaseText == true)
    //            return;

    //        string currentText = this.BaseText;

    //        int selStart = this.SelectionStart;
    //        if (currentText.Length < _password.Length)
    //        {
    //            // Remove deleted chars          
    //            _password = _password.Remove(selStart, _password.Length - currentText.Length);
    //            SetRealText(this, _password);
    //        }
    //        if (!string.IsNullOrEmpty(currentText))
    //        {
    //            for (int i = 0; i < currentText.Length; i++)
    //            {
    //                //The char is chinese
    //                Char currentChar = currentText[i];
    //                int iChar = (int)currentChar;
    //                if ((iChar > 127) && (iChar != 9679))
    //                {
    //                    string TextToPinyin = NPinyin.Pinyin.GetPinyin(currentText[i].ToString());
    //                    string newText = currentText.Substring(0, i) + TextToPinyin + currentText.Substring(i + 1);
    //                    selStart = (currentText.Substring(0, i) + TextToPinyin).Length;
    //                    currentText = newText;
    //                    this.BaseText = currentText;
    //                }
    //                if (currentText[i] != PWD_CHAR)
    //                {
    //                    // Replace or insert char
    //                    if (this.BaseText.Length == _password.Length)
    //                    {
    //                        _password = _password.Remove(i, 1).Insert(i, currentText[i].ToString());
    //                    }
    //                    else
    //                    {
    //                        _password = _password.Insert(i, currentText[i].ToString());
    //                    }
    //                }
    //            }
    //            SetRealText(this, _password);

    //            this.BaseText = new string(PWD_CHAR, _password.Length);
    //            this.SelectionStart = selStart;
    //        }
    //        base.OnTextChanged(e);
    //    }

    //    // flag used to bypass OnTextChanged
    //    private bool dirtyBaseText;

    //    /// <summary>
    //    /// Provide access to base.Text without call OnTextChanged 
    //    /// </summary>
    //    private string BaseText
    //    {
    //        get { return base.Text; }
    //        set
    //        {
    //            dirtyBaseText = true;
    //            base.Text = value;
    //            dirtyBaseText = false;
    //        }
    //    }

    //    /// <summary>
    //    /// Clean Password
    //    /// </summary>
    //    public new string Text
    //    {
    //        get { return _password; }
    //        set
    //        {
    //            _password = value;
    //            this.BaseText = new string(PWD_CHAR, value.Length);
    //        }
    //    }


    //    //数据绑定用的附加属性RealText  

    //    public static string GetRealText(DependencyObject obj)
    //    {
    //        return (string)obj.GetValue(RealTextProperty);
    //    }

    //    public static void SetRealText(DependencyObject obj, string value)
    //    {
    //        obj.SetValue(RealTextProperty, value);
    //    }

    //    // Using a DependencyProperty as the backing store for RealText.  This enables animation, styling, binding, etc...
    //    public static readonly DependencyProperty RealTextProperty =
    //        DependencyProperty.RegisterAttached("RealText", typeof(string), typeof(SecurePasswordBox), new UIPropertyMetadata(""));
    //}

}
