using System;

namespace EventsByMosh
{
    // https://www.youtube.com/watch?v=jQgwEsJISy0
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video(){ Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); // publisher
            var mailService = new MailService(); // subscriber 1
            var messageService = new MessageService(); // subscriber 2

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; // The event is a list of pointers to methods
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded2;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            videoEncoder.Encode(video);
        }
    }
}
