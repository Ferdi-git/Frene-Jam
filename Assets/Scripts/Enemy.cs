using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed  = 0.1f;
    public float health = 100f;
    public ParticleSystem particleSystem;
    public SpriteRenderer spriteRenderer;
    private SOEnemy soEnemy;

    public void Initialise(SOEnemy so)
    {
        soEnemy = so;
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
        particleSystem.Play();

        if (health < 0)
        {
            health = 0;
            ScoreManager.instance.AddToScore(soEnemy.points);
            PopupManager.instance.CreatePopup(transform.position, soEnemy.points);
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
