namespace EventsAndDelegates
{
    /// <summary>
    /// Notify delegate is used to create the event notify of same data type
    /// </summary>
    /// <param name="message">It takes the message</param>
    public delegate void Notify(string message);

    /// <summary>
    /// It will notify when the event is invoked
    /// </summary>
    internal class Notifier
    {
        /// <summary>
        /// Event of OnAction of type Delegate notify
        /// </summary>
        public event Notify OnAction;

        /// <summary>
        /// It checks for OnAction is null, if null means there is no method is registered to the delegate
        /// </summary>
        /// <param name="message">It takes the message it is string</param>
        public void Action(string message)
        {
            if (this.OnAction != null)
            {
                this.OnAction.Invoke(message);
            }
            else
            {
                Console.WriteLine("Not Registered");
            }
        }
    }
}