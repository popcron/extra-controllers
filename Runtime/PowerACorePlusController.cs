using UnityEngine.InputSystem.Layouts;

namespace UnityEngine.InputSystem
{
    [InputControlLayout(stateType = typeof(HORIPADSwitchControllerHID))]
    public class PowerACorePlusController : Gamepad
    {
        /// <summary>
        /// The last used/added GameCube controller.
        /// </summary>
        public new static PowerACorePlusController current { get; private set; }

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
            InputDeviceMatcher matcher = new InputDeviceMatcher().
                WithInterface("HID").
                WithCapability("vendorId", 0x20d6).
                WithCapability("productId", 0xa711);
            InputSystem.RegisterLayout<PowerACorePlusController>("PowerA Core (Plus) Controller", matches: matcher);
        }
    }
}
