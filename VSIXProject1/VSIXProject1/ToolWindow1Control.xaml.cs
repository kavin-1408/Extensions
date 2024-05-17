using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio.Shell;
using Microsoft.Web.WebView2;
using Microsoft.Web.WebView2.Core;

namespace VSIXProject1
{
    /// <summary>
    /// Interaction logic for ToolWindow1Control.
    /// </summary>
    public partial class ToolWindow1Control : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindow1Control"/> class.
        /// </summary>
        public ToolWindow1Control()
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

            // load the webview2
            await webView.EnsureCoreWebView2Async(env);

            webView.Source = new Uri("https://google.com/");
            /*https://stackoverflow.com/questions/76375277/has-anyone-managed-to-successfully-host-a-webview2-control-in-a-toolwindow-in-a*/
        }
    }
}