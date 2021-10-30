using System;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

namespace UnityEngine.InputSystem
{
    [InputControlLayout(stateType = typeof(GameCubeHIDInputReport))]
    public class GameCubeController : Gamepad
    {
        /// <summary>
        /// Also refered to as the generic joystick.
        /// </summary>
        public new StickControl leftStick => this["joystick"] as StickControl;

        /// <summary>
        /// Also called the C-Stick.
        /// </summary>
        public new StickControl rightStick => this["cStick"] as StickControl;

        /// <summary>
        /// The left trigger.
        /// </summary>
        public new AxisControl leftTrigger => this["leftTrigger"] as AxisControl;

        /// <summary>
        /// The right trigger.
        /// </summary>
        public new AxisControl rightTrigger => this["rightTrigger"] as AxisControl;

        /// <summary>
        /// This is the button that is pressed when the left trigger is fully down.
        /// </summary>
        public new ButtonControl leftShoulder => this["leftButton"] as ButtonControl;

        /// <summary>
        /// This is the button that is pressed when the right trigger is fully down.
        /// </summary>
        public new ButtonControl rightShoulder => this["rightButton"] as ButtonControl;

        /// <summary>
        /// The pathetic D-Pad.
        /// </summary>
        public new DpadControl dpad => this["dpad"] as DpadControl;

        /// <summary>
        /// The big green button.
        /// </summary>
        public new ButtonControl aButton => this["aButton"] as ButtonControl;

        /// <summary>
        /// The tiny red button under the A button.
        /// </summary>
        public new ButtonControl bButton => this["bButton"] as ButtonControl;

        /// <summary>
        /// The button that is to the right of the A button.
        /// </summary>
        public new ButtonControl xButton => this["xButton"] as ButtonControl;

        /// <summary>
        /// The button that is above the A button.
        /// </summary>
        public new ButtonControl yButton => this["yButton"] as ButtonControl;

        /// <summary>
        /// The button in the middle of the controller.
        /// </summary>
        public new ButtonControl startButton => this["startButton"] as ButtonControl;

        /// <summary>
        /// The button in the middle of the controller.
        /// </summary>
        public new ButtonControl selectButton => this["startButton"] as ButtonControl;

        /// <summary>
        /// The special Z button.
        /// </summary>
        public ButtonControl zButton => this["zButton"] as ButtonControl;

        #region Shims
        [Obsolete("The circle button is not a control on the GameCube controller.")]
        public new ButtonControl circleButton { get; }

        [Obsolete("The square button is not a control on the GameCube controller.")]
        public new ButtonControl squareButton { get; }

        [Obsolete("The triangle button is not a control on the GameCube controller.")]
        public new ButtonControl triangleButton { get; }

        [Obsolete("The cross button is not a control on the GameCube controller.")]
        public new ButtonControl crossButton { get; }

        [Obsolete("Right stick button doesn't exist on a GameCube controller.")]
        public new ButtonControl rightStickButton { get; }

        [Obsolete("Left stick button doesn't exist on a GameCube controller.")]
        public new ButtonControl leftStickButton { get; }

        [Obsolete("Button east cannot be inferred on a GameCube controller.")]
        public new ButtonControl buttonEast { get; }

        [Obsolete("Button south cannot be inferred on a GameCube controller.")]
        public new ButtonControl buttonSouth { get; }

        [Obsolete("Button north cannot be inferred on a GameCube controller.")]
        public new ButtonControl buttonNorth { get; }

        [Obsolete("Button west cannot be inferred on a GameCube controller.")]
        public new ButtonControl buttonWest { get; }
        #endregion

        /// <summary>
        /// The last used/added GameCube controller.
        /// </summary>
        public new static GameCubeController current { get; private set; }

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
            InputDeviceMatcher matcher = new InputDeviceMatcher().WithInterface("HID").WithCapability("vendorId", 0x79);
            InputSystem.RegisterLayout<GameCubeController>(matches: matcher);
        }
    }
}
