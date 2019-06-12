using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
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
        private List<string> urlList;

        public MainWindow()
        {
            InitializeComponent();

            urlList = new List<string> {
                    "http://www.yahoo.co.jp/",
                    "http://www.google.co.jp/",
                    "http://www.msn.co.jp/",
                    "http://www.naver.jp/",
                    //"http://www.cybozu.net/",
                    "http://www.aol.jp/",
                    //"http://home.hi-ho.ne.jp/",
                    "https://html5test.com/",
            };

            // JavaScriptのエラー表示を抑止する
            var axIWebBrowser2 = typeof(WebBrowser).GetProperty("AxIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            var comObj = axIWebBrowser2.GetValue(this.WebBrowser, null);
            comObj.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, comObj, new object[] { true });
        }

        private async void GetPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.GetUrlButton.IsEnabled = false;
            await Task.Run(()=> ShowPage());
            this.GetUrlButton.IsEnabled = true;
        }

        private async Task ShowPage()
        {
            HttpClient httpClient = new HttpClient();
            foreach(var url in this.urlList) { 
                var html = await httpClient.GetStringAsync(url);
                this.Dispatcher.Invoke((Action)(() => {
                    //this.WebBrowser.NavigateToString(html);
                    //this.WebView.NavigateToString(html);
                    this.WebBrowser.Navigate(url);
                    this.WebView.Navigate(url);
                }));
                System.Threading.Thread.Sleep(3000);
            }
            //urlList.ForEach(async (url) =>
            //{
            //    var html = await httpClient.GetStringAsync(url);
            //    this.Dispatcher.Invoke((Action)(() => {
            //        this.WebBrowser.NavigateToString(html);
            //    }));
            //    System.Threading.Thread.Sleep(5000);
            //});
        }
        private void CountUpButton_Click(object sender, RoutedEventArgs e)
        {
            this.CounterLable.Content = this.counter += 1;
        }
    }
}
