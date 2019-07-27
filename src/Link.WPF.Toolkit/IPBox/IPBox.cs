using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// IP Address Control
    /// </summary>
    [TemplatePart(Name = PART_IPTextA, Type = typeof(TextBoxBase))]
    [TemplatePart(Name = PART_IPTextB, Type = typeof(TextBoxBase))]
    [TemplatePart(Name = PART_IPTextC, Type = typeof(TextBoxBase))]
    [TemplatePart(Name = PART_IPTextD, Type = typeof(TextBoxBase))]
    public class IPBox : Control
    {
        private const string PART_IPTextA = "PART_IPTextA";
        private const string PART_IPTextB = "PART_IPTextB";
        private const string PART_IPTextC = "PART_IPTextC";
        private const string PART_IPTextD = "PART_IPTextD";

        static IPBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IPBox), new FrameworkPropertyMetadata(typeof(IPBox)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            IPTextA = GetTemplateChild(PART_IPTextA) as TextBoxBase;
            IPTextB = GetTemplateChild(PART_IPTextB) as TextBoxBase;
            IPTextC = GetTemplateChild(PART_IPTextC) as TextBoxBase;
            IPTextD = GetTemplateChild(PART_IPTextD) as TextBoxBase;
        }


        private TextBoxBase ipTextA;

        public TextBoxBase IPTextA
        {
            get { return ipTextA; }
            set { ipTextA = value; }
        }

        private TextBoxBase ipTextB;

        public TextBoxBase IPTextB
        {
            get { return ipTextB; }
            set { ipTextB = value; }
        }

        private TextBoxBase ipTextC;

        public TextBoxBase IPTextC
        {
            get { return ipTextC; }
            set { ipTextC = value; }
        }

        private TextBoxBase ipTextD;

        public TextBoxBase IPTextD
        {
            get { return ipTextD; }
            set { ipTextD = value; }
        }



    }
}
