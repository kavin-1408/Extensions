using Microsoft.VisualStudio.Shell;
using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WebView
{
    /// <summary>
    /// Interaction logic for WebViewControl.
    /// </summary>
    public partial class WebViewControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebViewControl"/> class.
        /// </summary>
        public WebViewControl()
        {
            InitializeComponent();

            ThreadHelper.JoinableTaskFactory.Run(async delegate {
                InitializeWebViewAsync();
            });
        }

        private async Task InitializeWebViewAsync()
        {
            // create webview2 environment and load the webview
            string webviewDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            webviewDirectory = Path.Combine(webviewDirectory, "MyWebView2Directory");
            Directory.CreateDirectory(webviewDirectory);

            CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(null, webviewDirectory);
            // load webview
            await webView.EnsureCoreWebView2Async(env);
            webView.Source = new Uri("C:\\Users\\kavin.rajkannu\\Desktop\\WebView\\WebView\\Resources\\Page\\index.html");//dynamic
        }
    }
}