using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace jPod {
   /// <summary>
   /// This class is resposible for choosing song directories
   /// </summary>
   public class SetDirectory : NotifyPropertyChanged{
      #region Property
      /// <summary>
      /// Collection of directories
      /// </summary>
      public static ObservableCollection<Directory> Directories { get { return sDirs; } }

      /// <summary>
      /// Command to choose directory
      /// </summary>
      public ICommand SetDirectoryCommand {
         get {
            return new RelayCommand (x => {
               using (FolderBrowserDialog dialog = new FolderBrowserDialog ()) {
                  if (dialog.ShowDialog () == DialogResult.OK) {
                     var path = dialog.SelectedPath;
                     sDirs.Add (new Directory { DirectoryName = path });
                     // ScanSongs is a time consuming process, so calling in a new thread.
                     new Thread (delegate () {
                        ScanSongs (path);
                     }).Start ();
                  }
               }
            }, y => {
               // As of now not allowing to create more than one directory.
               return sDirs.Count == 0;
            });
         }
      }
      #endregion

      #region Methods
      /// <summary>
      /// Scans for mp3 files in the choosen directory and subdirectories and adds it to library
      /// </summary>
      /// <param name="dir"></param>
      public void ScanSongs (string dir) {
         DirectoryInfo di = new DirectoryInfo (dir);
         var files = di.GetFiles ("*.mp3", SearchOption.AllDirectories);
         foreach (var file in files) {
            // Used open source library to get mp3 file information
            TagLib.File tf = TagLib.File.Create (file.FullName);
            var title = string.IsNullOrWhiteSpace (tf.Tag.Title) ? "Unknown" : tf.Tag.Title;
            var album = string.IsNullOrWhiteSpace (tf.Tag.Album) ? "Unknown" : tf.Tag.Title;
            var artist = tf.Tag.AlbumArtists.FirstOrDefault ();
            var song = new Song (title, album,
               string.IsNullOrWhiteSpace (artist) ? "Unknown" : artist,
               // storing time in milliseconds. Discarding hour and milliseconds for simplicity.
               (tf.Properties.Duration.Minutes*60 + tf.Properties.Duration.Seconds)*1000);
            SongLibrary.Add (song);
            Album.Add (song, Artist.Add (song));
         }
      }
      #endregion

      #region Fields
      static ObservableCollection<Directory> sDirs = new ObservableCollection<Directory> ();
      #endregion
   }

   /// <summary>
   /// Represents a direcoty
   /// </summary>
   public struct Directory{
      public string DirectoryName { get; set; }
   }
}
