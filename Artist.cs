using System;
using System.Collections.Generic;

namespace jPod {
   /// <summary>
   /// Represents an Artist
   /// </summary>
   public class Artist : SongDisplayBase, IEquatable<Artist> {
      #region Properties
      /// <summary>
      /// Name of the artist
      /// </summary>
      public string Name { get; private set; }

      /// <summary>
      /// Number of songs sung by this artist
      /// </summary>
      public int SongCount { get { return Songs.Count; } }

      /// <summary>
      /// Collection of song sung by thsi artist
      /// </summary>
      public List<Song> Songs { get { return mSongs; } }

      /// <summary>
      /// Collection of all artists added to library
      /// </summary>
      public static IEnumerable<Artist> All { get { return sArtistsDict.Values; } }
      #endregion

      #region Methods
      /// <summary>
      /// Add song to this artist
      /// </summary>
      void AddSong (Song song) {
         mSongs.Add (song);
      }
      /// <summary>
      /// Compares 'this' artist to that of 'other' artist
      /// </summary>
      /// <returns>True if both are equal otherwise false</returns>
      public bool Equals (Artist other) {
         if (other.Name == null) return false;
         return Name.Equals (other.Name);
      }

      /// <summary>
      /// Overrides base Objects' equality comparision
      /// </summary>
      public override bool Equals (object obj) {
         return base.Equals (obj as Artist);
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
      /// Add song to artist
      /// </summary>
      /// <param name="song">Song to be added to artist</param>
      /// <returns>Aritst if new artist is created, otherwise null</returns>
      public static Artist Add (Song song) {
         Artist key = new Artist { Name = song.ArtistName };
         Artist artist = null;
         // Check if the artist 'key' is present in our dictionary
         // If present add the song to the artist, else create new artist and add the song to it.
         if (!sArtistsDict.TryGetValue (key, out artist)) {
            artist = new Artist { Name = song.ArtistName };
            artist.AddSong (song);
            sArtistsDict[artist] = artist;
            return artist;
         }
         artist.AddSong (song);
         return null;
      }
      #endregion

      #region Fields
      List<Song> mSongs = new List<Song> ();
      static Dictionary<Artist, Artist> sArtistsDict = new Dictionary<Artist, Artist> ();
      #endregion
   }
}
