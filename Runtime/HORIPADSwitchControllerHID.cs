using System.Runtime.InteropServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace UnityEngine.InputSystem
{
    [StructLayout(LayoutKind.Explicit, Size = 20)]
    public struct HORIPADSwitchControllerHID : IInputStateTypeInfo
    {
        public FourCC format => new FourCC('H', 'I', 'D');

        [InputControl(name = "dpad", format = "BIT", layout = "Dpad", bit = 24, sizeInBits = 4, defaultState = 8)]
        [InputControl(name = "dpad/up", format = "BIT", layout = "DiscreteButton", parameters = "minValue=7,maxValue=1,nullValue=8,wrapAtValue=7", bit = 24, sizeInBits = 4)]
        [InputControl(name = "dpad/right", format = "BIT", layout = "DiscreteButton", parameters = "minValue=1,maxValue=3", bit = 24, sizeInBits = 4)]
        [InputControl(name = "dpad/down", format = "BIT", layout = "DiscreteButton", parameters = "minValue=3,maxValue=5", bit = 24, sizeInBits = 4)]
        [InputControl(name = "dpad/left", format = "BIT", layout = "DiscreteButton", parameters = "minValue=5, maxValue=7", bit = 24, sizeInBits = 4)]
        [InputControl(name = "buttonNorth", displayName = "X", shortDisplayName = "X", bit = (uint)Button.North)]
        [InputControl(name = "buttonSouth", displayName = "B", shortDisplayName = "B", bit = (uint)Button.South, usage = "Back")]
        [InputControl(name = "buttonWest", displayName = "Y", shortDisplayName = "Y", bit = (uint)Button.West, usage = "SecondaryAction")]
        [InputControl(name = "buttonEast", displayName = "A", shortDisplayName = "A", bit = (uint)Button.East, usage = "PrimaryAction")]
        [InputControl(name = "leftStickPress", displayName = "Left Stick", bit = (uint)Button.StickL)]
        [InputControl(name = "rightStickPress", displayName = "Right Stick", bit = (uint)Button.StickR)]
        [InputControl(name = "leftShoulder", displayName = "L", shortDisplayName = "L", bit = (uint)Button.L)]
        [InputControl(name = "rightShoulder", displayName = "R", shortDisplayName = "R", bit = (uint)Button.R)]
        [InputControl(name = "leftTrigger", displayName = "ZL", shortDisplayName = "ZL", format = "BIT", bit = (uint)Button.ZL)]
        [InputControl(name = "rightTrigger", displayName = "ZR", shortDisplayName = "ZR", format = "BIT", bit = (uint)Button.ZR)]
        [InputControl(name = "start", displayName = "Plus", bit = (uint)Button.Plus, usage = "Menu")]
        [InputControl(name = "select", displayName = "Minus", bit = (uint)Button.Minus)]
        [FieldOffset(0)]
        public uint buttons;

        [InputControl(name = "leftStick", offset = 0, format = "VCB2", layout = "Stick")]
        [InputControl(name = "rightStick", offset = 0, format = "VCB2", layout = "Stick")]

        [InputControl(name = "leftStick/y", offset = 4, format = "USHT", parameters = "invert,normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
        [FieldOffset(4)] public ushort leftStickY;

        [InputControl(name = "rightStick/y", offset = 6, format = "USHT", parameters = "invert,normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
        [FieldOffset(6)] public ushort rightStickY;

        [InputControl(name = "rightStick/x", offset = 5, format = "USHT", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
        [FieldOffset(8)] public ushort rightStickX;

        [InputControl(name = "leftStick/x", offset = 3, format = "USHT", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
        [FieldOffset(10)] public ushort leftStickX;

        public float leftTrigger => ((buttons & (1 << (int)Button.ZL)) != 0) ? 1f : 0f;

        public float rightTrigger => ((buttons & (1 << (int)Button.ZR)) != 0) ? 1f : 0f;

        public enum Button
        {
            North = 11,
            South = 9,
            West = 8,
            East = 10,

            StickL = 18,
            StickR = 19,
            L = 12,
            R = 13,

            ZL = 14,
            ZR = 15,
            Plus = 17,
            Minus = 16,

            X = North,
            B = South,
            Y = West,
            A = East,
        }

        public HORIPADSwitchControllerHID WithButton(Button button, bool value = true)
        {
            var bit = (uint)1 << (int)button;
            if (value)
                buttons |= bit;
            else
                buttons &= ~bit;
            // dpad default state
            buttons |= 8 << 24;
            //leftStickX = 0x8000;
            //leftStickY = 0x8000;
            //rightStickX = 0x8000;
            //rightStickY = 0x8000;
            return this;
        }
    }
}
