using System;
using System.Diagnostics;
using System.Windows;

namespace jPod {
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window {
      public MainWindow () {
         InitializeComponent ();
         AppDomain currentDomain = AppDomain.CurrentDomain;
         currentDomain.UnhandledException += new UnhandledExceptionEventHandler ((obj, args) => {
            Exception e = (Exception)args.ExceptionObject;
            Debug.WriteLine ("caught exception : " + e.Message);
         });
      }
   }
}
