namespace RemoteShortcuts.Shared
{
    public interface IKeyboardCommands
    {
        /// <summary>
        /// Execute keyboard key presses.
        /// When using multiple keys, all but the last will be modifiers.
        /// </summary>
        /// <param name="keys"></param>
        void Press(params string[] keys);
    }
}