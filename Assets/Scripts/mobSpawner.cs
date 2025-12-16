using System.Collections;
using UnityEngine;

public class mobSpawner : MonoBehaviour
{
    public GameObject mobPrefab;
    public SOEnemy[] difEnemies;
    public float inBetweenSpawnTime = 0.5f;
    private bool canSpawn = true;  

    void FixedUpdate()
    {
        if(canSpawn) StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        canSpawn = false;
        float randfloat = Random.Range(-8f, 8f);
        Vector2 pos = new Vector2(transform.position.x + randfloat, transform.position.y);
        int randint = Random.Range(0, difEnemies.Length);
        var newEnemy = Instantiate(mobPrefab, pos, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().Initialise(difEnemies[randint]);
        yield return new WaitForSeconds(inBetweenSpawnTime);
        canSpawn = true;


    }

}
