using System.Runtime.InteropServices;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace UnityEngine.InputSystem
{
    [StructLayout(LayoutKind.Explicit, Size = kSize)]
    internal struct DualMotorRumbleCommand : IInputDeviceCommandInfo
    {
        public static FourCC Type { get { return new FourCC('R', 'M', 'B', 'L'); } }

        internal const int kSize = 8 + sizeof(float) * 2;

        [FieldOffset(0)]
        public InputDeviceCommand baseCommand;

        [FieldOffset(8)]
        public float lowFrequencyMotorSpeed;

        [FieldOffset(12)]
        public float highFrequencyMotorSpeed;

        public FourCC typeStatic
        {
            get { return Type; }
        }

        public static DualMotorRumbleCommand Create(float lowFrequency, float highFrequency)
        {
            return new DualMotorRumbleCommand
            {
                baseCommand = new InputDeviceCommand(Type, kSize),
                lowFrequencyMotorSpeed = lowFrequency,
                highFrequencyMotorSpeed = highFrequency
            };
        }
    }
}
