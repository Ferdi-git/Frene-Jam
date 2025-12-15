using System.Collections;
using UnityEngine;

public class mobSpawner : MonoBehaviour
{
    public GameObject mobPrefab;
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
        Instantiate(mobPrefab, pos, Quaternion.identity);
        yield return new WaitForSeconds(inBetweenSpawnTime);
        canSpawn = true;


    }

}
