using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed  = 0.1f;
    public float health = 100f;
    public SpriteRenderer spriteRenderer;

    public void Initialise(SOEnemy so)
    {
        speed = so.speed;
        health = so.life;
        spriteRenderer.sprite = so.sprite;
        transform.localScale = new Vector2(so.scale, so.scale) ;
    }


    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void Hit(float dmg)
    {
        StartCoroutine(CoBlink());

        health -= dmg; 
        if(health < 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }

    private IEnumerator CoBlink()
    {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = Color.white;
    }
}
