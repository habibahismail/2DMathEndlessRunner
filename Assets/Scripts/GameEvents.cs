using UnityEngine;

namespace bebaSpace
{
    public class GameEvents : MonoBehaviour
    {
        public static System.Action ReachedPlatformTriggerSpawnPoint;
        public static System.Action<float> PlatformGenerated;


        public static void OnReachedPlatformTriggerSpawnPoint()
        {
            ReachedPlatformTriggerSpawnPoint?.Invoke();
        }

        public static void OnPlatformGenerated(float lastXpos)
        {
            PlatformGenerated?.Invoke(lastXpos);
        }

    }
}
