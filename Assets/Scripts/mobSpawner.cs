using System.Collections;
using UnityEngine;

public class mobSpawner : MonoBehaviour
{
    public GameObject mobPrefab;
    public Vague[] difVagues;
    public float inBetweenSpawnTime = 0.5f;
    private bool canSpawn = true;  
    private int curentWave = 0;

    void FixedUpdate()
    {
        if(canSpawn) StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        canSpawn = false;
        float randfloat = Random.Range(-8f, 8f);
        Vector2 pos = new Vector2(transform.position.x + randfloat, transform.position.y);
        int randint = Random.Range(0, difVagues[curentWave].enemies.Length);
        var newEnemy = Instantiate(mobPrefab, pos, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().Initialise(difVagues[curentWave].enemies[randint]);
        yield return new WaitForSeconds(difVagues[curentWave].spawnInterval);
        canSpawn = true;


    }

}
