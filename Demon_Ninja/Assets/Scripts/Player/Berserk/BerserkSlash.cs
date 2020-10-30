using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkSlash : MonoBehaviour
{
    public BerserkController berserk;
    private int damage;


    public void SetDamage(int damage) {
        this.damage = damage;
    }


    public void Awake()
    {
        this.SetDamage(berserk.Damage);
        //Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.substractHealth(damage);
            enemyScript.BeingHurt();
        }
    }
}
