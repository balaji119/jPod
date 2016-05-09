using System.Collections.Generic;
using System.Windows.Controls;

namespace jPod {
   /// <summary>
   /// Interaction logic for PlayListCtrl.xaml
   /// </summary>
   public partial class PlayListView : UserControl {
      public PlayListView () {
         InitializeComponent ();
         DataContext = this;
      }

      public IEnumerable<PlayList> PlayLists { get { return PlayList.All; } }

      private void ListView_SelectionChanged (object sender, SelectionChangedEventArgs e) {
         PlayList pl = e.AddedItems[0] as PlayList;
         pl.SetDisplay ();
      }
   }
}
