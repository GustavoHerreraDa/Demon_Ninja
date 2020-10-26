using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthSlider;

    public bool IsAlive
    { get; set; }

    public float MaxHealth
    { get; set; }

    [SerializeField]
    public float CurrentHealth
    { get; set; }

    public void addHealth(int health)
    {
        CurrentHealth += health;

        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
    }

    public void substractHealth(int health)
    {
        CurrentHealth -= health;

        if (CurrentHealth < 0)
            CurrentHealth = 0;

        if (CurrentHealth == 0)
            IsAlive = false;
    }

    // Use this for initialization
    void Start()
    {
        IsAlive = true;
    }

    public void Revive()
    {
        IsAlive = true;
        CurrentHealth = MaxHealth;
    }

    public float CalculateHealthForSlider()
    {
        return CurrentHealth / MaxHealth;
    }

    public virtual void Update()
    {

        if (healthSlider != null)
        {
            healthSlider.value = CalculateHealthForSlider();
            Debug.Log("healthSlider.value " + healthSlider.value);
        }
    }
}
