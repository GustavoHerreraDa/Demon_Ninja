using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkSlash : MonoBehaviour
{
    private int damage;
    public void SetDamage(int damage) {
        this.damage = damage;
    }

    public void Awake()
    {
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.substractHealth(damage);
            enemyScript.BeingHurt();
            Debug.Log("Damage " + enemyScript.name + " Health " + enemyScript.CurrentHealth);
        }
    }
}
