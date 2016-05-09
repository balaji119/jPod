namespace jPod {
   /// <summary>
   /// Represents a song
   /// </summary>
   public class Song {
      #region Constructor
      public Song (string songName, string albumName, string artistName, int duration) {
         Name = songName;
         ArtistName = artistName;
         AlbumName = albumName;
         Duration = duration;
      }
      #endregion

      #region Properties
      /// <summary>
      /// Name of the song
      /// </summary>
      public string Name { get; private set; }

      /// <summary>
      /// The album to which the song belongs to
      /// </summary>
      public string AlbumName { get; private set; }

      /// <summary>
      /// The artist to which the song belongs to
      /// </summary>
      public string ArtistName { get; private set; }

      /// <summary>
      /// Running duration of the song
      /// </summary>
      public int Duration { get; private set; }
      #endregion
   }
}
