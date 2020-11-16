using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BerserkUI : MonoBehaviour
{
    public Image cooldownCycle;
    public float fireCooldown;
    public Color originalColor;
    void Start()
    {
        Debug.Log("START BERSERK UI");
        originalColor = cooldownCycle.color;

        var berserk = FindObjectOfType<BerserkController>();
        if (berserk is null)
        {
            this.gameObject.SetActive(false);
            return;
        }
        fireCooldown = berserk.fireCooldown;
        berserk.SetCircle(this);
    }

    public void Fire()
    {
        StartCoroutine(ShootCooldown());
    }

    IEnumerator ShootCooldown()
    {
        float ticks = 0;

        cooldownCycle.color = Color.red;
        cooldownCycle.fillAmount = 0;

        while (ticks < fireCooldown)
        {
            ticks += Time.deltaTime;
            cooldownCycle.fillAmount = ticks;
            yield return null;
        }

        CompletedFireCooldown();
    }

    public void CompletedFireCooldown()
    {
        cooldownCycle.color = originalColor;
        cooldownCycle.fillAmount = 1;
    }

}
