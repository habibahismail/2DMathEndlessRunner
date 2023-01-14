using System.Collections.Generic;
using UnityEngine;

namespace bebaSpace
{
    public class PlatformGenerator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> thePlatforms;
        [SerializeField] private GameObject lastStarterPlatform;
        [SerializeField] private Transform platformParent;
        [SerializeField] private float platformXoffset;


        private float platformSize = 0;
        private GameObject lastGeneratedPlatform;
        private GameObject currentPlatform;

        private void Start()
        {
            lastGeneratedPlatform = lastStarterPlatform;

            if (platformSize == 0) { platformSize = 30; }

            GameEvents.PlatformGenerated += SetLastPlatformWidth;
            GameEvents.ReachedPlatformTriggerSpawnPoint += InstantiateNewPlatform;
            
        }

        private void InstantiateNewPlatform()
        {
            int index = Random.Range(0, thePlatforms.Count);
            GameObject platformToInstantiate = thePlatforms[index];

            Debug.Log("platform size = " + platformSize);

            float xPos = Mathf.RoundToInt(lastGeneratedPlatform.transform.position.x + platformSize + platformXoffset);
            Vector3 position = new Vector3( xPos , 0, 0);

            Debug.Log("lastGeneratedPlatform pos x: " + lastGeneratedPlatform.transform.position.x);
            Debug.Log("xPos = " + xPos);

            currentPlatform = Instantiate(platformToInstantiate, position, Quaternion.identity, platformParent);

            lastGeneratedPlatform = currentPlatform;
            
        }

        private void SetLastPlatformWidth(float scale)
        {
            platformSize = scale;
        }

    }
}
