using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace jPod {
   /// <summary>
   /// Interaction logic for LibraryCtrl.xaml
   /// </summary>
   public partial class LibraryView : UserControl {
      public LibraryView () {
         InitializeComponent ();
         DataContext = this;
      }

      public IEnumerable<Library> LibraryElements { get { return Library.All; } }

      void ListView_SelectionChanged (object sender, SelectionChangedEventArgs e) {
         Library lib = e.AddedItems[0] as Library;
         lib.SetDisplay ();
      }
   }
}
