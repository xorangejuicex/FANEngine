using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace FANEngine
{
    static class Input
    {
        static private KeyboardState prevState;
        static private KeyboardState curState;

        public static void Update()
        {
            prevState = curState;
            curState = Keyboard.GetState();
        }

        public static bool IsKeyDown(Keys key)
        {
            return curState.IsKeyDown(key);
        }

        public static bool IsKeyReleased(Keys key)
        {
            return curState.IsKeyUp(key) &&
                prevState.IsKeyDown(key);
        }

        public static bool IsKeyTriggered(Keys key)
        {
            return curState.IsKeyDown(key) &&
                prevState.IsKeyUp(key);
        }
    }
}
