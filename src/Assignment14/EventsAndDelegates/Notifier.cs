namespace Task1
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
        /// <param name="s">It takes the message</param>
        public void Action(string s)
        {
            if (this.OnAction != null)
            {
                this.OnAction.Invoke(s);
            }
            else
            {
                Console.WriteLine("Not Registered");
            }
        }
    }
}