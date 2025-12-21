using UnityEngine;

public class Wall : MonoBehaviour
{
    public float wallHealth = 1000f;
    public GameObject hitEffect;
    public GameObject destroyWallEffect;
    public SpriteRenderer sprite;
    public UIManager uiManager;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(hitEffect, collision.gameObject.transform.position, Quaternion.identity,this.transform);
            Destroy(collision.gameObject);
            wallHealth -= 10;
            if(wallHealth <= 0)
            {
                UIManager.Instance.Lose();
                destroyWallEffect.SetActive(true);
                sprite.enabled = false;
                wallHealth = 0;
                Destroy(gameObject);
            }
            uiManager.UpdateSlider(wallHealth);
        }
    }

}
