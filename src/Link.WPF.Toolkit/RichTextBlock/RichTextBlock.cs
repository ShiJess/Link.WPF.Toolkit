using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Link.WPF.Toolkit
{
    /// <summary>
    /// rich TextBlock
    /// </summary>
    public class RichTextBlock : TextBlock
    {

        #region Para Indent Property       
        public static readonly DependencyProperty ParaIndentProperty = DependencyProperty.Register("ParaIndent", typeof(int), typeof(RichTextBlock), new PropertyMetadata(0));
        /// <summary>
        /// first line text indent
        /// 首行缩进
        /// </summary>
        public int ParaIndent
        {
            get
            {
                return (int)GetValue(ParaIndentProperty);

            }
            set
            {
                SetValue(ParaIndentProperty, value);
            }
        }

        #endregion

        public static readonly DependencyProperty InnerTextProperty = DependencyProperty.Register("InnerText", typeof(string), typeof(RichTextBlock), new PropertyMetadata(""));
        /// <summary>
        /// inner text
        /// </summary>
        public string InnerText
        {
            get
            {
                return (string)GetValue(InnerTextProperty);

            }
            set
            {
                SetValue(InnerTextProperty, value);
            }
        }
  
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.Text = InnerText.PadLeft(ParaIndent, ' ');
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //this.Text = InnerText.PadLeft(ParaIndent, ' ');
        }
             
    }
}