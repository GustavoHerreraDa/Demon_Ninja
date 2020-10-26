using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private int deathDamage;

    void Start()
    {
        deathDamage = 99999;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.substractHealth(deathDamage);
                player.Hurt();
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerController player = collider.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.substractHealth(deathDamage);
                player.Hurt();
            }
        }
    }

}
