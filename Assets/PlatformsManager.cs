using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platforms;
    [SerializeField]
    private GameObject[] obsticles;
    [SerializeField]
    private int platformLenght = 50;
    private int zOffset = 0;
    private int platformsIndex = 0;

    Dictionary<int, List<GameObject>> obsticlesForPlatform = new Dictionary<int, List<GameObject>>();

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < platforms.Length; i++)
        {
            Vector3 positionOfPlatform = new Vector3(0,0, i * platformLenght);
            Instantiate(platforms[i], positionOfPlatform, Quaternion.Euler(0,0,0));
            platformsIndex = i;
            zOffset += 50;
            SpawnObsiclesOnPlatform(positionOfPlatform);
        }    
    }
    internal void RecyclePlatform(GameObject platform)
    {
        platform.transform.position = new Vector3(0,0, zOffset);
        zOffset += platformLenght;
        platformsIndex += 1;
        SpawnObsiclesOnPlatform(platform.transform.position);
        RemoveOldObsticles();
    }

    private void RemoveOldObsticles()
    {
        List<GameObject> lastParticles = obsticlesForPlatform.Values.Last();
        foreach (GameObject item in lastParticles)
        {
            Destroy(item);
        }
    }

    private void SpawnObsiclesOnPlatform(Vector3 positionOfPlatform)
    {
        var listOfObsticlesOnPlatform = new List<GameObject>();

        for (int i = 0; i < obsticles.Length; i++)
        {
            Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 2, positionOfPlatform.z);
            var obsticle = Instantiate(obsticles[i], randomPosition, Quaternion.identity);
            listOfObsticlesOnPlatform.Add(obsticle);
        }
        Debug.Log("Size of obsticlesList: " + listOfObsticlesOnPlatform.Count.ToString());
        obsticlesForPlatform.Add(platformsIndex,listOfObsticlesOnPlatform);
    }
}
