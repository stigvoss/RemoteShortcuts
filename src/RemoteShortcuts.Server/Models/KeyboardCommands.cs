using RemoteShortcuts.Shared;
using System;
using System.Linq;
using WindowsInput;
using WindowsInput.Native;

namespace RemoteShortcuts.Server.Models
{
    internal sealed class KeyboardCommands : IKeyboardCommands
    {
        private IKeyboardSimulator _keyboard;

        public KeyboardCommands(IKeyboardSimulator keyboard)
        {
            _keyboard = keyboard;
        }

        public void Press(params string[] keys)
        {
            if (keys is null || keys.Length < 1)
            {
                return;
            }

            if (keys.Length == 1)
            {
                PressOneKey(keys);
            }
            else
            {
                PressKeyCombination(keys);
            }
        }

        private void PressKeyCombination(string[] keys)
        {
            var modifiers = new VirtualKeyCode[keys.Length - 1];

            for (var index = 0; index < keys.Length - 1; index++)
            {
                var modifier = keys[index];

                if (Enum.TryParse<VirtualKeyCode>(modifier, out var modifierKeyCode))
                {
                    modifiers[index] = modifierKeyCode;
                }
                else
                {
                    return;
                }
            }

            var key = keys.Last();

            if (Enum.TryParse<VirtualKeyCode>(key, out var keyCode))
            {
                _keyboard.ModifiedKeyStroke(modifiers, keyCode);
            }
            else
            {
                return;
            }
        }

        private void PressOneKey(string[] keys)
        {
            var key = keys.Single();

            if (Enum.TryParse<VirtualKeyCode>(key, out var keyCode))
            {
                _keyboard.KeyPress(keyCode);
            }
        }
    }
}
