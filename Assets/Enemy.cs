using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed  = 0.1f;
    public float health = 100f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void Hit(float dmg)
    {
        health -= dmg; 
        if(health < 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }
}
