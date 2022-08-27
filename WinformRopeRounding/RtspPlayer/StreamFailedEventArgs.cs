using System;

namespace PGSPanel.RtspPlayer
{
    public class StreamFailedEventArgs : EventArgs
    {
        public StreamFailedEventArgs(string error)
        {
            Error = error;
        }

        public string Error { get; }
    }
}
