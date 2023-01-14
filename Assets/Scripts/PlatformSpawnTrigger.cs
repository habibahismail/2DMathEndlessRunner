using UnityEngine;

namespace bebaSpace
{
    public class PlatformSpawnTrigger : MonoBehaviour
    {
        private bool isTriggered = false;

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && !isTriggered )
            {
                isTriggered = true;
                GameEvents.OnReachedPlatformTriggerSpawnPoint();
            }
        }
    }
}
