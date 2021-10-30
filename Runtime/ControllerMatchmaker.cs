namespace UnityEngine.InputSystem
{
#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoad]
#endif
    public class ControllerMatchmaker : Gamepad
    {
        static ControllerMatchmaker()
        {
            Initialize();
        }

#if UNITY_EDITOR
        [UnityEditor.Callbacks.DidReloadScripts]
        private static void ReloadedScripts()
        {
            Initialize();
        }
#endif

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Initialize()
        {
            GameCubeController.SelfRegister();
            HORIPADSwitchController.SelfRegister();
            PowerACorePlusController.SelfRegister();
        }
    }
}
