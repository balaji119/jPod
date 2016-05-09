using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace jPod {
   /// <summary>
   /// Represents song library containig artists, album etc..
   /// </summary>
   public class Library: SongDisplayBase {
      #region Properties
      /// <summary>
      /// Name of the library element
      /// </summary>
      public string Name { get; private set; }

      /// <summary>
      /// The View associated with the library element
      /// </summary>
      public UIElement View { get; private set; }

      /// <summary>
      /// Collection of all library element
      /// </summary>
      public static List<Library> All { get { return sPlayLists; } }
      #endregion

      #region Methods
      /// <summary>
      /// Set view of this library to SongDisplayView
      /// </summary>
      public void SetDisplay () {
         SongDisplay = View;
         if (View is IPlayable) PlayControl.It.Playable = View as IPlayable;
         else PlayControl.It.Playable = null;
      }
      /// <summary>
      /// Loads all library element
      /// When you create new library element, add it here.
      /// </summary>
      static Library () {
         sPlayLists.Add (new Library { Name = "Songs", View = new SongsView (SongLibrary.AllSongs) });
         sPlayLists.Add (new Library { Name = "Artists", View = new ArtistsView () });
         sPlayLists.Add (new Library { Name = "Albums", View = new AlbumsView () });
      }
      #endregion

      #region Fields
      static List<Library> sPlayLists = new List<Library> ();
      #endregion
   }
}
