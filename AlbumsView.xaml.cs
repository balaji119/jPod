using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Input;

namespace jPod {
   /// <summary>
   /// Interaction logic for AlbumsView.xaml
   /// </summary>
   public partial class AlbumsView : UserControl {
      #region Constructors
      public AlbumsView () {
         InitializeComponent ();
         DataContext = this;
      }
      #endregion

      #region Properties
      public IEnumerable<Album> Albums { get { return Album.All; } }

      public IEnumerable<PlayList> PlayLists { get { return PlayList.All; } }

      public ICommand OpenCommand {
         get {
            return new RelayCommand (
               x => {
                  mSelectedAlbum.SetDisplay ();
               },
               y => { return true; }
               );
         }
      }
      #endregion

      #region Events
      void MenuItem_Click (object sender, System.Windows.RoutedEventArgs e) {
         var name = (e.Source as MenuItem).Header as string;
         var playList = PlayList.All.Where (x => x.Name == name).FirstOrDefault ();
         if (mSelectedAlbum == null) return;
         mSelectedAlbum.Songs.ForEach (
            x => { playList.AddSong (x); }
            );
      }

      void ListView_SelectionChanged (object sender, SelectionChangedEventArgs e) {
         mSelectedAlbum = e.AddedItems[0] as Album;
      }
      #endregion

      #region Fields
      Album mSelectedAlbum = null;
      #endregion
   }
}
