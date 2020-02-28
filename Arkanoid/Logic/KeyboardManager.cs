using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Arkanoid.Logic
{
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

        public bool IsPressed(Key key)
        {
            if (DictKeys.ContainsKey(key))
                return DictKeys[key];

            return false;
        }
    }
}
