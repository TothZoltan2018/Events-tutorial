using System;

namespace EventsByMosh
{
    public class MessageService
    {
        // Eventhandler: Naming convetion as below but works with any name
        public void OnVideoEncoded(object sender, VideoEventArgs e)
        {
            Console.WriteLine("MessageService: Sending a Text message..." + e.Video.Title);
        }
    }
}
