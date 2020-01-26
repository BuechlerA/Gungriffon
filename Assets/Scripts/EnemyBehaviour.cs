using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IDamageable
{
    public float health = 4f;
    private bool isDead = false;

    public GameObject deathParticle;

    private void Start()
    {

    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        if (!isDead)
        {
            Debug.Log(gameObject.name + " took Damage");
            health -= damage;
            if (health <= 0f)
            {
                isDead = true;
                Die();
            }
        }
        else
        {
            return;
        }
    }

    private void Die()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.2f);
    }

}
