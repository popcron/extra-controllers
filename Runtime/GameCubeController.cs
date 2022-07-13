using System;
using System.ComponentModel;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Haptics;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

namespace UnityEngine.InputSystem
{
    [InputControlLayout(stateType = typeof(GameCubeControllerState), isGenericTypeOfDevice = true)]
    public class GameCubeController : InputDevice, IDualMotorRumble
    {
        /// <summary>
        /// The right button in the middle section of the gamepad (called "menu" on Xbox
        /// controllers and "options" on PS4 controllers).
        /// </summary>
        /// <value>Control representing the right button in midsection.</value>
        public ButtonControl startButton { get; protected set; }

        /// <summary>
        /// The 4-way directional pad on the gamepad.
        /// </summary>
        /// <value>Control representing the d-pad.</value>
        public DpadControl dpad { get; protected set; }

        /// <summary>
        /// The left thumbstick on the controller.
        /// </summary>
        public Vector2Control leftStick { get; protected set; }

        /// <summary>
        /// The control stick using on the right of the controller.
        /// </summary>
        public Vector2Control controlStick { get; protected set; }

        /// <summary>
        /// The left trigger.
        /// </remarks>
        public AxisControl leftTrigger { get; protected set; }

        /// <summary>
        /// The right trigger.
        public AxisControl rightTrigger { get; protected set; }

        /// <summary>
        /// The left trigger button when depressed all the way.
        /// </remarks>
        public ButtonControl leftTriggerButton { get; protected set; }

        /// <summary>
        /// The right trigger button when depressed all the way.
        public ButtonControl rightTriggerButton { get; protected set; }

        public ButtonControl zButton { get; protected set; }

        public ButtonControl aButton { get; protected set; }

        public ButtonControl bButton { get; protected set; }

        public ButtonControl xButton { get; protected set; }

        public ButtonControl yButton { get; protected set; }

        public bool isPluggedIn 
        {
            get
            {
                float l = leftTrigger.ReadUnprocessedValue();
                float r = rightTrigger.ReadUnprocessedValue();
                return false;
            }
        }
        
        private DualMotorRumble rumble;

        /// <summary>
        /// Retrieve a gamepad button by its <see cref="GamepadButton"/> enumeration
        /// constant.
        /// </summary>
        /// <param name="control">Button to retrieve.</param>
        /// <exception cref="ArgumentException"><paramref name="control"/> is not a valid gamepad
        /// button value.</exception>
        public ButtonControl this[Control control]
        {
            get
            {
                switch (control)
                {
                    case Control.Start: return startButton;
                    case Control.Y: return yButton;
                    case Control.X: return xButton;
                    case Control.B: return bButton;
                    case Control.A: return aButton;
                    case Control.LButton: return leftTriggerButton;
                    case Control.RButton: return rightTriggerButton;
                    case Control.ZButton: return zButton;
                    case Control.DpadUp: return dpad.down;
                    case Control.DpadDown: return dpad.down;
                    case Control.DpadLeft: return dpad.left;
                    case Control.DpadRight: return dpad.right;
                    default:
                        throw new InvalidEnumArgumentException(nameof(control), (int)control, typeof(Control));
                }
            }
        }

        /// <summary>
        /// The last used/added GameCube controller.
        /// </summary>
        public static GameCubeController current { get; private set; }

        protected override void FinishSetup()
        {
            startButton = GetChildControl<ButtonControl>("startButton");
            yButton = GetChildControl<ButtonControl>("yButton");
            xButton = GetChildControl<ButtonControl>("xButton");
            bButton = GetChildControl<ButtonControl>("bButton");
            aButton = GetChildControl<ButtonControl>("aButton");
            leftTriggerButton = GetChildControl<ButtonControl>("leftTriggerButton");
            rightTriggerButton = GetChildControl<ButtonControl>("rightTriggerButton");
            zButton = GetChildControl<ButtonControl>("zButton");
            dpad = GetChildControl<DpadControl>("dpad");
            leftStick = GetChildControl<StickControl>("leftStick");
            controlStick = GetChildControl<StickControl>("controlStick");
            leftTrigger = GetChildControl<AxisControl>("leftTrigger");
            rightTrigger = GetChildControl<AxisControl>("rightTrigger");

            base.FinishSetup();
        }

        public override void MakeCurrent()
        {
            base.MakeCurrent();
            current = this;
        }

        protected override void OnRemoved()
        {
            base.OnRemoved();
            if (current == this)
            {
                current = null;
            }
        }

        public static void SelfRegister()
        {
            var mayflashAdapter = new InputDeviceMatcher().WithInterface("HID").WithCapability("vendorId", 0x0079);
            InputSystem.RegisterLayout<GameCubeController>(matches: mayflashAdapter);

            var weeWuGCAdapter = new InputDeviceMatcher().WithInterface("HID").WithCapability("vendorId", 0x057E).WithProduct("0x0337");
            InputSystem.RegisterLayout<GameCubeController>(matches: weeWuGCAdapter);
        }

        public void SetMotorSpeeds(float lowFrequency, float highFrequency)
        {
            rumble.SetMotorSpeeds(this, lowFrequency, highFrequency);
        }

        public void PauseHaptics()
        {
            rumble.PauseHaptics(this);
        }

        public void ResumeHaptics()
        {
            rumble.ResumeHaptics(this);
        }

        public void ResetHaptics()
        {
            rumble.ResetHaptics(this);
        }

        public enum Control
        {
            Start,
            Y,
            X,
            B,
            A,
            Button1,
            LButton,
            RButton,
            ZButton,
            DpadUp,
            DpadDown,
            DpadRight,
            DpadLeft,
            LeftJoystick,
            ControlStick,
            LTrigger,
            RTrigger
        }
    }
}
