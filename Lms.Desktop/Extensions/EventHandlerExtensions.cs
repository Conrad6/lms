using System;

namespace Lms.Desktop.Extensions
{
    public static class EventHandlerExtensions
    {
        public static void Raise(this EventHandler handler, object sender)
        {
            handler?.Invoke(sender, System.EventArgs.Empty);
        }

        public static void Raise<TEventArgs>(this EventHandler<TEventArgs> handler, object sender, TEventArgs args)
            where TEventArgs : System.EventArgs
        {
            handler?.Invoke(sender, args);
        }
    }
}