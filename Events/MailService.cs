using System;

namespace EventsByMosh
{
    public class MailService
    {
        // Eventhandler: Naming convetion as below but works with any name
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MailService: Sending an email..." + e.Video.Title);
        }

        public void OnVideoEncoded2(object source, VideoEventArgs e)
        {
            Console.WriteLine("MailService2: Sending an email..." + e.Video.Title);
        }
    }
}   
