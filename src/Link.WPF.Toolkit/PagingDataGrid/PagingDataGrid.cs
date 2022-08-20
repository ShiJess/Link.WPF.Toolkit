using System;
using System.Collections;
using System.Collections.Generic;
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
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Link.WPF.Toolkit.Pagination"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Link.WPF.Toolkit.Pagination;assembly=Link.WPF.Toolkit.Pagination"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:Pagination/>
    ///
    /// </summary>
    [TemplatePart(Name = PART_HomeButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_PrevButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_NextButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_LastButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_JumpButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_PageSizeComboBox, Type = typeof(ComboBox))]
    [TemplatePart(Name = PART_PageIndexTextBox, Type = typeof(TextBox))]
    public class PagingDataGrid : DataGrid
    {

        private const string PART_HomeButton = "PART_Home";
        private const string PART_PrevButton = "PART_Prev";
        private const string PART_NextButton = "PART_Next";
        private const string PART_LastButton = "PART_Last";
        private const string PART_JumpButton = "PART_Jump";
        private const string PART_PageSizeComboBox = "PART_PageSize";
        private const string PART_PageIndexTextBox = "PART_PageIndex";


        private static void TotalItemsSourceProperChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PagingDataGrid pdg = d as PagingDataGrid;
            if (pdg != null)
            {
                pdg.RefreshList(d, e);
            }
        }

        public static readonly DependencyProperty TotalItemsSourceProperty = DependencyProperty.Register(
            "TotalItemsSource",
            typeof(IEnumerable),
            typeof(PagingDataGrid),
            new FrameworkPropertyMetadata(TotalItemsSourceProperChanged)
            {
                BindsTwoWayByDefault = true
            }
            );
        public static readonly DependencyProperty ShowRowNumberProperty = DependencyProperty.Register("ShowRowNumber", typeof(bool), typeof(PagingDataGrid), new FrameworkPropertyMetadata(false) { BindsTwoWayByDefault = true });

        public IEnumerable TotalItemsSource
        {
            get { return (IEnumerable)GetValue(TotalItemsSourceProperty); }
            set { SetValue(TotalItemsSourceProperty, value); }
        }

        public bool ShowRowNumber
        {
            get { return (bool)GetValue(ShowRowNumberProperty); }
            set { SetValue(ShowRowNumberProperty, value); }
        }


        public static readonly DependencyProperty PageIndexProperty = DependencyProperty.Register("PageIndex", typeof(int), typeof(PagingDataGrid), new FrameworkPropertyMetadata(1) { });//BindsTwoWayByDefault=true
        public static readonly DependencyProperty PageCountProperty = DependencyProperty.Register("PageCount", typeof(int), typeof(PagingDataGrid), new FrameworkPropertyMetadata(1) { BindsTwoWayByDefault = true });
        public static readonly DependencyProperty PageSizeProperty = DependencyProperty.Register("PageSize", typeof(int), typeof(PagingDataGrid), new FrameworkPropertyMetadata(1) { BindsTwoWayByDefault = true });


        public int PageIndex
        {
            get { return (int)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }
        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }
        public int PageSize
        {
            get { return (int)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }

        static PagingDataGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PagingDataGrid), new FrameworkPropertyMetadata(typeof(PagingDataGrid)));
        }

        /// <summary>
        /// 对外隐藏：避免绑定错数据
        /// </summary>
        private new IEnumerable ItemsSource { get; set; }

        public PagingDataGrid()
        {
            //base.ItemsSource
            //ItemsSourceProperty

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            BtnFirst = GetTemplateChild(PART_HomeButton) as Button;
            BtnPreview = GetTemplateChild(PART_PrevButton) as Button;
            BtnNext = GetTemplateChild(PART_NextButton) as Button;
            BtnLast = GetTemplateChild(PART_LastButton) as Button;
            BtnJump = GetTemplateChild(PART_JumpButton) as Button;
            CbPageSize = GetTemplateChild(PART_PageSizeComboBox) as ComboBox;
            TbPageIndex = GetTemplateChild(PART_PageIndexTextBox) as TextBox;
        }


        public void RefreshList(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }


        private Button btnFirst;

        private Button BtnFirst
        {
            get { return btnFirst; }
            set { btnFirst = value; }
        }

        private Button btnPreview;

        private Button BtnPreview
        {
            get { return btnPreview; }
            set { btnPreview = value; }
        }

        private Button btnNext;

        public Button BtnNext
        {
            get { return btnNext; }
            set { btnNext = value; }
        }

        private Button btnLast;

        public Button BtnLast
        {
            get { return btnLast; }
            set { btnLast = value; }
        }

        private ComboBox cbPageSize;

        public ComboBox CbPageSize
        {
            get { return cbPageSize; }
            set { cbPageSize = value; }
        }

        private Button btnJump;

        public Button BtnJump
        {
            get { return btnJump; }
            set { btnJump = value; }
        }

        private TextBox tbPageIndex;

        public TextBox TbPageIndex

        {
            get { return tbPageIndex; }
            set { tbPageIndex = value; }
        }



    }
}
