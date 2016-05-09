using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace jPod {
   /// <summary>
   /// This class does various actios to song like pause, play etc..
   /// </summary>
   public class PlayControl : NotifyPropertyChanged {
      #region Methods
      async void  ManageSong (Song song) {
         if (mPlayState == PlayState.None) return;
         await Task.Run (() => { Thread.Sleep (song.Duration); });
         //await till the duration of song gets over, then play next song.
         PlayNextSong ();
      }

      void PlayNextSong () {
         Song song = mPlayable.PlayNext ();
         SongStatus = "Playing: " + song.Name;
         ManageSong (song);
      }
      #endregion

      #region Properties
      public IPlayable Playable {
         get { return mPlayable; }
         set { 
            mPlayable = value;
            SongStatus = "";
            mPlayState = PlayState.None;
         }
      }

      public string PausePlay {
         get { return mPausePlay; }
         set {
            mPausePlay = value;
            OnPropertyChanged ("PausePlay");
         }
      }
      string mPausePlay = "Play";

      public string SongStatus {
         get { return mSongStatus; }
         set {
            mSongStatus = value;
            OnPropertyChanged ("SongStatus");
         }
      }

      public ICommand PausePlayCommand {
         get {
            return new RelayCommand (
               x => {
                  if (mPlayState == PlayState.Playing) {
                     mPlayState = PlayState.Paused;
                     PausePlay = "Play";
                     SongStatus = "Paused: " + mPlayable.Pause().Name;
                  } else {
                     mPlayState = PlayState.Playing;
                     PausePlay = "Pause";
                     Song song  = mPlayable.Play();
                     SongStatus = "Playing: " + song.Name;
                     ManageSong (song);
                  }
               },
               y => { return Playable != null; }
               );
         }
      }

      public ICommand PlayPreviousCommand {
         get {
            return new RelayCommand (
               x => {
                  Song song = mPlayable.PlayPrevious ();
                  SongStatus = "Playing: " + song;
                  ManageSong (song);
               },
               y => { return mPlayState != PlayState.None; }
               );
         }
      }

      public ICommand PlayNext {
         get {
            return new RelayCommand (
               x => {
                  PlayNextSong ();
               },
               y => { return mPlayState != PlayState.None; }
               );
         }
      }

      public ICommand StopCommand {
         get {
            return new RelayCommand (
               x => {
                  mPlayState = PlayState.None;
                  mPlayable.Stop ();
                  PausePlay = "Play";
                  SongStatus = "";
               },
               y => { return mPlayState != PlayState.None; }
               );
         }
      }

      /// <summary>
      /// Singleton object
      /// </summary>
      public static PlayControl It {
         get {
            if (sIt == null) sIt = new PlayControl ();
            return sIt;
         }
      }
      static PlayControl sIt = null;
      #endregion

      #region Fields
      PlayState mPlayState = PlayState.None;
      IPlayable mPlayable;
      string mSongStatus = "";
      #endregion
   }
}
