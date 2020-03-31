using System.Runtime.InteropServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

namespace UnityEngine.InputSystem.LowLevel
{
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public struct GameCubeHIDInputReport : IInputStateTypeInfo
    {
        public FourCC format => new FourCC('H', 'I', 'D');

        [InputControl(name = "xButton", displayName = "X", bit = 0, format = "BIT", layout = "Button")]
        [InputControl(name = "aButton", displayName = "A", bit = 1, format = "BIT", layout = "Button")]
        [InputControl(name = "bButton", displayName = "B", bit = 2, format = "BIT", layout = "Button")]
        [InputControl(name = "yButton", displayName = "Y", bit = 3, format = "BIT", layout = "Button")]
        [InputControl(name = "leftButton", displayName = "L Button", bit = 4, format = "BIT", layout = "Button")]
        [InputControl(name = "rightButton", displayName = "R Button", bit = 5, format = "BIT", layout = "Button")]
        [InputControl(name = "zButton", displayName = "Z", bit = 7, format = "BIT", layout = "Button")]
        [FieldOffset(1)]
        public byte faceButtons;

        [InputControl(name = "startButton", displayName = "Start", bit = 1, format = "BIT", layout = "Button")]
        [FieldOffset(2)]
        public byte startButton;

        [InputControl(name = "dpad", displayName = "Start", bit = 3, format = "BIT", layout = "Dpad", sizeInBits = 4)]
        [InputControl(name = "dpad/up", displayName = "Up", bit = 4, format = "BIT", layout = "Button")]
        [InputControl(name = "dpad/left", displayName = "Left", bit = 7, format = "BIT", layout = "Button")]
        [InputControl(name = "dpad/down", displayName = "Down", bit = 6, format = "BIT", layout = "Button")]
        [InputControl(name = "dpad/right", displayName = "Right", bit = 5, format = "BIT", layout = "Button")]
        [FieldOffset(2)]
        public byte dpad;

        [InputControl(name = "joystick", displayName = "Joystick", layout = "Stick", format = "VCB2")]
        [InputControl(name = "joystick/x", displayName = "X", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
        [InputControl(name = "joystick/y", displayName = "Y", offset = 1, format = "BYTE", parameters = "invert,normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
        [FieldOffset(3)]
        public byte joystickX;

        [FieldOffset(4)]
        public byte joystickY;

        [InputControl(name = "cStick", displayName = "C Stick", layout = "Stick", format = "VCB2")]
        [InputControl(name = "cStick/x", displayName = "X", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
        [InputControl(name = "cStick/y", displayName = "Y", offset = 0, format = "BYTE", parameters = "invert,normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
        [FieldOffset(5)]
        public byte cStickX;

        [FieldOffset(6)]
        public byte cStickY;

        [InputControl(name = "leftTrigger", displayName = "L Trigger", layout = "Axis")]
        [FieldOffset(7)]
        public byte leftTrigger;


        [InputControl(name = "rightTrigger", displayName = "R Trigger", layout = "Axis")]
        [FieldOffset(8)]
        public byte rightTrigger;
    }
}