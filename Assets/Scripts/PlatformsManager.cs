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
    private int platformLenght = 150;
    private int zOffset = 0;

    List<List<GameObject>> obsticlesForPlatform = new List<List<GameObject>>();

    void Start()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            Vector3 positionOfPlatform = new Vector3(0, 0, i * platformLenght);
            var platformOf = Instantiate(platforms[i], positionOfPlatform, Quaternion.Euler(0, 0, 0));
            zOffset += platformLenght;
            SpawnObsiclesOnPlatform(platformOf);
        }
    }
    internal void RecyclePlatform(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, zOffset);
        zOffset += platformLenght;
        SpawnObsiclesOnPlatform(platform);
        RemoveOldObsticles();
    }

    private void RemoveOldObsticles()
    {
        List<GameObject> lastParticles = obsticlesForPlatform.First();
        foreach (GameObject item in lastParticles)
        {
            Destroy(item);
        }
        obsticlesForPlatform.Remove(lastParticles);
    }

    private void SpawnObsiclesOnPlatform(GameObject platformSelf)
    {
        var listOfObsticlesOnPlatform = new List<GameObject>();
        for (int i = 0; i < obsticles.Length; i++)
        {
            var xOfPlatform = 8;
            var yOfPlatform = platformSelf.transform.localScale.y;
            var zOfPlatform = platformSelf.transform.position.z;

            Vector3 randomPosition = new Vector3(
                x: Mathf.Round(Random.Range(-(8), 8)),
                y: 2f,
                //todo change hardcoded value to opsticle  z size
                z: Mathf.Round(Random.Range( zOfPlatform - 10, zOfPlatform - 60))
            );
            GameObject obsticle = Instantiate(obsticles[i], randomPosition, Quaternion.identity);
            listOfObsticlesOnPlatform.Add(obsticle);
        }
        obsticlesForPlatform.Add(listOfObsticlesOnPlatform);
    }
}
