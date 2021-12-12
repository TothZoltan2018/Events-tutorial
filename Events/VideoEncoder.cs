using System;
using System.Threading;

namespace EventsByMosh
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
    class VideoEncoder
    {
        // 1 - Define a delegate. It determines the signature of the method (event handler in the subscriber)
        // which will be called when the publisher (this class) will raise an event.
        // 2 - Define an event based on that delegate
        // 3 - Raise the event

        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        //public event VideoEncodedEventHandler VideoEncoded;

        // Instead of the above 2 lines we can use a special delegate:
        // public delegate void EventHandler<TEventArgs>(object? sender, TEventArgs e);
        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        /// <summary>
        /// This method notifes all the subscribers
        /// </summary>
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video});
        }
    }
}
