using System;
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
   /// Interaction logic for PlayListSongsView.xaml
   /// </summary>
   public partial class PlayListSongsView : UserControl, IPlayable {
      #region Constructor
      public PlayListSongsView (IEnumerable<Song> songs, PlayList playList) {
         InitializeComponent ();
         DataContext = this;
         Songs = songs;
         mPlayList = playList;
         PlayControl.It.Playable = this;
      }
      #endregion

      #region Properties
      /// <summary>
      /// Represents the selected index of list view
      /// </summary>
      public int SelectedIndex {
         get { return mSelectedIndex; }
         set {
            mSelectedIndex = value;
            mSelectedSong = Songs.ElementAt (mSelectedIndex);
            //Sets focus to list view item at SelectedIndex.
            SListView.SelectedItems.Clear ();
            (SListView.ItemContainerGenerator.ContainerFromIndex (mSelectedIndex) as ListViewItem).IsSelected = true;
         }
      }

      /// <summary>
      /// Collection of song in the playlist
      /// </summary>
      public IEnumerable<Song> Songs { get; private set; }

      /// <summary>
      /// Removes the selected song
      /// </summary>
      public ICommand RemoveCommand {
         get {
            return new RelayCommand (x => {
               SListView.SelectedIndex = -1;
               mPlayList.RemoveSong (mSelectedSong);
            }, y => {
               return true;
            });
         }
      }
      #endregion

      #region Events
      private void ListView_SelectionChanged (object sender, SelectionChangedEventArgs e) {
         try {
            // This try cathc is used to supress out of bound exception.
            // TO DO: choose a better way.
            mSelectedSong = e.AddedItems[0] as Song;
            mSelectedIndex = (e.Source as ListView).SelectedIndex;
         } catch { }
      }
      #endregion

      #region Fields
      Song mSelectedSong = null;
      int mSelectedIndex = 0;
      PlayList mPlayList;
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
         n = n % Songs.Count ();
         SelectedIndex = n;
         return mSelectedSong;
      }
      #endregion
   }
}
