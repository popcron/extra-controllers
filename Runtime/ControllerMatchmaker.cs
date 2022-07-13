namespace UnityEngine.InputSystem
{
#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoad]
#endif
    public static class ControllerMatchmaker
    {
#if UNITY_EDITOR
        [UnityEditor.Callbacks.DidReloadScripts]
        private static void ReloadedScripts()
        {
            Trigger();
        }
#endif

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void StartedPlaying()
        {
            Trigger();
        }

        private static void Trigger()
        {
            GameCubeController.SelfRegister();
            HORIPADSwitchController.SelfRegister();
            PowerACorePlusController.SelfRegister();
        }
    }
}
