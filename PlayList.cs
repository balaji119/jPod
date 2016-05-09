using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace jPod {
   /// <summary>
   /// Represents a play list
   /// </summary>
   public class PlayList : SongDisplayBase {
      #region Properties
      /// <summary>
      /// Name of the play list
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Collection of songs in this play list
      /// </summary>
      public ObservableCollection<Song> Songs { get { return mSongs; } }

      /// <summary>
      /// Collection of all play list
      /// </summary>
      public static ObservableCollection<PlayList> All { get { return sPlayLists; } }
      #endregion

      #region Methods
      /// <summary>
      /// Add song to this playlist
      /// </summary>
      public void AddSong (Song song) {
         mSongs.Add (song);
      }

      public void RemoveSong (Song song) {
         mSongs.Remove (song);
      }

      /// <summary>
      /// Set UIElement to SongDisplayView
      /// </summary>
      public void SetDisplay () {
         SongDisplay = new PlayListSongsView (mSongs, this);
      }
      /// <summary>
      /// Adds a play list to playlist collection
      /// </summary>
      /// <param name="name">Name of the playlist</param>
      public static void Add (string name) {
         PlayList pList = new PlayList { Name = name };
         sPlayLists.Add (pList);
      }
      #endregion

      #region Fields
      ObservableCollection<Song> mSongs = new ObservableCollection<Song> ();
      static ObservableCollection<PlayList> sPlayLists = new ObservableCollection<PlayList> ();
      #endregion
   }
}
