using System.Collections;
using UnityEngine;

public class mobSpawner : MonoBehaviour
{
    public GameObject mobPrefab;
    public Vague[] difVagues;
    private bool canSpawn = true;  
    private int currentWave = 0;

    private void Start()
    {
        currentWave = 0;
        StartCoroutine(WaveDuration());
    }

    void FixedUpdate()
    {
        if(canSpawn) StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        canSpawn = false;
        float randfloat = Random.Range(-8f, 8f);
        Vector2 pos = new Vector2(transform.position.x + randfloat, transform.position.y);
        int randint = Random.Range(0, difVagues[currentWave].enemies.Length);
        var newEnemy = Instantiate(mobPrefab, pos, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().Initialise(difVagues[currentWave].enemies[randint]);
        yield return new WaitForSeconds(difVagues[currentWave].spawnInterval);
        canSpawn = true;


    }

    private IEnumerator WaveDuration()
    {
        while (currentWave < difVagues.Length-1)
        {
            yield return new WaitForSeconds(difVagues[currentWave].waveLength);
            currentWave++;

        }
        print("Win");
    }

}
