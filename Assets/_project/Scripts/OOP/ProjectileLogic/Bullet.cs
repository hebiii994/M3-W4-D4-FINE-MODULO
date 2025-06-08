using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    //usiamo OnHit che è obbligatoria

    protected override void OnHit(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            LifeController enemyLife = collider.GetComponent<LifeController>();

            if (enemyLife != null )
            {
                enemyLife.TakeDamage(GetDamage());
            }
            Destroy(gameObject);
        }
        else if (collider.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
