using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class InputManager
    {
        private MouseState _previousMouseState;
        private MouseState _currentMouseState;
        private KeyboardState _previousKeyboardState;
        private KeyboardState _currentKeyboardState;
        private Keys lastKey;

        public InputManager()
        {

        }

        public void Update()
        {
            _previousMouseState = _currentMouseState; ;
            _previousKeyboardState = _currentKeyboardState;
            _currentMouseState = Mouse.GetState();
            _currentKeyboardState = Keyboard.GetState();
        }

        public Vector2 MousePosition
        {
            get { return new Vector2(_currentMouseState.Position.X, _currentMouseState.Position.Y); }
        }

        public bool LeftMouseButtonPressed
        {
            get { return _currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released; }
        }

        public bool RightMouseButtonPressed
        {
            get { return _currentMouseState.RightButton == ButtonState.Pressed && _previousMouseState.RightButton == ButtonState.Released; }
        }

        public bool LeftMouseButtonHolding
        {
            get { return _currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Pressed; }
        }

        public bool LeftMouseButtonReleased
        {
            get { return _currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed; }
        }

        public bool isKeyPressed(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key);
        }

        public bool isKeyHolding(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyDown(key);
        }

        public bool isKeyReleased(Keys key)
        {
            return _currentKeyboardState.IsKeyUp(key) && _previousKeyboardState.IsKeyDown(key);
        }

        public StringBuilder WriteToString(StringBuilder stringBuilder)
        {
            //check if space was pressed and add it to string
            if (isKeyReleased(Keys.Space))
            {
                stringBuilder.Append(" ");
            }
            //loop through alfabet
            for (Keys key = Keys.A; key < Keys.LeftWindows; key++)
            {
                //if key is released check if determine whether key should be uppercase or lowercase and add it to the string
                if(isKeyReleased(key))
                {
                    if(_currentKeyboardState.IsKeyDown(Keys.LeftShift) || _currentKeyboardState.IsKeyDown(Keys.RightShift))
                    {
                        stringBuilder.Append(key.ToString());
                    }
                    else
                    {
                        stringBuilder.Append(key.ToString().ToLower());
                    }
                }
            }       
            //if backspace is pressed remove last character in string
            if(isKeyReleased(Keys.Back) && stringBuilder.Length > 0)
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            return stringBuilder;
        }
    }
}