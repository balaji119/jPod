namespace jPod {
   /// <summary>
   /// Defines a playable collection
   /// </summary>
   public interface IPlayable {
      /// <summary>
      /// Defines the method which plays a song
      /// </summary>
      /// <returns>The song which this method plays</returns>
      Song Play ();
      /// <summary>
      /// Defines the method which pauses a song
      /// </summary>
      /// <returns>The song which this method pauses</returns>
      Song Pause ();
      /// <summary>
      /// Defines the method which stops a song
      /// </summary>
      void Stop ();
      /// <summary>
      /// Defines the method whic plays the next song
      /// </summary>
      /// <returns>The song which this method plays</returns>
      Song PlayNext ();
      /// <summary>
      /// Defines the method whic plays the previous song
      /// </summary>
      /// <returns>The song which this method plays</returns>
      Song PlayPrevious ();
   }
}
