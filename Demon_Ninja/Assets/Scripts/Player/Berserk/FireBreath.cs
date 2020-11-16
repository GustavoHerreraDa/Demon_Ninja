using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreath : MonoBehaviour
{
    // Start is called before the first frame update
    float fire_speed = 7;

    private int damage;
    private Vector3 position;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetPosition(Vector3 position)
    {
        this.position = position.normalized;
    }

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += position * Time.deltaTime * fire_speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.substractHealth(damage);
            enemyScript.BeingHurt();
            Destroy(gameObject);
        }
    }

}
