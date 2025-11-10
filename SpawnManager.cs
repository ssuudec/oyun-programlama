using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;



    [SerializeField]
    private GameObject tripleShotBonusPrefab;


    [SerializeField]
    private GameObject enemyContainer;
    

    [SerializeField]
    private bool stopSpawning = false;
     




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnBonusRoutine());
    }



    IEnumerator SpawnEnemyRoutine()
    {
        while (stopSpawning == false)
        {
            Vector3 position = new Vector3(Random.Range(-9.5f, 9.5f), 7.4f, 0);

            GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            enemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }

    }

    IEnumerator SpawnBonusRoutine()
    {
        while(stopSpawning == false)
        {
            Vector3 position = new Vector3(Random.Range(-9.18f, 9.18f), 7.7f, 0);
            GameObject TripleShotBonus = Instantiate(tripleShotBonusPrefab, position, Quaternion.identity);
            int WaitTime = Random.Range(3, 8);
            Debug.Log("Üçlü atış bekleme süresi" + WaitTime);
            yield return new WaitForSeconds(WaitTime);
 
        }
    }



    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }
    




}
