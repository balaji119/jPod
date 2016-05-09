using System.Collections.Generic;

namespace jPod {
   /// <summary>
   /// Represents all songs in library
   /// </summary>
   public class SongLibrary {
      #region Methods
      /// <summary>
      /// Adds song to the song collection
      /// </summary>
      /// <param name="song">Song object</param>
      public static void Add (Song song) {
         sSongs.Add (song);
      }
      #endregion

      #region Properties
      /// <summary>
      /// Collection of all songs in the library
      /// </summary>
      public static List<Song> AllSongs { get { return sSongs; } }
      #endregion

      #region Fields
      static List<Song> sSongs = new List<Song> ();
      #endregion
   }
}
