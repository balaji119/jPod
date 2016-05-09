using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;

namespace jPod {
   /// <summary>
   /// Interaction logic for SongsView.xaml
   /// </summary>
   public partial class SongsView : UserControl, IPlayable {
      #region Constructor
      public SongsView (IEnumerable<Song> songs) {
         InitializeComponent ();
         DataContext = this;
         Songs = songs;
      }
      #endregion

      #region Properties
      /// <summary>
      /// Collection of play list
      /// </summary>
      public IEnumerable<PlayList> PlayLists { get { return PlayList.All; } }

      /// <summary>
      /// Collection of song
      /// </summary>
      public IEnumerable<Song> Songs { get; private set; }

      /// <summary>
      /// Represents selected index of list view
      /// </summary>
      public int SelectedIndex {
         get { return mSelectedIndex; }
         set { 
            mSelectedIndex = value;
            mSelectedSong = Songs.ElementAt(mSelectedIndex);
            //Sets focus to list view item at SelectedIndex.
            SListView.SelectedItems.Clear ();
            (SListView.ItemContainerGenerator.ContainerFromIndex (mSelectedIndex) as ListViewItem).IsSelected = true;
         }
      }

      #endregion

      #region Events
      void MenuItem_Click (object sender, System.Windows.RoutedEventArgs e) {
         string name = (e.Source as MenuItem).Header as string;
         var playList = PlayList.All.Where (x => x.Name == name).FirstOrDefault();
         if (mSelectedSong == null) return;
         playList.AddSong (mSelectedSong);
      }

      void ListView_SelectionChanged (object sender, SelectionChangedEventArgs e) {
         try {
            mSelectedSong = e.AddedItems[0] as Song;
            mSelectedIndex = (e.Source as ListView).SelectedIndex;
         } catch { }
      }
      #endregion

      #region Fields
      Song mSelectedSong = null;
      int mSelectedIndex = 0;
      #endregion

      #region IPlayable implementation
      public Song Play () {
         if (mSelectedSong == null) SelectedIndex = 0;
         return mSelectedSong;
      }

      public Song Pause () {
         return mSelectedSong;
      }

      public void Stop () {
         mSelectedIndex = -1;
      }

      public Song PlayNext () {
         int n = mSelectedIndex + 1;
         n = n % Songs.Count ();
         SelectedIndex = n;
         return mSelectedSong;
      }

      public Song PlayPrevious () {
         int n = mSelectedIndex - 1;
         n = n % Songs.Count();
         SelectedIndex = n;
         return mSelectedSong;
      }
      #endregion
   }
}
