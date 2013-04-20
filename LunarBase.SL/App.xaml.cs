using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LunarBase.Library;

namespace LunarBase.SL
{
    public partial class App : Application
    {

        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppCache.ApplicationDomain = HtmlPage.Document.DocumentUri.AbsoluteUri.Substring(
                                            0, HtmlPage.Document.DocumentUri.AbsoluteUri.IndexOf(HtmlPage.Document.DocumentUri.AbsolutePath));
            Resources.Add("ApplicationViewModel", AppCache.ApplicationViewModel);
            this.RootVisual = new MainPage();
            // HtmlDocument requires using System.Windows.Browser; 
            HtmlDocument doc = HtmlPage.Document;
            ////Enable the HTML textbox on the page and say hello
            //doc.GetElementById("Text1").SetProperty("disabled", false);
            //doc.GetElementById("Text1").SetAttribute("value",
            //    "This text set from managed code.");
            //Set up some scriptable managed types for access from Javascript.
            ScriptableManagedType smt = new ScriptableManagedType();

            HtmlPage.RegisterScriptableObject("SLapp", smt);
        }

        private void Application_Exit(object sender, EventArgs e)
        {

        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }
    }
}
