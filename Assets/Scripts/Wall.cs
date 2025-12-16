using UnityEngine;

public class Wall : MonoBehaviour
{
    public float wallHealth = 1000f;
    public UIManager uiManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            wallHealth -= 10;
            if(wallHealth <= 0)
            {
                wallHealth = 0;
                Destroy(gameObject);
            }
            uiManager.UpdateSlider(wallHealth);
        }
    }

}
