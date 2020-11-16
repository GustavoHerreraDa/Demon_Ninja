using UnityEngine;

public class HiddenWall : Destructable
{
    public GameObject hiddenArea;
    public GameObject hiddenFog;
    public override void Awake()
    {
        base.Awake();
        damageFeedBack = GetComponent<ColorFeedback>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        MaxHealth = 40;
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MaxHealth = CurrentHealth;

        if (!IsAlive)
        {
            if (hiddenArea != null)
                hiddenArea.SetActive(true);

            if (hiddenFog != null)
                hiddenFog.SetActive(false);

            PlaySound();
            DeathEffect();
            Destroy(gameObject);
        }
    }

}
