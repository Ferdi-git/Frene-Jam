using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private CircleCollider2D triggerZone;
    private bool isAttacking = false;
    public float damage = 25;
    public float atkCooldown = 0.75f;

    private void Start()
    {
        triggerZone = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }

    public void TeleportPlayer(Vector2 newPos)
    {
        transform.position = newPos;
    }

    private void FixedUpdate()
    {
        if (!isAttacking) {CheckInZone(); }
    }

    private void CheckInZone()
    {
        isAttacking=true;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, triggerZone.radius);

        if (hitColliders.Length > 0)
        {
            foreach (Collider2D col in hitColliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    animator.SetTrigger("Attack");
                    col.GetComponent<Enemy>().Hit(damage);
                }
            }
        }
        StartCoroutine(CoAttackCoolDown());
    }

    private IEnumerator CoAttackCoolDown()
    {
        yield return new WaitForSeconds(atkCooldown);
        isAttacking = false;
    }
   
}
