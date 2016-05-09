using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Input;

namespace jPod {
   /// <summary>
   /// Interaction logic for AtristsView.xaml
   /// </summary>
   public partial class ArtistsView : UserControl {
      #region Constructor
      public ArtistsView () {
         InitializeComponent ();
         DataContext = this;
      }
      #endregion

      #region Properties
      public IEnumerable<Artist> Artists { get { return Artist.All; } }

      public IEnumerable<PlayList> PlayLists { get { return PlayList.All; } }

      public ICommand OpenCommand {
         get {
            return new RelayCommand (
               x => {
                  mSelectedArtist.SetDisplay ();
               },
               y => { return true; }
               );
         }
      }
      #endregion

      #region Events
      void ListView_SelectionChanged (object sender, SelectionChangedEventArgs e) {
         mSelectedArtist = e.AddedItems[0] as Artist;
      }

      void MenuItem_Click (object sender, System.Windows.RoutedEventArgs e) {
         var name = (e.Source as MenuItem).Header as string;
         var playList = PlayList.All.Where (x => x.Name == name).FirstOrDefault ();
         if (mSelectedArtist == null) return;
         mSelectedArtist.Songs.ForEach (
            x => { playList.AddSong (x); }
            );
      }
      #endregion

      #region Fields
      Artist mSelectedArtist = null;
      #endregion
   }
}
