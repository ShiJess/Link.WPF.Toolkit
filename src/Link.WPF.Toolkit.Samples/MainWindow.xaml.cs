using Link.WPF.Toolkit.Samples.View;
using System;
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
#if NET40
using System.Windows.Interactivity;
#endif


namespace Link.WPF.Toolkit.Samples
{
   
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.Items.Add("111");
            dataGrid.Items.Add("111");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LinkMessageBox messageBox = new LinkMessageBox();
            messageBox.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.mask.ShowMask();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.mask.HideMask();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.mask.ShowWait();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            WindowStyleTest win = new WindowStyleTest();
            win.Owner = this;
            win.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            WindowMainTest win = new WindowMainTest();
            win.Owner = this;
            win.ShowDialog();
        }
    }
}
