using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace AsyncApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private int counter;
        private List<string> list;

        public MainWindow()
        {
            InitializeComponent();

            list = new List<string> {
                    "http://www.yahoo.co.jp/",
                    "http://www.google.co.jp/",
                    "http://www.msn.co.jp/"
            };
        }

        private async void BtnGetUrl_Click(object sender, RoutedEventArgs e)
        {
            this.btnGetUrl.IsEnabled = false;
            //list.ForEach(async x => {
            //    this.ShowPage(x);
            //    System.Threading.Thread.Sleep(3000);
            //    }
            //    );
            await ShowPage(list[0]);
            System.Threading.Thread.Sleep(3000);
            this.btnGetUrl.IsEnabled = true;
        }

        private async Task ShowPage(string url)
        {
            //HttpClient httpClient = new HttpClient();
            //var html = await httpClient.GetStringAsync(url);
            //this.WebBrowser.NavigateToString(html);
        }

        private void BtnShowMessage_Click(object sender, RoutedEventArgs e)
        {
            this.lblCounter.Content = this.counter += 1;
        }
    }
}
