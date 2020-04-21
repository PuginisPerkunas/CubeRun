using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float startDelay = 2.0f;
    public float spawnTime = 1.0f;
    public Vector3 spawnPositionLocation;
    public GameObject[] enemysPrefabs;
    public EnemyData[] enemysData;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", startDelay, spawnTime);
    }

    private void CreateEnemy(){
        Vector3 spawnPosition = new Vector3(
            x: Random.Range(-spawnPositionLocation.x, spawnPositionLocation.x),
            y: spawnPositionLocation.y,
            z: spawnPositionLocation.z
        );
        //todo reikia sugalvoti kaip spawninti AI enemy 
        GameObject randomEnemy = enemysPrefabs[Random.Range(0, enemysPrefabs.Length)];
        var newGameObject = Instantiate(randomEnemy, spawnPosition, Quaternion.identity);
        EnemyData randomEnemyData = enemysData[Random.Range(0, enemysData.Length)];
        newGameObject.GetComponent<EnemyDisplay>()?.ApplyEnemyPropertys(randomEnemyData);
    }
}
