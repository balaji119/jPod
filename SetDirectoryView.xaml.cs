﻿using System;
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

namespace jPod {
   /// <summary>
   /// Interaction logic for DirectoryView.xaml
   /// </summary>
   public partial class SetDirectoryView : UserControl {
      public SetDirectoryView () {
         InitializeComponent ();
         DataContext = new SetDirectory ();
      }
   }
}
