using System.Windows.Controls;

namespace jPod {
   /// <summary>
   /// Interaction logic for SongDisplayCtrl.xaml
   /// </summary>
   public partial class SongDisplayView : UserControl {
      public SongDisplayView () {
         InitializeComponent ();
         It = this;
      }

      public static SongDisplayView It;
   }
}
