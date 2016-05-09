using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
namespace jPod {
   #region enum PlayState
   /// <summary>Describes the state of this application</summary>
   enum PlayState {
      None,
      Playing,
      Paused
   }
   #endregion

   #region class RelayCommand
   /// <summary>ICommand implementation</summary>
   public class RelayCommand : ICommand {
      #region Contructors
      /// <summary>Simple constructor takes an execute action handler.</summary>
      public RelayCommand (Action<object> execute) : this (execute, null) { }
      /// <summary>Accepts a handler and predicate parameters.</summary>
      public RelayCommand (Action<object> execute, Func<object, bool> canExecute) { mExecute = execute; mCanExecute = canExecute; }
      #endregion

      #region Methods
      /// <summary>This method is called by the command framework to check if "this" command can be executed.</summary>
      public bool CanExecute (object parameter) {
         try {
            return mCanExecute == null ? true : mCanExecute (parameter);
         } catch (Exception ex) {
            Debug.WriteLine ("Error in CanExecute: " + ex.Message);
            return false;
         }
      }

      /// <summary>This method is called by the command framework to execute "this" command.</summary>
      public void Execute (object parameter) { if (mExecute != null) mExecute (parameter); }
      #endregion

      #region Events
      /// <summary>This event is raised by the command manger framework.</summary>
      public event EventHandler CanExecuteChanged {
         add { CommandManager.RequerySuggested += value; }
         remove { CommandManager.RequerySuggested -= value; }
      }
      #endregion

      #region Private data
      readonly Action<object> mExecute;
      readonly Func<object, bool> mCanExecute;
      #endregion
   }
   #endregion

   #region class NotifyPropertyChanged
   /// <summary>
   /// INotifyPropertyChanged implementation
   /// </summary>
   public class NotifyPropertyChanged: INotifyPropertyChanged {
      public event PropertyChangedEventHandler PropertyChanged;

      public void OnPropertyChanged (string value) {
         if (PropertyChanged != null) {
            PropertyChanged (this, new PropertyChangedEventArgs (value));
         }
      }
   }
   #endregion

}
