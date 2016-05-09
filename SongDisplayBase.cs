using System.Windows;

namespace jPod {
   /// <summary>
   /// Base class to display content in SongDisplayView
   /// Classes which has any collection to display in SongDisplayView must inherit this class
   /// </summary>
   public class SongDisplayBase : NotifyPropertyChanged {
      #region Properties
      /// <summary>
      /// UIElement to display in SongdisplayView
      /// </summary>
      public UIElement SongDisplay {
         get { return mSongDisplay; }
         set {
            mSongDisplay = value;
            SongDisplayView.It.DataContext = this;
            OnPropertyChanged ("SongDisplay");
         }
      }
      UIElement mSongDisplay;
      #endregion
   }
}
