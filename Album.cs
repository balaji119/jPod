using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jPod {
   /// <summary>
   /// Represents an album
   /// </summary>
   public class Album : SongDisplayBase, IEquatable<Album> {
      #region Properties
      /// <summary>
      /// Name of the album
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Number of songs in this album
      /// </summary>
      public int SongCount { get { return Songs.Count; } }

      /// <summary>
      /// Number of artists in this album
      /// </summary>
      public int ArtistCount { get { return Artists.Count; } }

      /// <summary>
      /// Collection of artists in the album, which does not allows duplicate content to get added
      /// </summary>
      public HashSet<Artist> Artists = new HashSet<Artist> ();

      /// <summary>
      /// Collection of songs in the album
      /// </summary>
      public List<Song> Songs { get { return mSongs; } }

      /// <summary>
      /// Collection of all albums added to library
      /// </summary>
      public static IEnumerable<Album> All { get { return sAlbumDict.Values; } }
      #endregion

      #region Methods
      /// <summary>
      /// Add song to this album
      /// </summary>
      void AddSong (Song song) {
         mSongs.Add (song);
      }
      /// <summary>
      /// Compares 'this' album with the 'other' album
      /// </summary>
      /// <returns>True if both albums are equal otherwise false</returns>
      public bool Equals (Album other) {
         return Name.Equals (other.Name);
      }

      /// <summary>
      /// Overrides base Objects' equality comparision
      /// </summary>
      public override bool Equals (object obj) {
         return base.Equals (obj as Album);
      }

      /// <summary>
      /// Overrides base Objects' GetHashCode
      /// </summary>
      public override int GetHashCode () {
         if (Name == null) return 0;
         return Name.GetHashCode ();
      }

      /// <summary>
      /// Set UIElement to SongDisplayView
      /// </summary>
      public void SetDisplay () {
         SongDisplay = new SongsView (mSongs);
      }

      /// <summary>
      /// Add song and artist to album
      /// </summary>
      /// <param name="song">Song to be added to album</param>
      /// <param name="artist">artis to be added to album</param>
      public static void Add (Song song, Artist artist) {
         Album key = new Album { Name = song.ArtistName };
         Album album = null;
         // Check if the album 'key' is present in our dictionary
         // If it is present add the song to it, else create new one and add the song to it
         if (!sAlbumDict.TryGetValue (key, out album)) {
            album = new Album { Name = song.ArtistName };
            album.AddSong(song);
            sAlbumDict[album] = album;
         } else {
            album.AddSong(song);
         }
         // Album is stored in a HashSet, so we need not worry about duplicates.
         album.Artists.Add (artist);
      }
      #endregion

      #region Fields
      List<Song> mSongs = new List<Song> ();
      static Dictionary<Album, Album> sAlbumDict = new Dictionary<Album, Album> ();
      #endregion
   }
}
