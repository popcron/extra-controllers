using System.Runtime.InteropServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

namespace UnityEngine.InputSystem.LowLevel
{
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public struct GameCubeControllerState : IInputStateTypeInfo
    {
        public FourCC format => new FourCC('H', 'I', 'D');

        [InputControl(name = "xButton", displayName = "X", bit = (uint)Button1.X, format = "BIT", layout = "Button")]
        [InputControl(name = "aButton", displayName = "A", bit = (uint)Button1.A, format = "BIT", layout = "Button")]
        [InputControl(name = "bButton", displayName = "B", bit = (uint)Button1.B, format = "BIT", layout = "Button")]
        [InputControl(name = "yButton", displayName = "Y", bit = (uint)Button1.Y, format = "BIT", layout = "Button")]
        [InputControl(name = "leftTriggerButton", displayName = "L Button", bit = (uint)Button1.LButton, format = "BIT", layout = "Button")]
        [InputControl(name = "rightTriggerButton", displayName = "R Button", bit = (uint)Button1.RButton, format = "BIT", layout = "Button")]
        [InputControl(name = "zButton", displayName = "Z", bit = (uint)Button1.ZButton, format = "BIT", layout = "Button")]
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

        [InputControl(name = "leftStick", usage = "Primary2DMotion", processors = "stickDeadzone", displayName = "Left Joystick", layout = "Stick", format = "VCB2")]
        [InputControl(name = "leftStick/x", displayName = "X", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.05,clampMin=0,clampMax=1,normalizeMax=0.95,normalizeZero=0.5")]
        [InputControl(name = "leftStick/y", displayName = "Y", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0.05,clampMin=0,clampMax=1,normalizeMax=0.95,normalizeZero=0.5,invert")]
        [FieldOffset(3)]
        public byte joystickX;

        [FieldOffset(4)]
        public byte joystickY;

        [InputControl(name = "controlStick", usage = "Secondary2DMotion", processors = "stickDeadzone", displayName = "Control Stick", layout = "Stick", format = "VCB2")]
        [InputControl(name = "controlStick/x", displayName = "X", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0.05,clampMin=0,clampMax=1,normalizeMax=0.95,normalizeZero=0.5")]
        [InputControl(name = "controlStick/y", displayName = "Y", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.05,clampMin=0,clampMax=1,normalizeMax=0.95,normalizeZero=0.5,invert")]
        [FieldOffset(5)]
        public byte cStickX;

        [FieldOffset(6)]
        public byte cStickY;

        [InputControl(name = "leftTrigger", usage = "SecondaryTrigger", displayName = "L Trigger", layout = "Axis", shortDisplayName = "LB")]
        [FieldOffset(7)]
        public byte leftTrigger;


        [InputControl(name = "rightTrigger", usage = "SecondaryTrigger", displayName = "R Trigger", layout = "Axis", shortDisplayName = "RB")]
        [FieldOffset(8)]
        public byte rightTrigger;

        public enum Button1
        {
            X = 0,
            A = 1,
            B = 2,
            Y = 3,
            LButton = 4,
            RButton = 5,
            ZButton = 7
        }
    }
}