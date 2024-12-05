using System;

namespace ArbitraryPixel.Common
{
    /// <summary>
    /// Event arguments for an event involving state change.
    /// </summary>
    /// <typeparam name="T">The type representing a state object.</typeparam>
    public class StateChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// The state before the state change occurred.
        /// </summary>
        public T PreviousState { get; private set; }

        /// <summary>
        /// The state after the state change occurred.
        /// </summary>
        public T CurrentState { get; private set; }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="previousState">The state before the state change occurred.</param>
        /// <param name="currentState">The state after the state change occurred.</param>
        public StateChangedEventArgs(T previousState, T currentState)
        {
            this.PreviousState = previousState;
            this.CurrentState = currentState;
        }
    }
}
