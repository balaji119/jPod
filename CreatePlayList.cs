using System.Windows.Input;

namespace jPod {
   class CreatePlayList : NotifyPropertyChanged {
      #region Properties
      public string PlayListName {
         get { return mPlayListName; }
         set {
            mPlayListName = value;
            OnPropertyChanged ("PlayListName");
         }
      }
      string mPlayListName;

      public ICommand CreatePlayListCommand {
         get {
            return new RelayCommand (
               x => {
                  PlayList.Add (mPlayListName);
                  PlayListName = "";
               },
               y => { return !string.IsNullOrWhiteSpace (mPlayListName); }
               );
         }
      }
      #endregion
   }
}
