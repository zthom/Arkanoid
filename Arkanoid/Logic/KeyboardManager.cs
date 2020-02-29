using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Arkanoid.Logic
{
    /// <summary>
    /// Stores state of all keys pressed and released
    /// </summary>
    public class KeyboardManager
    {
        private Dictionary<Key, bool> DictKeys { get; set; } = new Dictionary<Key, bool>();

        public void KeyDown(Key key)
        {
            DictKeys[key] = true;
        }

        public void KeyUp(Key key)
        {
            DictKeys[key] = false;
        }

        /// <summary>
        /// Returns if key is currently pressed or released
        /// </summary>
        public bool IsPressed(Key key)
        {
            if (DictKeys.ContainsKey(key))
                return DictKeys[key];

            return false;
        }
    }
}
